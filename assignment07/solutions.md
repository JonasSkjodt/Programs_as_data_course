# 8.1

(i)
We have made all the numeric instruction in: Instruction.md

(ii)
We have compiled the ex3.c and ex5.c. (And analyzed the bytecode in the file <instruction.md>, and printed out the trace in the files <ex3trace.txt> and <ex5trace.txt>.)

ex3.c
```
val it: Machine.instr list =
  [LDARGS; CALL (1, "L1"); STOP; Label "L1"; INCSP 1; GETBP; CSTI 1; ADD;
   CSTI 0; STI; INCSP -1; GOTO "L3"; Label "L2"; GETBP; CSTI 1; ADD; LDI;
   PRINTI; INCSP -1; GETBP; CSTI 1; ADD; GETBP; CSTI 1; ADD; LDI; CSTI 1; ADD;
   STI; INCSP -1; INCSP 0; Label "L3"; GETBP; CSTI 1; ADD; LDI; GETBP; CSTI 0;
   ADD; LDI; LT; IFNZRO "L2"; INCSP -1; RET 0]

```

ex5.c
```
val it: Machine.instr list =
  [LDARGS; CALL (1, "L1"); STOP; Label "L1"; INCSP 1; GETBP; CSTI 1; ADD;
   GETBP; CSTI 0; ADD; LDI; STI; INCSP -1; INCSP 1; GETBP; CSTI 0; ADD; LDI;
   GETBP; CSTI 2; ADD; CALL (2, "L2"); INCSP -1; GETBP; CSTI 2; ADD; LDI;
   PRINTI; INCSP -1; INCSP -1; GETBP; CSTI 1; ADD; LDI; PRINTI; INCSP -1;
   INCSP -1; RET 0; Label "L2"; GETBP; CSTI 1; ADD; LDI; GETBP; CSTI 0; ADD;
   LDI; GETBP; CSTI 0; ADD; LDI; MUL; STI; INCSP -1; INCSP 0; RET 1]
```

We can see the nested scope's visability in ex5.c from the call in the symbolic instructions below:

```
[ 4 -999 4 4 4 4 4 ]{30: CALL 2 57}
[ 4 -999 4 4 4 33 2 4 4 ]{57: GETBP}
...
```
After the call, we see a new stack frame has been placed in the stack.
The new stack frame being: <b>33 2 4 4</b>
33 = retaddr
2 = old bp
4 = n
4 = res

# 8.3
We have inserted the correct code to cExpr in comp.fs marked by the comment ex8.3 on line 225
We explored the explenation in traceExplenation.txt.

# 8.4
We have compiled the files, ex8.out, ex13.out, and prog1.out.

ex8.c compared to prog1

ex8.c uses STI to save the value while prog1 uses DUP to always keep the value on the top of the stack.
This requires a lot less code, which make it overall faster.

ex13.out
We have a goto in the bytecode which handles the while loop. 

The if-statement is controlled by a series of ifnzero & ifzero. The && and || cant really be seen in the bytecode, instead what happens is that the instructions simple jumps to the next condition if true, but jumps out of the if-statement if false. When all nessary conditions are true, it will then print out the value of the variable "y".



# 8.5
We added the Ternary operator to Absyn.fs with

```
| Ternary of expr * expr * expr
```

Then we added the lexer details like so:

```
  | "?"             { QUE }
  | ":"             { COL } 
```

Followed by modifying the parser:

```
%token QUE COL
    ...

%right QUE COL
    ...

StmtU:
    ...
  | Expr QUE Expr COL Expr              { Ternary($1, $3, $5)  }
```

In comp.fs we added the following code, almost just like the if statement:

```
| Ternary (e1, e2, e3) ->
      let labelse = newLabel()
      let labend  = newLabel()
      cExpr e1 varEnv funEnv @ [IFZERO labelse] 
      @ cExpr e2 varEnv funEnv @ [GOTO labend]
      @ [Label labelse] @ cExpr e3 varEnv funEnv
      @ [Label labend]
```

Which gives us the result from our microC code in the file AA_ex8_5:

```
> compileToFile (fromFile "AA_ex8_5.c") "AA_ex8_5.out";;
val it: Machine.instr list =
  [LDARGS; CALL (1, "L1"); STOP; Label "L1"; INCSP 1; GETBP; CSTI 1; ADD;
   CSTI 5; STI; INCSP -1; INCSP 1; GETBP; CSTI 2; ADD; CSTI 10; STI; INCSP -1;
   CSTI 0; IFZERO "L2"; GETBP; CSTI 2; ADD; LDI; PRINTI; GOTO "L3"; Label "L2";
   GETBP; CSTI 1; ADD; LDI; PRINTI; Label "L3"; INCSP -2; RET 0]
```

In Interp.fs we also add the following code, taken from the if stmt. The only change is that we uses expr instead of stmts. This will make it so it can be used with the "run" command.

```
Ternary(e1, e2, e3) -> 
      let (v, store1) = eval e1 locEnv gloEnv store
      if v<>0 then eval e2 locEnv gloEnv store1
              else eval e3 locEnv gloEnv store1
```


# 8.6

We changed Absyn, the parser and lexer to accomodate the switch cases.

In comp.fs (149) we added to the match case, so that switch cases can be given symbolic instructions 

we compiled a switch case example code from the file AA_ex8_6.c to give us the result:

```
> compileToFile (fromFile "AA_ex8_6.c") "AA_ex8_6_1.out";;
val it: Machine.instr list =
  [LDARGS; CALL (0, "L1"); STOP; Label "L1"; INCSP 1; GETBP; CSTI 0; ADD;
   CSTI 2; STI; INCSP -1; INCSP 1; INCSP 1; GETBP; CSTI 2; ADD; CSTI 8; STI;
   INCSP -1; GETBP; CSTI 0; ADD; LDI; CSTI 3; EQ; IFZERO "L5"; Label "L5";
   GETBP; CSTI 1; ADD; CSTI 31; STI; INCSP -1; INCSP 0; GOTO "L2"; GETBP;
   CSTI 0; ADD; LDI; CSTI 2; EQ; IFZERO "L4"; Label "L4"; GETBP; CSTI 1; ADD;
   CSTI 28; STI; INCSP -1; GETBP; CSTI 2; ADD; LDI; CSTI 4; MOD; CSTI 0; EQ;
   IFZERO "L6"; GETBP; CSTI 1; ADD; CSTI 29; STI; INCSP -1; GOTO "L7";
   Label "L6"; INCSP 0; Label "L7"; INCSP 0; GOTO "L2"; GETBP; CSTI 0; ADD;
   LDI; CSTI 1; EQ; IFZERO "L3"; Label "L3"; GETBP; CSTI 1; ADD; CSTI 31; STI;
   INCSP -1; INCSP 0; GOTO "L2"; Label "L2"; INCSP -3; RET -1]
```
We marked the code in comp.fs with the comment ex8.6

In interp.fs we add extended exec to be able to run switch cases marked by ex8.6 as a comment on line 148.

we used our example file AA_ex8_6.c code with the switch statement and ran it.

```
> run (fromFile "AA_ex8_6.c") [];;
28 val it: Interp.store = map [(0, 2); (1, 28); (2, 7)]
```