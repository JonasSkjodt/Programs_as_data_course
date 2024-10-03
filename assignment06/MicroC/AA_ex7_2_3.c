/*7.2 (iii) 
Write a micro-C program containing a function void histogram(int
n, int ns[], int max, int freq[]) which fills array freq the
frequencies of the numbers in array ns. More precisely, when the function returns, element freq[c] must equal the number of times that value c appears
among the first n elements of arr, for 0<=c<=max. You can assume that all
numbers in ns are between 0 and max, inclusive.


For example, if your main function creates an array arr holding the seven
numbers 1 2 1 1 1 2 0 and calls histogram(7, arr, 3, freq), then
afterwards freq[0] is 1, freq[1] is 4, freq[2] is 2, and freq[3] is 0.


Of course, freq must be an array with at least four elements. What happens if it is not?
The array freq should be declared and allocated in the main function, and passed to histogram function.
It does not work correctly (in micro-C or C) to stack-allocate the array in histogram and somehow return it to the
main function. Your main function should print the contents of array freq after the call.
*/

void main() {
    int n;
    n = 7;
    
    int max;
    max = 3;

    int ns[7];
    ns[0] = 1;
    ns[1] = 2;
    ns[2] = 1;
    ns[3] = 1;
    ns[4] = 1;
    ns[5] = 2;
    ns[6] = 0;

    int freqSize;
    freqSize = 4;

    int freq[4];

    // Initialize freq array to 0
    /*
    without this code we get
    > run (fromFile "AA_ex7_2_3.c") [];;
        -998 -995 -997 -999 val it: Interp.store =
        map
            [(0, 7); (1, 3); (2, 1); (3, 2); (4, 1); (5, 1); (6, 1); (7, 2); (8, 0);
            ...]
    
    with the code, when we initialize it to 0 we get
    
      run (fromFile "AA_ex7_2_3.c") [];;
        1 4 2 0 val it: Interp.store =
        map
            [(0, 7); (1, 3); (2, 1); (3, 2); (4, 1); (5, 1); (6, 1); (7, 2); (8, 0);
            ...]

        which is the correct answer, but why?
    */
    int i;
    i = 0;
    while (i < freqSize) {
        freq[i] = 0;
        i = i + 1;
    }

    histogram(n, ns, max, freq);
    
    i = 0;
    while (i < freqSize) {
        print freq[i];
        i = i + 1;
    }
}


void histogram(int n, int ns[], int max, int freq[]) {
    int i;
    i = 0;
    
    // while(i < n) {
    //     freq[ns[i]] = freq[ns[i]] + 1;
    //     i = i + 1;
    // }
    while (i < n) {
        if (ns[i] <= max) {
            freq[ns[i]] = freq[ns[i]] + 1;
        }
        i = i + 1;
    }
}