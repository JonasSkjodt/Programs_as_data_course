/*7.2 (ii)
Write a micro-C program containing a function void squares(int n,
int arr[]) that, given n and an array arr of length n or more fills
arr[i] with i*i for i = 0,...,n − 1.
Your main function should allocate an array holding up to 20 integers, call
function squares to fill the array with n square numbers (where n ≤ 20 is
given as a parameter to the main function), then call function arrsum above
to compute the sum of the n squares, and print the sum
*/

void main() {
    int n;
    n = 20;
    int arr[20];

    squares(n, arr);

    int sump;
    sump = 0;

    arrsum(n, arr, &sump);

    print sump;
}


void squares(int n, int arr[]) {
    int i;
    i = 0;

    while(i < n) {
        arr[i] = i * i;
        i = i + 1;
    }
}

void arrsum(int n, int arr[], int *sump) {
    int i;
    i=0;

    while (i < n) {
        *sump = *sump + arr[i];
        i = i + 1;
    }
}
