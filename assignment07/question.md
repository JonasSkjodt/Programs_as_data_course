Hvordan ser stacken ud efter man har kaldt til et label?
 Label "L1";                                       |5:  
 

bp ændrer sig når en parameter er indsat, hvad er den tekniske forklaring på dette?
 
på side 143 i bogen, hvorfor vælger old bp lige "n" til at være dens reference fra sidste fac(_,_) udregning? 

https://stackoverflow.com/questions/1395591/what-exactly-is-the-base-pointer-and-stack-pointer-to-what-do-they-point
ESP (Stack Pointer) is the current stack pointer, which will change any time a word or address is pushed or popped on/off the stack. EBP (Base Pointer) is a more convenient way for the compiler to keep track of a function's parameters and local variables than using the ESP directly.


Hvad er symboliserer index tal 2 i tracen? (7.4.1) Vi tror 4 er argumentet (s).