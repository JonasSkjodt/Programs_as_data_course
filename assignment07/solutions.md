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

