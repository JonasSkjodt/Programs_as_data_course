void main() {
    int month;
    month = 2;
    int days;
    int y;
    y = 7;
    
    switch (month) {
        case 1:
            { days = 31; }
        case 2:
            { days = 28; if (y%4==0) days = 29; }
        case 3:
            { days = 31; }
    }

    print days;
}