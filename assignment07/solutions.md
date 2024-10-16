# 8.1

(i)
We have made all the numeric instruction in: Instruction.md

(ii)
We have compiled the ex3.c and ex5.c, analyzed the bytecode in the file instruction.md, and printed out the trace in the files ex3trace.txt and ex5trace.txt.

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
We have inserted the correct code to cExpr in comp.fs
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

Which gives us the result:

```
> compileToFile (fromFile "AA_ex8_5.c") "AA_ex8_5.out";;
val it: Machine.instr list =
  [LDARGS; CALL (1, "L1"); STOP; Label "L1"; INCSP 1; GETBP; CSTI 1; ADD;
   CSTI 5; STI; INCSP -1; INCSP 1; GETBP; CSTI 2; ADD; CSTI 10; STI; INCSP -1;
   CSTI 0; IFZERO "L2"; GETBP; CSTI 2; ADD; LDI; PRINTI; GOTO "L3"; Label "L2";
   GETBP; CSTI 1; ADD; LDI; PRINTI; Label "L3"; INCSP -2; RET 0]
```

# 8.6
I dont know what the fuck is going on (in comp.fs)
We changed Absyn, the parser and lexer to accomodate the switch cases. In comp.fs ...