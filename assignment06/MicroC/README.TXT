Compiling and loading the micro-C evaluator and parser (MicroC/README.TXT)
--------------------------------------------------------------------------

Archive microc.zip contains the files used in points A, B and C below.


A. Generating and compiling the lexer and parser for micro-C, and
   loading the interpreter for micro-C.

   fslex --unicode CLex.fsl
   fsyacc --module CPar CPar.fsy
   dotnet fsi -r /mnt/c/users/jonas/Desktop/fsharp/FsLexYacc.11.3.0/build/fslex/net6.0/FsLexYacc.Runtime.dll Util.fs Absyn.fs CPar.fs CLex.fs Parse.fs Interp.fs ParseAndRun.fs

   open ParseAndRun;;
   fromFile "AA_ex7_2_2.c";;
   run (fromFile "AA_ex7_2_1.c") [];;
   run (fromFile "AA_ex7_2_2.c") [];;
   run (fromFile "AA_ex7_2_3.c") [];;
   run (fromFile "AA_ex7_3_1.c") [];;
   run (fromFile "AA_ex7_3_2.c") [];;
   run (fromFile "AA_ex7_3_3.c") [];;
   run (fromFile "AA_ex7_4.c") [];;
   run (fromFile "ex1.c") [17];;
   run (fromFile "ex5.c") [4];;
   run (fromFile "ex11.c") [8];;


B. To compile and use the micro-C compiler

   fslex --unicode CLex.fsl
   fsyacc --module CPar CPar.fsy
   dotnet fsi -r /mnt/c/users/jonas/Desktop/fsharp/FsLexYacc.11.3.0/build/fslex/net6.0/FsLexYacc.Runtime.dll Util.fs Absyn.fs CPar.fs CLex.fs Parse.fs Machine.fs Comp.fs ParseAndComp.fs   

   open ParseAndComp;;
   compileToFile (fromFile "ex11.c") "ex11.out";;
   compile "ex11";;

The Java stack machine:

   javac Machine.java
   java Machine ex11.out 8

The C stack machine
   gcc -o machine machine.c
   ./machine ex11.out 8    

C. To compile and use the backwards (continuation-based) micro-C compiler:

   fslex --unicode CLex.fsl
   fsyacc --module CPar CPar.fsy
   //dotnet fsi -r ~/fsharp/FsLexYacc.Runtime.dll Util.fs Absyn.fs CPar.fs CLex.fs Parse.fs Machine.fs Contcomp.fs ParseAndContcomp.fs   
   dotnet fsi -r /mnt/c/users/jonas/Desktop/fsharp/FsLexYacc.11.3.0/build/fslex/net6.0/FsLexYacc.Runtime.dll Util.fs Absyn.fs CPar.fs CLex.fs Parse.fs Machine.fs Contcomp.fs ParseAndContcomp.fs 

   open ParseAndContcomp;;
   contCompileToFile (fromFile "ex11.c") "ex11.out";;
   contCompileToFile (fromFile "ex1.c") "ex1.out";;
   compile "ex11";;
   #q;;

   javac Machine.java
   java Machine ex11.out 8	


D. Build the backwards micro-C compiler as a command-line program microcc

   fslex --unicode CLex.fsl
   fsyacc --module CPar CPar.fsy

   dotnet build microcc.fsproj
   dotnet run ex11.c

   javac Machine.java
   java Machine ex11.out 8
