/*7.3 (ii) */
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

    //make sure to initialize the array so it doesnt contain garbage values
    for (i = 0; i < n; i = i + 1) {
        arr[i] = i * i;
    }

    //print the array
    for (i = 0; i < n; i = i + 1) {
        print arr[i];
    }
}

void arrsum(int n, int arr[], int *sump) {
    int i;

    for (i = 0; i < n; i = i + 1) {
        *sump = *sump + arr[i];
    }
}