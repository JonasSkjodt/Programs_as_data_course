(* Programming language concepts for software developers, 2010-08-28 *)

(* Evaluating simple expressions with variables *)

module Intro2

(* Association lists map object language variables to their values *)

let env = [("a", 3); ("c", 78); ("baf", 666); ("b", 111)];;

let emptyenv = []; (* the empty environment *)

let rec lookup env x =
    match env with 
    | []        -> failwith (x + " not found")
    | (y, v)::r -> if x=y then v else lookup r x;;

let cvalue = lookup env "c";;


(* Object language expressions with variables *)

type expr = 
  | CstI of int
  | Var of string
  | Prim of string * expr * expr
  | If of expr * expr * expr

let e1 = CstI 17;;

let e2 = Prim("+", CstI 3, Var "a");;

let e3 = Prim("+", Prim("*", Var "b", CstI 9), Var "a");;


(* Evaluation within an environment *)

let rec eval e (env : (string * int) list) : int =
    match e with
    | CstI i            -> i
    | Var x             -> lookup env x 
    //| Prim("+", e1, e2) -> eval e1 env + eval e2 env
    //| Prim("*", e1, e2) -> eval e1 env * eval e2 env

    // 1.1 (iii)
    | Prim("-", e1, e2) -> eval e1 env - eval e2 env
    | Prim(ope, e1, e2) ->
        let v1 = eval e1 env
        let v2 = eval e2 env
        match ope with
        | "+" -> v1 + v2
        | "*" -> v1 * v2
        | "-" -> v1 - v2
        | "max" -> max (v1) (v2)
        | "min" -> min (v1) (v2)
        | "==" -> if v1 = v2 then 1 else 0

        | _ -> failwith "not operatable"

    // 1.1 (i)
    | Prim("max", e1, e2) -> max (eval e1 env) (eval e2 env)
    | Prim("min", e1, e2) -> min (eval e1 env) (eval e2 env)
    | Prim("==", e1, e2)  -> if eval e1 env = eval e2 env then 1 else 0

    // 1.1 (v)
    | If(e1, e2, e3) -> if ((eval e1 env) > 0) then eval e2 env else eval e3 env

    | Prim _            -> failwith "unknown primitive";;

let e1v  = eval e1 env;;
let e2v1 = eval e2 env;;
let e2v2 = eval e2 [("a", 314)];;
let e3v  = eval e3 env;;
 
//outputs 
// 1.1 (ii) 
let e4 = Prim("max", CstI 5, CstI 10);;
let e4v = eval e4 env;; 

let e5 = Prim("min", CstI 5, CstI 10);;
let e5v = eval e5 env;; 

let e6 = Prim("==", CstI 5, CstI 10);;
let e6v = eval e6 env;; 

// 1.1 (iii)
let e7 = Prim("+", CstI 3, Var "a");;
let e7v = eval e7 env;;

let e8 = Prim("-", CstI 3, Var "a");;
let e8v = eval e8 env;; 

let e9 = Prim("*", CstI 3, Var "a");;
let e9v = eval e9 env;; 

let e10 = Prim("max", CstI 3, Var "b");;
let e10v = eval e10 env;;

// 1.1 (v)
let e11 = If(Var "a", CstI 11, CstI 22);;
let e11v = eval e11 env;; 
    

//1.1, 1.2, 1.4, 2.1, 2.2, 2.3

// 1.2 (i)
// Then x ∗ (y + 3) is represented as Mul(Var "x", Add(Var "y",
// CstI 3)), not as Prim("*", Var "x", Prim("+", Var "y",
// CstI 3))
type aexpr =
  | CstI of int
  | Var of string
  | Add of aexpr * aexpr
  | Mul of aexpr * aexpr
  | Sub of aexpr * aexpr


// 1.2 (ii)
//v − (w + z)
let ae1 = Sub(Var "v", Add(Var "w", Var "z"))
// 2*(v-(w+z))
let ae2 = Mul(CstI 2, Sub(Var "v", Add(Var "w", Var "z")))
// x + y + z + v 
let ae3 = Add(Add(Add(Var "x", Var "y"), Var "z"), Var "v")

// 1.2 (iii)
// Write an F# function fmt : aexpr -> string to format expressions
// as strings. For instance, it may format Sub(Var "x", CstI 34) as the
// string "(x - 34)". It has very much the same structure as an eval function, but takes no environment argument (because the name of a variable is
// independent of its value).

let rec fmt (ae: aexpr) string =
    match ae with
    | CstI i            -> i
    | Var x             -> x
    | Add ae1 ae        -> "(" + (fmt ae1) + "+" + (fmt ae2) + ")" 
    | Sub ae1 ae        -> "(" + (fmt ae1) + "-" + (fmt ae2) + ")" 
    | mul ae1 ae        -> "(" + (fmt ae1) + "*" + (fmt ae2) + ")" 
    