(* Programming language concepts for software developers, 2012-02-17 *)

(* Evaluation, checking, and compilation of object language expressions *)
(* Stack machines for expression evaluation                             *) 

(* Object language expressions with variable bindings and nested scope *)

module Intcomp1

type expr = 
  | CstI of int
  | Var of string
  | Let of (string * expr) list * expr
  // old code
  // | Let of string * expr * expr
  | Prim of string * expr * expr;;

(* ---------------------------------------------------------------------- *)

(* Evaluation of expressions with variables and bindings *)

let rec lookup env x =
    match env with 
    | []        -> failwith (x + " not found")
    | (y, v)::r -> if x=y then v else lookup r x;;

//ex 2.1 
let rec eval e (env : (string * int) list) : int =
    match e with
    | CstI i            -> i
    | Var x             -> lookup env x
    | Let(xList, body)  ->
          let rec evalBind env xList =
              match xList with
              | [] -> env
              | (x, e)::xr ->
                  let xval = eval e env
                  let env1 = (x, xval) :: env
                  evalBind env1 xr
          let env1 = evalBind env xList
          eval body env1

    | Prim("+", e1, e2) -> eval e1 env + eval e2 env
    | Prim("*", e1, e2) -> eval e1 env * eval e2 env
    | Prim("-", e1, e2) -> eval e1 env - eval e2 env
    | Prim _            -> failwith "unknown primitive";;

let run e = eval e [];;

//old needed code
let rec mem x vs = // aka list.exist 
    match vs with
    | []      -> false
    | v :: vr -> x=v || mem x vr;;

let rec lookOrSelf env x =
    match env with 
    | []        -> Var x
    | (y, e)::r -> if x=y then e else lookOrSelf r x;;

let rec remove env x =
    match env with 
    | []        -> []
    | (y, e)::r -> if x=y then r else (y, e) :: remove r x;;

let newVar : string -> string = 
    let n = ref 0
    let varMaker x = (n := 1 + !n; x + string (!n))
    varMaker;;


(* ---------------------------------------------------------------------- *)

(* Free variables *)

(* Operations on sets, represented as lists.  Simple but inefficient;
   one could use binary trees, hashtables or splaytrees for
   efficiency.  *)

(* union(xs, ys) is the set of all elements in xs or ys, without duplicates *)
// mem: does element x exist in set ys
let rec union (xs, ys) = 
    match xs with 
    | []    -> ys
    | x::xr -> if mem x ys then union(xr, ys)
               else x :: union(xr, ys);;

(* minus xs ys  is the set of all elements in xs but not in ys *)
// mem: does element x exist in set ys
let rec minus (xs, ys) = 
    match xs with 
    | []    -> []
    | x::xr -> if mem x ys then minus(xr, ys)
               else x :: minus (xr, ys);;

(* Find all variables that occur free in expression e *)

// ex 2.2
// Revise the function freevars : expr -> string list to
// work for the language as extended in Exercise 2.1.

// Note: freevars lists all the FREE variables that appear in an expression
// by going through the expression and checking if the variable is bound

// look at one of the examples, tes1v should give back the FREE variable "y", 
// since that has not been given any value
let rec freevars e : string list =
    match e with
    | CstI i -> []
    | Var x  -> [x]
    | Let(xList, body) ->
        let rec freevarsBind env xList =
              match xList with
              | [] -> env
              | (x, e)::xr ->
                  let first = freevars e // freevars (CstI 5) -> []
                  let second = freevarsBind env xr // freevarsBind [] [] -> []
                  union (first, second) // union ([], [])
        let boundVars = freevarsBind [] xList // freevarsBind [] [("z", CstI 5)] -> []
        union (boundVars, minus (freevars body, List.map fst xList)) // (Going through with tes1 on line 261): union ([], minus (["y","z"], ["z"]) -> ["y"]
    
    | Prim(ope, e1, e2) -> union (freevars e1, freevars e2);;

//should give back ["y"]
let tes1 = Let([("z", CstI 5); ],  Prim("*", Var "y", Var "z"))
let tes1v = freevars tes1

let tes2 = Let([("z", CstI 5); ("y", CstI 6)],  Prim("*", Prim("*", Var "y", CstI 3), Var "z"))
let tes2v = freevars tes2

let tes3 = Let([("z", CstI 5); ("y", CstI 6); ("x", CstI 7); ("m", CstI 8); ],  Prim("*", Prim("*", Prim("*", Var "y", Var "z"), Var "K"), Prim("*", Var "s", Var "m")))
let tes3v = freevars tes3


(* ---------------------------------------------------------------------- *)

(* Compilation to target expressions with numerical indexes instead of
   symbolic variable names.  *)

type texpr =                            (* target expressions *)
  | TCstI of int
  | TVar of int                         (* index into runtime environment *)
  | TLet of texpr * texpr               (* erhs and ebody                 *)
  | TPrim of string * texpr * texpr;;

(* Map variable name to variable index at compile-time *)

let rec getindex vs x = // (when running tc1): ["z"; "y"] "y"
    match vs with 
    | []    -> failwith "Variable not found"
    | y::yr -> if x = y then 0 else 1 + getindex yr x;;  // (when running tc1): getindex [] "y" -> 2

(* Compiling from expr to texpr *)

// ex 2.3
// Revise the expr-to-texpr compiler tcomp : expr -> texpr
// from Intcomp1.fs to work for the extended expr language. There is no need
// to modify the texpr language or the teval interpreter to accommodate multiple
// sequential let-bindings.

// Note: tcomp is a function that takes an expression and a list of strings and returns a texpr
// by going through the expression and converting it to a texpr
// aka translate expr to texpr
let rec tcomp (e : expr) (cenv : string list) : texpr =
    match e with
    | CstI i -> TCstI i
    | Var x  -> TVar (getindex cenv x) // (when running tc1): getindex [ "y"; "z"] "y"

    | Let(xList, body) ->
        let rec tcompBind cenv xList =
              match xList with
              | [] -> tcomp body cenv // (when running tc1): tcomp (Prim("*", Var "y", Var "z")) ["y", "z"] -> TPrim(ope, (TVar 0), (TVar 1))
              | (x, e) :: xr -> 
                  let first = tcomp e cenv // (when running tc1): tcomp CstI 5 [] -> TCstI 5 
                  let second = tcompBind (x :: cenv) xr // (when running tc1): tcompBind ("z" :: []) [("y", CstI 6)]
                  TLet(first, second)
        tcompBind cenv xList
    
    | Prim(ope, e1, e2) -> TPrim(ope, tcomp e1 cenv, tcomp e2 cenv);; // TPrim(ope, (TVar 0), (TVar 1))

let tc1 = Let([("z", CstI 5); ("y", CstI 6) ],  Prim("*", Var "y", Var "z"))
let tc1v = tcomp tc1 [] // TLet(CstI 5, TLet(CstI 6, TPrim("+", (TVar 0), (TVar 1)))
