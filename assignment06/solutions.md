<style>
r { color: Red }
o { color: Orange }
g { color: Green }
</style>

# 7.1
We used fromFile "ex1.c";; to generate the following:
```
val it: Absyn.program =
  Prog 
    [Fundec
       (None, "main", [(TypI, "n")],
        Block
          [Stmt
             (While
                (Prim2 (">", Access (AccVar "n"), CstI 0),
                 Block
                   [Stmt (Expr (Prim1 ("printi", Access (AccVar "n"))));
                    Stmt
                      (Expr
                         (Assign
                            (AccVar "n",
                             Prim2 ("-", Access (AccVar "n"), CstI 1))))]));
           Stmt (Expr (Prim1 ("printc", CstI 10)))])]
```
Abstract syntax tree and indication of its parts, help was gathered from lecture 6 slide 26.

### Declarations:
<ul>
  <li>
     Prog 
  </li>
  <li>
    Fundec
  </li>
</ul>

### Statements:
<ul>
  <li>
    Block
  </li>
  <li>
    While 
  </li>
  <li>
    Stmt
  </li>
  <li>
    Expr
  </li>
</ul>

### Types:
<ul>
  <li>
    TypI
  </li>
</ul>

### Expressions:
<ul>
  <li>
    Prim2
  </li>
  <li>
    AccVar
  </li>
  <li>
    Prim1
  </li>
  <li>
    Assign
  </li>
  <li>
    CstI
  </li>
  <li>
    Access
  </li>
</ul>

# 7.2

We ran the commands to run the code we made in the files AA_ex7_2_1.c, AA_ex7_2_2.c, and AA_ex7_2_3.c.

When running "run (fromFile "AA_ex7_2_1.c") [];;"

```
37 val it: Interp.store =
  map
    [(0, 7); (1, 13); (2, 9); (3, 8); (4, 0); (5, 37); (6, 4); (7, 0); (8, 5);
     ...]
```

When running "run (fromFile "AA_ex7_2_2.c") [];;"

```
2470 val it: Interp.store =
  map
    [(0, 20); (1, 0); (2, 1); (3, 4); (4, 9); (5, 16); (6, 25); (7, 36);
     (8, 49); ...]
```

When running "run (fromFile "AA_ex7_2_3.c") [];;"
```
1 4 2 0 val it: Interp.store =
  map
    [(0, 7); (1, 3); (2, 1); (3, 2); (4, 1); (5, 1); (6, 1); (7, 2); (8, 0);
     ...]
```

# 7.3


# 7.4


# 7.5