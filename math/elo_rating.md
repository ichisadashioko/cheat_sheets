# Elo Rating Formula

## Code 

```java
public int[] calculateEloPoints(int white, int black, String winner) {
    int[] ret = new int[2];
    double d_white = (double) white;
    double d_black = (double) black;

    double e_white, e_black; // expected chance of winning for white and black (range = [0, 1] or 0% to 100%)
    double q_white, q_black;
    double r_white, r_black; // results of white and black. win = 1, lose = 0
    double k_white, k_black; // k factors of white and black

    q_white = Math.pow(10, (d_white / 400.0));
    q_black = Math.pow(10, (d_black / 400.0));

    e_white = q_white / (q_white + q_black);
    e_black = q_black / (q_white + q_black);

    k_white = kFactor(d_white);
    k_black = kFactor(d_black);

    if (winner.matches("white")) {
        r_white = 1;
        r_black = 0;
    } else if (winner.matches("black")) {
        r_white = 0;
        r_black = 1;
    } else {
        return null;
    }

    ret[0] = (int) (k_white * (r_white - e_white));
    ret[1] = (int) (k_black * (r_black - e_black));
    return ret;
}

public double kFactor(double point) {
    double k;
    if (point < 1500) {
        k = 32;
    } else if (point > 2000) {
        k = 16;
    } else {
        k = 24;
    }
    return k;
}
```