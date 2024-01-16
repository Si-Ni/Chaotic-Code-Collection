public class Polynom {
    private Integer[] values;
    private int n;

    public Integer[] getValues() {
        return values;
    }

    public void setValues(Integer[] values) {
        this.values = values;
    }

    public int getN() {
        return n;
    }

    public void setN(int n) {
        this.n = n;
    }

    public Polynom(Integer[] values) {
        this.values = values;
        this.n = values.length - 1;
    }

    public int calculateForX(int x) {
        int result = 0;
        for (int i = 0; i <= this.n; i++) {
            result += this.values[i] * Math.pow(x, i);
        }
        return result;
    }

    public String stringify() {
        String result = "";
        if (this.values[0] != 0) {
            result = result + values[0] + " ";
        }
        for (int i = 1; i <= this.n; i++) {
            int currentValue = this.values[i];
            if (currentValue != 0) {
                if (result != "") {
                    if (currentValue < 0) {
                        result += "- ";
                        currentValue = Math.abs(currentValue);
                    } else {
                        result += "+ ";
                    }
                }
                result = result + currentValue + "x^" + i + " ";
            }
        }
        return result;
    }

    public static Polynom add(Polynom p1, Polynom p2) {
        Integer[] longArr;
        Integer[] shortArr;

        if (p1.getN() > p2.getN()) {
            longArr = p1.getValues();
            shortArr = p2.getValues();
        } else {
            longArr = p2.getValues();
            shortArr = p1.getValues();
        }

        Integer[] addedPolynom = new Integer[longArr.length];
        for (int i = 0; i < longArr.length; i++) {
            if (i < shortArr.length) {
                addedPolynom[i] = longArr[i] + shortArr[i];
            } else {
                addedPolynom[i] = longArr[i];
            }   
        }

        Polynom result = new Polynom(addedPolynom);
        return result;
    }

    public static Polynom multiply(Polynom p1, Polynom p2) {
        int arrLength = p1.getN() + p2.getN();
        Integer[] result = new Integer[arrLength+1];
        for (int i = 0; i <= arrLength; i++) {
            result[i] = 0;
        }

        Integer[] longArr;
        Integer[] shortArr;
        if (p1.getN() > p2.getN()) {
            longArr = p1.getValues();
            shortArr = p2.getValues();
        } else {
            longArr = p2.getValues();
            shortArr = p1.getValues();
        }

        for (int i = 0; i < shortArr.length; i++) {
            for (int j = 0; j < longArr.length; j++) {
                result[i+j] = result[i+j] + shortArr[i] * longArr[j];
            }
        }

        return new Polynom(result);
    }

    public static String compare(Polynom p1, Polynom p2) {
        if (p1.getN() > p2.getN()) {
            return String.format("P1( %s) > P2( %s)", p1.stringify(), p2.stringify());
        } else if (p2.getN() > p1.getN()) {
            return String.format("P1( %s) < P2( %s)", p1.stringify(), p2.stringify());
        } 
        Integer[] v1 = p1.getValues();
        Integer[] v2 = p2.getValues();
        for (int i = 0; i <= p1.getN(); i++) {
            if (v1[i] > v2[i]) {
                return String.format("P1( %s) > P2( %s)", p1.stringify(), p2.stringify());
            } else if (v1[i] < v2[i]) {
                return String.format("P1( %s) < P2( %s)", p1.stringify(), p2.stringify());
            }
        }
        return  String.format("P1( %s) = P2( %s)", p1.stringify(), p2.stringify());
    }
}
