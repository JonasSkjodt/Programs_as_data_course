
# 1 "ExprLex.fsl"
 
(* File Expr/Exprlex.fsl
   Lexer specification for the simple expression language.
*)

module ExprLex

open FSharp.Text.Lexing
open ExprPar

let lexemeAsString lexbuf = 
    LexBuffer<char>.LexemeString lexbuf

(* Scan keywords as identifiers and use this function to distinguish them. *)
(* If the set of keywords is large, use a hashtable instead.               *)

let keyword s =
    match s with
    | "let" -> LET
    | "in"  -> IN
    | "end" -> END
    | _     -> NAME s

//# 26 "ExprLex.fs"
let trans : uint16[] array = 
    [| 
    (* State 0 *)
     [| 12us;12us;12us;12us;12us;12us;12us;12us;12us;1us;2us;12us;12us;1us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;1us;12us;12us;12us;12us;12us;12us;12us;9us;10us;7us;5us;12us;6us;12us;12us;3us;3us;3us;3us;3us;3us;3us;3us;3us;3us;12us;12us;12us;8us;12us;12us;12us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;12us;12us;12us;12us;12us;12us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;11us;|];
    (* State 1 *)
     [| 65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;|];
    (* State 2 *)
     [| 65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;|];
    (* State 3 *)
     [| 65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;14us;14us;14us;14us;14us;14us;14us;14us;14us;14us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;|];
    (* State 4 *)
     [| 65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;65535us;65535us;65535us;65535us;65535us;65535us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;|];
    (* State 5 *)
     [| 65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;|];
    (* State 6 *)
     [| 65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;|];
    (* State 7 *)
     [| 65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;|];
    (* State 8 *)
     [| 65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;|];
    (* State 9 *)
     [| 65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;|];
    (* State 10 *)
     [| 65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;|];
    (* State 11 *)
     [| 65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;|];
    (* State 12 *)
     [| 65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;|];
    (* State 13 *)
     [| 65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;65535us;65535us;65535us;65535us;65535us;65535us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;|];
    (* State 14 *)
     [| 65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;14us;14us;14us;14us;14us;14us;14us;14us;14us;14us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;|];
    |] 
let actions : uint16[] = [|65535us;0us;1us;2us;3us;4us;5us;6us;7us;8us;9us;10us;11us;3us;2us;|]
let _fslex_tables = FSharp.Text.Lexing.UnicodeTables.Create(trans,actions)
let rec _fslex_dummy () = _fslex_dummy() 
// Rule Token
and Token  lexbuf =
  match _fslex_tables.Interpret(0,lexbuf) with
  | 0 -> ( 
//# 26 "ExprLex.fsl"
                                     Token lexbuf 
//# 69 "ExprLex.fs"
          )
  | 1 -> ( 
//# 27 "ExprLex.fsl"
                                     lexbuf.EndPos <- lexbuf.EndPos.NextLine; Token lexbuf 
//# 74 "ExprLex.fs"
          )
  | 2 -> ( 
//# 28 "ExprLex.fsl"
                                     CSTINT (System.Int32.Parse (lexemeAsString lexbuf)) 
//# 79 "ExprLex.fs"
          )
  | 3 -> ( 
//# 30 "ExprLex.fsl"
                                     keyword (lexemeAsString lexbuf) 
//# 84 "ExprLex.fs"
          )
  | 4 -> ( 
//# 31 "ExprLex.fsl"
                                     PLUS  
//# 89 "ExprLex.fs"
          )
  | 5 -> ( 
//# 32 "ExprLex.fsl"
                                     MINUS 
//# 94 "ExprLex.fs"
          )
  | 6 -> ( 
//# 33 "ExprLex.fsl"
                                     TIMES 
//# 99 "ExprLex.fs"
          )
  | 7 -> ( 
//# 34 "ExprLex.fsl"
                                     EQ    
//# 104 "ExprLex.fs"
          )
  | 8 -> ( 
//# 35 "ExprLex.fsl"
                                     LPAR  
//# 109 "ExprLex.fs"
          )
  | 9 -> ( 
//# 36 "ExprLex.fsl"
                                     RPAR  
//# 114 "ExprLex.fs"
          )
  | 10 -> ( 
//# 37 "ExprLex.fsl"
                                     EOF   
//# 119 "ExprLex.fs"
          )
  | 11 -> ( 
//# 38 "ExprLex.fsl"
                                     failwith "Lexer error: illegal symbol" 
//# 124 "ExprLex.fs"
          )
  | _ -> failwith "Token"

//# 3000000 "ExprLex.fs"
