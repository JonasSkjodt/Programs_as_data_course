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


# 7.3


# 7.4


# 7.5