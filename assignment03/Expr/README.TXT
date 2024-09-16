Compiling and loading the expression evaluator and parser (Expr/README.TXT)
---------------------------------------------------------------------------

Archive expr.zip contains the files used below.

A. Generating and compiling the lexer and parser for the expression
   language:

   fslex --unicode ExprLex.fsl
   fsyacc --module ExprPar ExprPar.fsy
   fsharpi -r FsLexYacc.Runtime.dll Absyn.fs ExprPar.fs ExprLex.fs Parse.fs

   open Parse;;
   fromString "2 + 3 * 4";;     

   #q;;


B. Generating and compiling the lexer and parser for the expression
   language, and loading the interpreter eval, the compiler (to simple
   stack machine code) scomp, and the simple stack machine seval:

   fslex --unicode ExprLex.fsl
   fsyacc --module ExprPar ExprPar.fsy
   fsharpi -r FsLexYacc.Runtime.dll Absyn.fs ExprPar.fs ExprLex.fs Parse.fs Expr.fs

   open Parse;;
   open Expr;;
   run (fromString "2 + 3 * 4");;
   eval (fromString "2 + x * 4") [("x", 3)];;
   eval (fromString "let x = 1+2 in 2 + x * 4 end") [];;

   let code1 = scomp (fromString "2 + 3 * 4") [];;
   seval code1 [];;

   let code2 = scomp (fromString "2 + x * 4") [Bound "x"];;
   seval code2 [3];;

   let code3 = scomp (fromString "let x = 1+2 in 2 + x * 4 end") [];;
   seval code3 [];;

   let code4 = compString "let x = 1+2 in 2 + x * 4 end";;

   let code5 = compString "if 4 then 2 else 3";;
   
   let code6 = compString "let x = 1+2 if 0 then 2 else 3 end";;


   #q;;
