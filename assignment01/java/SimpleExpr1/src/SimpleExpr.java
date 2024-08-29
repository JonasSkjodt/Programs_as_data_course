import java.util.Map;
import java.util.HashMap;

abstract class Expr {
  abstract public int eval(Map<String, Integer> env);
  abstract public String toString();
  abstract public Expr simplify();
}

class CstI extends Expr {
  protected final int i;
  
  public CstI(int i) { 
    this.i = i; 
  }
  
  public int eval(Map<String, Integer> env) { 
    return i; 
  }
  public String toString() { 
    return Integer.toString(i); 
  }
  
  public Expr simplify() {
    
    return this;
  
  }

  public int compareTo(CstI e2) {
    if (i == e2.i) {
      return 1;
    } 
    else {
     return 0;
    }
  }

}

class Var extends Expr {
  protected final String name;
  
  public Var(String name) {
    this.name = name;}
  
  public int eval(Map<String, Integer> env) {
    return env.get(name);
  }
  
  public String toString() {
    return name;
  }
  
  public Expr simplify() {
    return this;
  }
}

class Add extends Expr {
  protected final Expr e1, e2;
  
  public Add(Expr e1, Expr e2) {
    this.e1 = e1; this.e2 = e2;
  }
  
  public int eval(Map<String, Integer> env) {
    return e1.eval(env) + e2.eval(env);
  }
  
  public String toString() {
    return "(" + e1.toString() + " + " + e2.toString() + ")";
  }
  
  public Expr simplify() {
      Expr se1 = e1.simplify();
      Expr se2 = e2.simplify();
      if (se1 instanceof CstI && ((CstI) se1).i == 0) return se2;
      if (se2 instanceof CstI && ((CstI) se2).i == 0) return se1;
      return new Add(se1, se2);
  }
}

class Sub extends Expr {
  protected final Expr e1, e2;
  
  public Sub(Expr e1, Expr e2) {
    this.e1 = e1; this.e2 = e2;
  }
  
  public int eval(Map<String, Integer> env) {
    return e1.eval(env) - e2.eval(env);
  }
  
  public String toString() {
    return "(" + e1.toString() + " - " + e2.toString() + ")";
  }
  public Expr simplify() {
      Expr se1 = e1.simplify();
      Expr se2 = e2.simplify();

      if (se2 instanceof CstI && ((CstI) se2).i == 0) return se1;
      if (se1 instanceof CstI && ((CstI) se1).i == 0) return se2;
      if (se1 instanceof CstI && se2 instanceof CstI && (((CstI) se1).i - ((CstI) se2).i == 0)) return new CstI(0);
      
      return new Sub(se1, se2);
  }
}

class Mul extends Expr {
  protected final Expr e1, e2;
  
  public Mul(Expr e1, Expr e2) { 
    this.e1 = e1; this.e2 = e2; 
  }
  
  public int eval(Map<String, Integer> env) { 
    return e1.eval(env) * e2.eval(env); 
  }
  
  public String toString() { 
    return "(" + e1.toString() + " * " + e2.toString() + ")"; 
  }

  public Expr simplify() {
      Expr se1 = e1.simplify();
      Expr se2 = e2.simplify();
      if (se1 instanceof CstI && ((CstI) se1).i == 1) return se2;
      if (se2 instanceof CstI && ((CstI) se2).i == 1) return se1;
      if (se1 instanceof CstI && ((CstI) se1).i == 0) return new CstI(0);
      if (se2 instanceof CstI && ((CstI) se2).i == 0) return new CstI(0);
      return new Mul(se1, se2);
  }
}

public class SimpleExpr {
  public static void main(String[] args) {
      Expr e1 = new Add(new CstI(3), new Var("a"));
      Expr e2 = new Mul(new Var("b"), new CstI(4));
      Expr e3 = new Sub(new Var("c"), new CstI(2));

      Map<String, Integer> env0 = new HashMap<String, Integer>();
      env0.put("a", 3);
      env0.put("c", 78);
      env0.put("baf", 666);
      env0.put("b", 111);
      env0.put("z", 12);

      System.out.println("Old ones");
      System.out.println(e1.toString());
      System.out.println(e2.toString());
      System.out.println(e3.toString());

      // 1.4 (ii)
      Expr e4 = new Add(new CstI(17), new Var("z"));
      Expr e5 = new Mul(new Var("z"), new CstI(1));
      Expr e6 = new Sub(new Var("a"), new Var("z"));

      System.out.println("\n1.4 (ii)");
      System.out.println(e4.toString());
      System.out.println(e5.toString());
      System.out.println(e6.toString());

      System.out.println("\nOld ones");
      System.out.println(e1.eval(env0));
      System.out.println(e2.eval(env0));
      System.out.println(e3.eval(env0));

      System.out.println("\n1.4 (iii)");
      System.out.println(e4.eval(env0));
      System.out.println(e5.eval(env0));
      System.out.println(e6.eval(env0));

      // 1.4 (iv)
      System.out.println("\n1.4 (v)");
      Expr e7 = new Add(new CstI(0), new Var("z"));
      Expr e8 = new Mul(new Var("b"), new CstI(1));
      Expr e9 = new Sub(new CstI(5), new CstI(5));

      System.out.println(e7.simplify().toString());
      System.out.println(e8.simplify().toString());
      System.out.println(e9.simplify().toString());
  }
}
