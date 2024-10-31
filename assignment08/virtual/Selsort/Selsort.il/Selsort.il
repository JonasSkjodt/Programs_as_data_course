// https://en.wikipedia.org/wiki/List_of_CIL_instructions

	.method public hidebysig static 
		void SelectionSort (
			int32[] arr								//parameter
		) cil managed 
	{
		// Method begins at RVA 0x20cc
		// Header size: 12
		// Code size: 78 (0x4e)
		.maxstack 4
		.locals init (
			[0] int32, // i
			[1] int32, // least
			[2] int32, // tmp
			[3] int32, // j
			[4] bool, // variable given by the if
			[5] bool, // variable given by the comparison in the inner for loop
			[6] bool //
		)

		IL_0000: nop								// no operation (used for timing purposes, to force memory alignment)
		IL_0001: ldc.i4.0							// push constant 0 onto the stack
		IL_0002: stloc.0							// stores in local variable 0
		IL_0003: br.s IL_0041						// unconditional jump to instruction IL_0041
		// loop start (head: IL_0041)				 
			IL_0005: nop							// no operation (used for timing purposes, to force memory alignment)
			IL_0006: ldloc.0						// load local variable at stack [0]  / load the value of i onto the stack
			IL_0007: stloc.1						// store the value from the top of the stack into var [1] / stores the value of i in a new variable "least"
			IL_0008: ldloc.0						// load local variable at stack [0] / value of i onto the stack
			IL_0009: ldc.i4.1						// push constant 1 onto the stack
			IL_000a: add							// (arithmetic) use add, pops the two top values from the stack and adds them, then pushes the result back onto the stack / adds the value of i and int 1 together
			IL_000b: stloc.3						// Stores the value from the top of the stack into local variable 3 / then stores the added value to j
			IL_000c: br.s IL_0022					// Unconditional jump to instruction IL_0022
			// loop start (head: IL_0022)			
				IL_000e: ldarg.0					// load the first local argument (arr[j]) onto the stack, at placement 0 of the arguments
				IL_000f: ldloc.3					// load local constant variable 3 / load value of j onto the stack
				IL_0010: ldelem.i4					// load local array element (loads the element of index j of the array (arr[j]) onto the stack)
				IL_0011: ldarg.0					// load the first local argument (arr[least]) onto the stack, at placement 0 of the arguments
				IL_0012: ldloc.1					// load local variable 1 / load value of least onto the stack
				IL_0013: ldelem.i4					// load local array element / gets the value of arr[least] which is of type int
				IL_0014: clt						// the If statement, which takes the two loaded array elements and compare them. Push 1 (of type int32) if value1 lower than value2, else push 0.
				IL_0016: stloc.s 4					// stores the result of the if-comparison in local variable 4
				IL_0018: ldloc.s 4					// loads the anonymous varible given by the if-statement onto the stack
				IL_001a: brfalse.s IL_001e			// if false, go to instruction IL_001e

				IL_001c: ldloc.3					// load local constant variable 3 / load value of j onto the stack
				IL_001d: stloc.1					// stores value of j in least

				IL_001e: ldloc.3					// value of j
				IL_001f: ldc.i4.1					// constant 1 onto the stack
				IL_0020: add						// add
				IL_0021: stloc.3					// stores the result

				IL_0022: ldloc.3					// value of j
				IL_0023: ldarg.0					// get arr
				IL_0024: ldlen						// Push the length (of type native unsigned int) of array on the stack. / arr.length
				IL_0025: conv.i4					// Convert the length to int32, pushing int32 on stack.
				IL_0026: clt						// The for loop comparison, which checks j < arr.length.
				IL_0028: stloc.s 5					// stores the result in variable at [5]
				IL_002a: ldloc.s 5					// load the value of var [5] onto the stack
				IL_002c: brtrue.s IL_000e			// if true, then jump to instruction IL_000e
			// end loop

			IL_002e: ldarg.0						// load the first local argument (arr[i]) onto the stack, at placement 0 of the arguments
			IL_002f: ldloc.0						// gets the value of i
			IL_0030: ldelem.i4						// gets the value of arr[i]
			IL_0031: stloc.2						// stores the value of tmp
			IL_0032: ldarg.0						// load the first local argument (arr[i]) onto the stack, at placement 0 of the arguments
			IL_0033: ldloc.0						// gets the value of i
			IL_0034: ldarg.0						// load the first local argument (arr[least]) onto the stack, at placement 0 of the arguments
			IL_0035: ldloc.1						// gets the value of least
			IL_0036: ldelem.i4						// gets the value of arr[least]
			IL_0037: stelem.i4						// stores the value from the stack into the array[least]
			IL_0038: ldarg.0						// load the first local argument (arr[least]) onto the stack, at placement 0 of the arguments
			IL_0039: ldloc.1						// gets the value of least
			IL_003a: ldloc.2						// gets the value of tmp
			IL_003b: stelem.i4						// stores the value from the stack into the array[least]
			IL_003c: nop							// no operation (used for timing purposes, to force memory alignment)
			IL_003d: ldloc.0						// gets the value of i
			IL_003e: ldc.i4.1						// push least onto the stack 
			IL_003f: add							// addition
			IL_0040: stloc.0						// stores the result onto var i

			IL_0041: ldloc.0						// load var i
			IL_0042: ldarg.0						// load the first local argument (arr[i]) onto the stack, at placement 0 of the arguments
			IL_0043: ldlen							// Push the length (of type native unsigned int) of array on the stack. / arr.length
			IL_0044: conv.i4						// convert pushed length to int32
			IL_0045: clt							// The for loop comparison, which checks i < arr.length.
			IL_0047: stloc.s 6						// stores the result of the comparison
			IL_0049: ldloc.s 6						// loads value of the comparison
			IL_004b: brtrue.s IL_0005				// if true, jump to IL_0005
		// end loop

		IL_004d: ret								// return
	} // end of method Selsort::SelectionSort