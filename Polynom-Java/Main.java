class Main {
    public static void main(String[] args) {
        Polynom p1 = new Polynom(new Integer[]{-1, 2, 3, 0, 8, 9});
        System.out.println(p1.stringify());
        Polynom p2 = new Polynom(new Integer[]{2, 3, 6, -5, -7});
        System.out.println(p2.stringify());
        System.out.println("Addiert:");
        System.out.println(Polynom.add(p1, p2).stringify());
        Polynom p3 = new Polynom(new Integer[]{-1, 2, -3, 0, 8, 9});
        System.out.println(p3.stringify());
        Polynom p4 = new Polynom(new Integer[]{2, 3, -6, 5, -7});
        System.out.println(p4.stringify());
        System.out.println("Multipliziert:");
        System.out.println(Polynom.multiply(p3, p4).stringify());
        System.out.println("Vergleich");
        Polynom p5 = new Polynom(new Integer[]{2, 3});
        Polynom p6 = new Polynom(new Integer[]{2, 3});
        System.out.println(Polynom.compare(p5, p6));
        Polynom p7 = new Polynom(new Integer[]{2, 3, 4});
        Polynom p8 = new Polynom(new Integer[]{2, 3});
        System.out.println(Polynom.compare(p7, p8));
        Polynom p9 = new Polynom(new Integer[]{2, 3, 4});
        Polynom p10 = new Polynom(new Integer[]{2, 3, 6});
        System.out.println(Polynom.compare(p9, p10));
        Polynom p11 = new Polynom(new Integer[]{2, 3, 0, -6});
        System.out.println(p11.stringify());
        System.out.println("3 für x eingesetzt:");
        System.out.println(p11.calculateForX(3));
    }
}