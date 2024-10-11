// micro-C example 9 -- return a result via a pointer argument

void main(int i) {
  int r;
  fac(i, &r); // (3, 0)
  print r;
}

void fac(int n, int *res) {
  // print &n;			// Show n's address
  if (n == 0)
    *res = 1;
  else {
    int tmp;
    fac(n-1, &tmp); //fac(3, _):      fac(2, _):       fac(1, _):         fac(0, _) -> 1
    *res = tmp * n; //2 * 3: -> 6      1 * 2 -> 2         1 * 1 -> 1             
  }
}
