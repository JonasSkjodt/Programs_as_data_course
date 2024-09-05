type sinstr =
  | SCstI of int                        (* push integer           *)
  | SVar of int                         (* push variable from env *)
  | SAdd                                (* pop args, push sum     *)
  | SSub                                (* pop args, push diff.   *)
  | SMul                                (* pop args, push product *)
  | SPop                                (* pop value/unbind var   *)
  | SSwap;;                             (* exchange top and next  *)

(* Ex 2.4 - assemble to integers *)
(* SCST = 0, SVAR = 1, SADD = 2, SSUB = 3, SMUL = 4, SPOP = 5, SSWAP = 6; *)
let rec sinistrToInt (si : sinstr) : int list =
    match si with
    | SCstI i -> [0; i]
    | SVar i -> [1; i]
    | SAdd -> [2]
    | SSub -> [3]
    | SMul -> [4]
    | SPop -> [5]
    | SSwap -> [6]
    | _ -> failwith "not a type of sinstr"

//tests for sinistrToInt function
let sin1 = SCstI 10 
let sin1v = sinistrToInt sin1

let sin2 = SVar 4
let sin2v = sinistrToInt sin2

let sin3 = SPop
let sin3v = sinistrToInt sin3

// assemble : sinstr list -> int list
// that folds over a list of sinstr and use sinstrToInt
// to accumulate the list of integers.
let rec assemble (instrs : sinstr list) : int list  =
    match instrs with
    | [] -> []
    | head :: tail -> sinistrToInt head @ assemble tail
    | _ -> failwith "Assemble failed"

//tests for assemble function
let ass1 = [SCstI 10] 
let ass1v = assemble ass1

let ass2 = [SVar 4; SCstI 10]
let ass2v = assemble ass2

let ass3 = [SVar 4; SCstI 10; SSwap; SPop]
let ass3v = assemble ass3

(* Output the integers in list inss to the text file called fname: *)

let intsToFile (inss : int list) (fname : string) = 
    let text = String.concat " " (List.map string inss)
    System.IO.File.WriteAllText(fname, text);;

//print answer to is1.txt
let sintofile = [SCstI 17; SVar 0; SVar 1; SAdd; SSwap; SPop]
let sintofilev = assemble sintofile
intsToFile sintofilev "is1.txt"

