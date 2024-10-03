/*7.2 (i)*/

void main() {
    // int n;
    // n = 4;
    // int arr[n]; This cant be done in micro c without doing stuff with malloc
    
    int arr[4];

    arr[0] = 7;
    arr[1] = 13;
    arr[2] = 9;
    arr[3] = 8;
    
    int sump;
    sump = 0; // If sump is not initialized, it might start with a garbage value. So make sure to initialize it.
    arrsum(4, arr, &sump); //remember to give the address of the variable, otherwise it will not fully work.
    //The reason for this is that the function is not returning anything, so the only way to get the value is to pass the address

    print sump;
}

void arrsum(int n, int arr[], int *sump) {
    int i;
    i=0;

    while (i < n) {
        *sump = *sump + arr[i];
        i = i + 1;
    }
}
