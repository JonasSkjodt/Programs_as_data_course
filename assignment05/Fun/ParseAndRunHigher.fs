(* File Fun/ParseAndRunHigher.fs *)

module ParseAndRunHigher

open HigherFun;;

let fromString = Parse.fromString;;

let eval = HigherFun.eval;;

let run e = eval e [];;

(* Examples of higher-order programs, in concrete syntax *)

let ex5 = 
    Parse.fromString 
     @"let tw g = let app x = g (g x) in app end 
       in let mul3 x = 3 * x 
       in let quad = tw mul3 
       in quad 7 end end end";;

let ex6 = 
    Parse.fromString 
     @"let tw g = let app x = g (g x) in app end 
       in let mul3 x = 3 * x 
       in let quad = tw mul3 
       in quad end end end";;

let ex7 = 
    Parse.fromString 
     @"let rep n = 
           let rep1 g = 
               let rep2 x = if n=0 then x else rep (n-1) g (g x) 
               in rep2 end 
           in rep1 end 
       in let mul3 x = 3 * x 
       in let tw = rep 2 
       in let quad = tw mul3 
       in quad 7 end end end end";;

let ex8 = 
    Parse.fromString 
     @"let rep n =
           let rep1 g = 
               let rep2 x = if n=0 then x else rep (n-1) g (g x) 
               in rep2 end 
           in rep1 end 
       in let mul3 x = 3 * x 
       in let twototen = rep 10 mul3 
       in twototen 7 end end end";;

let ex9 = 
    Parse.fromString 
     @"let rep n = 
           let rep1 g = 
               let rep2 x = if n=0 then x else rep (n-1) g (g x) 
               in rep2 end 
           in rep1 end 
       in let mul3 x = 3 * x 
       in let twototen = (rep 10) mul3 
       in twototen 7 end end end";;

(*6.1*)
// val it: HigherFun.value = Int 7
let ex10 = 
    Parse.fromString 
     @"let add x = let f y = x+y in f end 
       in add 2 5 end";;

// ex11 should be 7 since addtwo is a higher order function
// val it: HigherFun.value = Int 7
let ex11 =
    Parse.fromString
     @"let add x = let f y = x+y in f end
       in let addtwo = add 2
         in addtwo 5 end
       end";;

// yes it is expected, although let x = 77 introduces x with the value of 77
// it does not affect the function addtwo due to not being in the same enclosure as the higher order function
// so the result is 7 from addtwo 5
let ex12 = 
    Parse.fromString 
     @"let add x = let f y = x+y in f end 
       in let addtwo = add 2
        in let x = 77 in addtwo 5 end
        end
       end";;

// in this one function f doesnt have any value to add to x and therefore
// the function will be shown instead of a value
let ex13 = 
    Parse.fromString 
     @"let add x = let f y = x+y in f end 
       in add 2 end";;

//6.2
// Fun("x", Prim("*", CstI 2, Var "x"))
let ex14 = 
    Parse.fromString 
     @"fun x -> 2*x";;

//let y = 22 in fun z -> z+y end
let ex15 =
    Parse.fromString
     @"let y = 22 in fun z -> z+y end";;

//6.3
// let add x = fun y -> x+y
// in add 2 5 end
let ex16 =
    Parse.fromString
     @"let add x = fun y -> x+y
        in add 2 5 end";;
// let add = fun x -> fun y -> x+y
// in add 2 5 end
let ex17 =
    Parse.fromString
     @"let add = fun x -> fun y -> x+y 
        in add 2 5 end";;

//6.5 testing
let ex18 =
    Parse.fromString
     @"let f x = 1 in f 7 + f false end";;