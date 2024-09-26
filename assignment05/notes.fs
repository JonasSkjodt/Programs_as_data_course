//the comments in typ follow the example ex1 to understand the code
let ex1 = Letfun("f1", "x", TypI, Prim("+", Var "x", CstI 1), TypI, Call(Var "f1", CstI 12));;

let rec typ (e : tyexpr) (env : typ env) : typ =
    match e with
    | CstI i -> TypI
    | CstB b -> TypB
    | Var x  -> lookup env x                        // what type is var "x"? it is a TypI
    | Prim(ope, e1, e2) ->                          // Prim("+", Var "x", CstI 1)
      let t1 = typ e1 env                           // e1 = var "x" -> TypI
      let t2 = typ e2 env                           // e2 = CstI 1 -> TypI
      match (ope, t1, t2) with
      | ("*", TypI, TypI) -> TypI
      | ("+", TypI, TypI) -> TypI
      | ("-", TypI, TypI) -> TypI
      | ("=", TypI, TypI) -> TypB
      | ("<", TypI, TypI) -> TypB
      | ("&", TypB, TypB) -> TypB
      | _   -> failwith "unknown op, or type error"
    | Let(x, eRhs, letBody) -> 
      let xTyp = typ eRhs env 
      let letBodyEnv = (x, xTyp) :: env 
      typ letBody letBodyEnv
    | If(e1, e2, e3) -> 
      match typ e1 env with
      | TypB -> let t2 = typ e2 env
                let t3 = typ e3 env
                if t2 = t3 then t2
                else failwith "If: branch types differ"
      | _    -> failwith "If: condition not boolean"
      
    | Letfun(f, x, xTyp, fBody, rTyp, letBody) ->   // Letfun("f1", "x", TypI, Prim("+", Var "x", CstI 1), TypI, Call(Var "f1", CstI 12))
      let fTyp = TypF(xTyp, rTyp)                   // (typI, typI)
      let fBodyEnv = (x, xTyp) :: (f, fTyp) :: env  // ("x", TypI) :: ("f1", TypF(TypI, TypI)) :: []
      let letBodyEnv = (f, fTyp) :: env             // ("f1", TypF(TypI, TypI)) :: []
      if typ fBody fBodyEnv = rTyp                  // typ (Prim("+", Var "x", CstI 1)) (("x", TypI) :: ("f1", TypF(TypI, TypI)) :: []) -> TypI = TypI
      then typ letBody letBodyEnv                   // typ (Call(Var "f1", CstI 12)) (("f1", TypF(TypI, TypI)) :: []) -> TypI
      else failwith ("Letfun: return type in " + f)
      
    | Call(Var f, eArg) ->                          // Call(var "f1", CstI 12)
      match lookup env f with                       // What type is var "f1"? It is TypF(TypI, TypI)
      | TypF(xTyp, rTyp) ->                         // TypF(TypI, TypI)
        if typ eArg env = xTyp then rTyp            // typ CstI 12 (("f1", TypF(TypI, TypI)) :: []) -> TypI = TypI then return TypI
        else failwith "Call: wrong argument type"
      | _ -> failwith "Call: unknown function"
    | Call(_, eArg) -> failwith "Call: illegal function in call"


//example ex4
let ex4 = Let("b", Prim("=", CstI 1, CstI 2), If(Var "b", Var "b", CstB false));;

//the comments in typ follow the example ex4 to understand the code
let rec typ (e : tyexpr) (env : typ env) : typ =
    match e with
    | CstI i -> TypI
    | CstB b -> TypB
    | Var x  -> lookup env x                        // what type is "b"? it is TypB 
    | Prim(ope, e1, e2) ->                          // Prim("=", CstI 1, CstI 2)                         
      let t1 = typ e1 env                           // typ CstI 1 [] -> TypI                         
      let t2 = typ e2 env                           // typ CstI 2 [] -> TypI                        
      match (ope, t1, t2) with                      // ("=", TypI, TypI)
      | ("*", TypI, TypI) -> TypI
      | ("+", TypI, TypI) -> TypI
      | ("-", TypI, TypI) -> TypI
      | ("=", TypI, TypI) -> TypB                   // returns TypB
      | ("<", TypI, TypI) -> TypB
      | ("&", TypB, TypB) -> TypB
      | _   -> failwith "unknown op, or type error"
    | Let(x, eRhs, letBody) ->                      // Let("b", Prim("=", CstI 1, CstI 2), If(Var "b", Var "b", CstB false))
      let xTyp = typ eRhs env                       // typ Prim("=", CstI 1, CstI 2) [] -> TypB
      let letBodyEnv = (x, xTyp) :: env             // ("b", TypB) :: []
      typ letBody letBodyEnv                        // typ If(Var "b", Var "b", CstB false) ("b", TypB) :: [] -> TypB 
    | If(e1, e2, e3) ->                             // If(Var "b", Var "b", CstB false)
      match typ e1 env with                         // typ (Var "b") [] -> TypB
      | TypB -> let t2 = typ e2 env                 // typ (Var "b") [] -> TypB
                let t3 = typ e3 env                 // typ (CstB false) [] -> TypB
                if t2 = t3 then t2                  // if TypB = TypB then return TypB
                else failwith "If: branch types differ"
      | _    -> failwith "If: condition not boolean"
      
    | Letfun(f, x, xTyp, fBody, rTyp, letBody) ->   
      let fTyp = TypF(xTyp, rTyp)                   
      let fBodyEnv = (x, xTyp) :: (f, fTyp) :: env  
      let letBodyEnv = (f, fTyp) :: env             
      if typ fBody fBodyEnv = rTyp                  
      then typ letBody letBodyEnv                   
      else failwith ("Letfun: return type in " + f)
      
    | Call(Var f, eArg) ->                          
      match lookup env f with                      
      | TypF(xTyp, rTyp) ->                         
        if typ eArg env = xTyp then rTyp            
        else failwith "Call: wrong argument type"
      | _ -> failwith "Call: unknown function"
    | Call(_, eArg) -> failwith "Call: illegal function in call"