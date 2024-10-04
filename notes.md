useful links:
https://github.itu.dk/nh/ProgramsAsDataCodeE2024
C compiler: https://www.onlinegdb.com/online_c_compiler

For exam:
(1) https://github.com/NoticeMeDan/bprd-assignments/tree/master



where we are in assignment06;

7.3
we are thinking about changing the parser to
| FOR LPAR StmtOrDecSeq SEMI Expr SEMI Expr RPAR StmtM  { For($3, $5, $7, $9)        } but are still thinking about it

Otherwise we need to look at changing our micro-c programs AA_ex7 .. etc to use for loops instead of while loops
