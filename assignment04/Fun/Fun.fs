(* File Fun/Fun.fs
   A strict functional language with integers and first-order 
   one-argument functions * sestoft@itu.dk

   Does not support mutually recursive function bindings.

   Performs tail recursion in constant space (because F# does).
*)

module Fun

open Absyn

(* Environment operations *)

type 'v env = (string * 'v) list

let rec lookup env x =
    match env with 
    | []        -> failwith (x + " not found")
    | (y, v)::r -> if x=y then v else lookup r x;;

(* A runtime value is an integer or a function closure *)

type value = 
  | Int of int
  //changed Closure from string to string list
  //| Closure of string * (string) list * expr * value env
  | Closure of string * (string) list * expr * (string * value) list  (* (f, xs, fBody, fDeclEnv) *)

let rec eval (e : expr) (env : value env) : int =
    match e with 
    | CstI i -> i
    | CstB b -> if b then 1 else 0
    | Var x  ->
      match lookup env x with
      | Int i -> i 
      | _     -> failwith "eval Var"
    | Prim(ope, e1, e2) -> 
      let i1 = eval e1 env
      let i2 = eval e2 env
      match ope with
      | "*" -> i1 * i2
      | "+" -> i1 + i2
      | "-" -> i1 - i2
      | "=" -> if i1 = i2 then 1 else 0
      | "<" -> if i1 < i2 then 1 else 0
      | _   -> failwith ("unknown primitive " + ope)
    | Let(x, eRhs, letBody) -> 
      let xVal = Int(eval eRhs env)
      let bodyEnv = (x, xVal) :: env
      eval letBody bodyEnv
    | If(e1, e2, e3) -> 
      let b = eval e1 env
      if b<>0 then eval e2 env
      else eval e3 env
    //old stuff
    // | Letfun(f, x, fBody, letBody) ->  
    //   let bodyEnv = (f, Closure(f, x, fBody, env)) :: env
    //   eval letBody bodyEnv
    // | Call(Var f, eArg) -> 
    //   let fClosure = lookup env f
    //   match fClosure with
    //   | Closure (f, x, fBody, fDeclEnv) -> 
    //     let xVal = Int(eval eArg env) 
    //     // let fBodyEnv = (x, xVal) :: (f, fClosure) :: fDeclEnv
    //     let fBodyEnv = (x, xVal) :: (f, fClosure) :: env
    //     eval fBody fBodyEnv
    //   | _ -> failwith "eval Call: not a function"
    // | Call _ -> failwith "eval Call: not first-order function"

    //new stuff
    | Letfun(f, xs, fBody, letBody) ->  
      let bodyEnv = (f, Closure(f, xs, fBody, env)) :: env
      eval letBody bodyEnv
    | Call(Var f, eArgs) -> 
      let fClosure = lookup env f
      match fClosure with
      | Closure (f, xs, fBody, fDeclEnv) -> 
        let xVals = List.map (fun eArg -> Int(eval eArg env)) eArgs // xVals now takes all elements of the list and gets int value from the element and adds it to a new list. 
        let fBodyEnv = List.zip xs xVals @ (f, fClosure) :: fDeclEnv // List.zip takes two lists and combines them into a list of tuples.
        eval fBody fBodyEnv
      | _ -> failwith "eval Call: not a function"
    | Call _ -> failwith "eval Call: not first-order function"

(* Evaluate in empty environment: program must have no free variables: *)

let run e = eval e [];;

(* Examples in abstract syntax *)

// let ex1 = Letfun("f1", "x", Prim("+", Var "x", CstI 1), 
//                  Call(Var "f1", CstI 12));;

// (* Example: factorial *)

// let ex2 = Letfun("fac", "x",
//                  If(Prim("=", Var "x", CstI 0),
//                     CstI 1,
//                     Prim("*", Var "x", 
//                               Call(Var "fac", 
//                                    Prim("-", Var "x", CstI 1)))),
//                  Call(Var "fac", Var "n"));;

// (* let fac10 = eval ex2 [("n", Int 10)];; *)

// (* Example: deep recursion to check for constant-space tail recursion *)

// let ex3 = Letfun("deep", "x", 
//                  If(Prim("=", Var "x", CstI 0),
//                     CstI 1,
//                     Call(Var "deep", Prim("-", Var "x", CstI 1))),
//                  Call(Var "deep", Var "count"));;
    
// let rundeep n = eval ex3 [("count", Int n)];;

// (* Example: static scope (result 14) or dynamic scope (result 25) *)

// let ex4 =
//     Let("y", CstI 11,
//         Letfun("f", "x", Prim("+", Var "x", Var "y"),
//                Let("y", CstI 22, Call(Var "f", CstI 3))));;

// (* Example: two function definitions: a comparison and Fibonacci *)

// let ex5 = 
//     Letfun("ge2", "x", Prim("<", CstI 1, Var "x"),
//            Letfun("fib", "n",
//                   If(Call(Var "ge2", Var "n"),
//                      Prim("+",
//                           Call(Var "fib", Prim("-", Var "n", CstI 1)),
//                           Call(Var "fib", Prim("-", Var "n", CstI 2))),
//                      CstI 1), Call(Var "fib", CstI 25)));;
                     
// (*4.2*)
// let rec sum n =
//     match n with
//     | 1 -> 1
//     | _ -> n + sum (n-1);;
 
// // SUM
// let ex6 = Letfun("sum", "n", 
//                   If(Prim("=", Var "n", CstI 1),
//                     CstI 1,
//                     Prim("+", Var "n", 
//                         Call(Var "sum",
//                         Prim("-", Var "n", CstI 1)))), 
//                     Call(Var "sum", Var "n"))

// let t6 = eval ex6 [("n", Int 1000)];;

// // POWER OF
// let rec pow n m =
//     match m with
//     | 0 -> 1
//     | _ -> n * pow n (m-1);;

// let ex7 = Let("n", CstI 3, 
//             Letfun("pow", "m", 
//                     If(Prim("=", Var "m", CstI 1),
//                       Var "n",
//                       Prim("*", Var "n", 
//                           Call(Var "pow",
//                           Prim("-", Var "m", CstI 1)))), 
//                       Call(Var "pow", Var "m")))

// let t7 = eval ex7 [("m", Int 8)];;

// // SUM OF POWERS
// let rec sumPower n m =
//     match m with
//     | 0 -> pow n m
//     | _ -> pow n m + sumPower n (m-1);;

// let ex8 = 
//     Let("n", CstI 3, 
//         Letfun("pow", "m", 
//             If(Prim("=", Var "m", CstI 0),
//                 CstI 1,
//                 Prim("*", Var "n", 
//                     Call(Var "pow", Prim("-", Var "m", CstI 1)))),
//             Letfun("sumPower", "m",
//                 If(Prim("=", Var "m", CstI 0),
//                     Call(Var "pow", Var "m"),
//                     Prim("+", 
//                         Call(Var "pow", Var "m"),
//                         Call(Var "sumPower", Prim("-", Var "m", CstI 1)))),
//                 Call(Var "sumPower", Var "m"))))

// // equates to 265720
// let t8 = eval ex8 [("m", Int 11)];;

// let ex9 = 
//     Let("m", CstI 8, 
//         Letfun("pow", "i", 
//             If(Prim("=", Var "i", CstI 0),
//                 CstI 1,
//                 Prim("*", Var "n", 
//                     Call(Var "pow", Prim("-", Var "i", CstI 1)))),
//             Letfun("sum", "n",
//                 If(Prim("=", Var "n", CstI 10),
//                     Call(Var "pow", Var "m"), // was n before
//                     Prim("+", 
//                         Call(Var "pow", Var "m"), // was n before
//                         Call(Var "sum", Prim("+", Var "n", CstI 1)))),
//                 Call(Var "sum", Var "n"))))

// // Evaluate ex9 with the environment [("n", Int 1)]
// let t9 = eval ex9 [("n", Int 1)];;



(*

let rec power n m =
    match m with
    | 0 -> 1
    | _ -> n * power n (m-1);;

let rec sumPower n m =
    match m with
    | 0 -> power n m
    | _ -> power n m + sumPower n (m-1);;

let rec sumPower2 n m =
    match m with
    | 0 -> 1
    | _ -> power n m + sumPower2 n (m-1);;*)


// let e1 = fromString "5+7";;
// let e2 = fromString "let y = 7 in y + 2 end";;
// let e3 = fromString "let f x = x + 7 in f 2 end";;

// run (fromString "5+7");;
// run (fromString "let y = 7 in y + 2 end");;
// run (fromString "let f x = x + 7 in f 2 end");;








