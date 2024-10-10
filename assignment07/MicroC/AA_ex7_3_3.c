/*7.2 (iii) */

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

    int i;

    for (i = 0; i < freqSize; i = i + 1) {
        freq[i] = 0;
    }

    histogram(n, ns, max, freq);
    
    for (i = 0; i < freqSize; i = i + 1) {
        print freq[i];
    }
}


void histogram(int n, int ns[], int max, int freq[]) {
    int i;
    
    for (i = 0; i < n; i = i + 1) {
        if (ns[i] <= max) {
            freq[ns[i]] = freq[ns[i]] + 1;
        }
    }
}