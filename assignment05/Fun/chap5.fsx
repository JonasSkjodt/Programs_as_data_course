
(* Higher-order functions and anonymous functions in F# *)
let rec map f xs = 
    match xs with 
      | []    -> []
      | x::xr -> f x :: map f xr


let mul2 x = 2.0 * x
map mul2 [4.0; 5.0; 89.0]

map (fun x -> 2.0 * x) [4.0; 5.0; 89.0]

map (fun x -> x > 10.0) [4.0; 5.0; 89.0]

(* Uniform iteration over a list *)
let rec sum xs = 
    match xs with 
      | []    -> 0
      | x::xr -> x + sum xr

let rec prod xs = 
    match xs with 
      | []    -> 1
      | x::xr -> x * prod xr

let rec foldr f xs e = 
    match xs with
      | []    -> e
      | x::xr -> f x (foldr f xr e)


(* Higher-order micro-ML/micro-F# *)
let twice g x = g(g x)

let add x = let f y = x+y in f
let addtwo = add 2 
let x = 77
addtwo 5


(* F# mutable references *)
let r = ref 177
r.Value
(r.Value <- r.Value+1; r.Value)
r.Value

let nextlab = ref -1
let newLabel () = (nextlab.Value <- 1 + nextlab.Value; 
                   "L" + string (nextlab.Value))
newLabel()

(*5.1 merge*)
let rec merge (xs, ys) = 
    match (xs, ys) with
      | ([], ys) -> ys // if xs is empty, return ys
      | (xs, []) -> xs // if ys is empty, return xs
      | (x::xr, y::yr) -> if x < y then x :: merge (xr, ys) // if x < y, take list x and merge it with the rest of xs and ys
                          else y :: merge (xs, yr) // if y < x, take list y and merge it with the rest of xs and ys

//merge ([3;5;12], [2;3;4;7]) should give [2;3;3;4;5;7;12].
let mergeTest = merge ([3;5;12], [2;3;4;7])