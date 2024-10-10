# 8.1

> compile "ex3";;
val it: Machine.instr list =
  // Numeric instruction: Symbolic instruction      |Stack                              | what it does
  [                                  
  24: LDARGS;                                       |0:                                 | start the program
  19: CALL (1, "L1");                               |1: CALL 1 5                        |
  25: STOP;                                         |4:                                 |

  Label "L1";                                       //function L1 starts    
  15: INCSP 1;                                      |5:                                 |
  13: GETBP;                                        |7:                                 |
  0: CSTI 1;                                        |8:                                 |
  1: ADD;                                           |10:                                | 
  0: CSTI 0;                                        |11:                                |
  12: STI;                                          |13:                                | i = 0
  15: INCSP -1;                                     |14:                                
  16: GOTO "L3";                                    |16: GOTO 43                        | while (i < n) 

  Label "L2";                                       //function L2 starts  
  13: GETBP;                                        |18:                                  |
  0: CSTI 1;                                        |19:                                  |
  1: ADD;                                           |21:                                  | 
  11: LDI;                                          |22:                                  |
  22: PRINTI;                                       |23:                                  | print i;
  15: INCSP -1;                                     |24:                                  |
  13: GETBP;                                        |26:                                  |
  0: CSTI 1;                                        |27:                                  |
  1: ADD;                                           |29:                                  |
  13: GETBP;                                        |30:                                  |
  0: CSTI 1;                                        |31:                                  |
  1: ADD;                                           |33:                                  | 
  11: LDI;                                          |34:                                  | 
  0: CSTI 1;                                        |35:                                  | 
  1: ADD;                                           |37:                                  | 
  12: STI;                                          |38:                                  | i = i + 1
  15: INCSP -1;                                     |39:                                  |
  15: INCSP 0;                                      |41:                                  |
  
  Label "L3";                                       //function L3 starts  
  13: GETBP;                                        |43:                                |
  0: CSTI 1;                                        |44:                                |
  1: ADD;                                           |46:                                |
  11: LDI;                                          |47:                                |
  13: GETBP;                                        |48:                                |
  0: CSTI 0;                                        |49:                                | 
  1: ADD;                                           |51:                                |
  11: LDI;                                          |52:                                | i < n
  7: LT;                                            |53:                                |
  18: IFNZRO "L2";                                  |54: IFNZRO 18                      | 
  15: INCSP -1;                                     |56:                                
  21: RET 0                                         |58: RET 0                          
  ]


> compile "ex5";;
val it: Machine.instr list =
  [
  24 : LDARGS;                                                                          |  Start the program      
  19: CALL (1, "L1");       | CALL 1 5                                                  | 
  25: STOP;                                                                             |
  
  Label "L1";               
  15: INCSP 1;                                                                          | 
  13: GETBP;                                                                            |
  0: CSTI 1;                                                                            |
  1: ADD;                                                                               |
  13: GETBP;                                                                            |
  0: CSTI 0;                                                                            |
  1: ADD;                                                                               |
  11: LDI;                                                                              | 
  12: STI;                                                                              | r = n
  15: INCSP -1;                                                                         |
  15: INCSP 1;                                                                          |
  13: GETBP;                                                                            |
  0: CSTI 0;                                                                            |
  1: ADD;                                                                               |
  11: LDI;                                                                              |
  13: GETBP;                                                                            |
  0: CSTI 2;                                                                            |
  1: ADD;                                                                               |
  19: CALL (2, "L2");       |  CALL 2 57                                                | square(n, &r); 
  15: INCSP -1;                                                                         |
  13: GETBP;                                                                            |
  0: CSTI 2;                                                                            |
  1: ADD;                                                                               |
  11: LDI;                                                                              |
  22: PRINTI;                                                                           | print r;
  15: INCSP -1;                                                                         |
  15: INCSP -1;                                                                         |
  13: GETBP;                                                                            |
  0: CSTI 1;                                                                            |
  1: ADD;                                                                               |
  11: LDI;                                                                              |
  22: PRINTI;                                                                           | print r;
  15: INCSP -1;                                                                         |
  15: INCSP -1;                                                                         |
  21: RET 0;                | RET 0 (main function ended)                               |
   
  Label "L2";
  13: GETBP;                                                                            |
  0: CSTI 1;                                                                            |
  1: ADD;                                                                               |
  11: LDI;                                                                              |
  13: GETBP;                                                                            |
  0: CSTI 0;                                                                            |
  1: ADD;                                                                               |
  11: LDI;                                                                              |
  13: GETBP;                                                                            |              
  0: CSTI 0;                                                                            |
  1: ADD;                                                                               |
  11: LDI;                                                                              |
  3: MUL;                                                                               | i * i;
  12: STI;                                                                              | *rp = i * i;
  15: INCSP -1;                                                                         |
  15: INCSP 0;                                                                          |
  21: RET 1                 | RET 1                                                     | return from square
  ]