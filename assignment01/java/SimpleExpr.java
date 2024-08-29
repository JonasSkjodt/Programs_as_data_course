package java;
// File Intro/SimpleExpr.java
// Java representation of expressions as in lecture 1
// sestoft@itu.dk * 2010-08-29

import java.util.Map;
import java.util.HashMap;

abstract class Expr { 
  abstract public int eval(Map<String,Integer> env);
}

class CstI extends Expr { 
  protected final int i;

  public CstI(int i) { 
    this.i = i; 
  }

  public int eval(Map<String,Integer> env) {
    return i;
  } 

  @Override
  public String toString() {
      return "" + i;
  }

}

class Var extends Expr { 
  protected final String x;

  public Var(String x) { 
    this.x = x; 
  }

  public int eval(Map<String,Integer> env) {
    return env.get(x);
  }

  @Override
  public String toString() {
      return "" + x;
  }
}

class Binop extends Expr { 
  protected final String oper;
  protected final Expr e1, e2;

  public Binop(String oper, Expr e1, Expr e2) { 
    this.oper = oper; this.e1 = e1; this.e2 = e2;
  }

  public int eval(Map<String,Integer> env) {
    if (oper.equals("+"))
      return e1.eval(env) + e2.eval(env);
    else if (oper.equals("*"))
      return e1.eval(env) * e2.eval(env);
    else if (oper.equals("-"))
      return e1.eval(env) - e2.eval(env);
    else
      throw new RuntimeException("unknown primitive");
  }

  @Override
  public String toString() {
    if (oper.equals("+"))
      return e1.toString() + "+" + e2.toString();
    else if (oper.equals("*"))
      return e1.toString() + "*" + e2.toString();
    else 
      return e1.toString() + "-" + e2.toString();
  }
}

class Add extends Expr { 
  protected final Expr e1, e2;

  public Add(Expr e1, Expr e2) { 
    this.e1 = e1; this.e2 = e2;
  }

  public int eval(Map<String,Integer> env) {
    return e1.eval(env) + e2.eval(env);
  }

  @Override
  public String toString() {
    return e1.toString() + "+" + e2.toString();
  }
}

class Mul extends Expr {
  protected final Expr e1, e2;

  public Mul(Expr e1, Expr e2) {
    this.e1 = e1; this.e2 = e2;
  }

  public int eval(Map<String,Integer> env) {
    return e1.eval(env) * e2.eval(env);
  }

  @Override
  public String toString() {
    return e1.toString() + "*" + e2.toString();
  }
}

class Sub extends Expr {
  protected final Expr e1, e2;

  public Sub(Expr e1, Expr e2) {
    this.e1 = e1; this.e2 = e2;
  }

  public int eval(Map<String,Integer> env) {
    return e1.eval(env) - e2.eval(env);
  }

  @Override
  public String toString() {
    return e1.toString() + "-" + e2.toString();
  }
}


public class SimpleExpr {
  public static void main(String[] args) {
    Expr e = new Add(new CstI(17), new Var("z"));
    
    // Expr e1 = new CstI(17);
    // Expr e2 = new Binop("+", new CstI(3), new Var("a"));
    // Expr e3 = new Binop("+", new Binop("*", new Var("b"), new CstI(9)), 
		//             new Var("a"));
    Map<String,Integer> env0 = new HashMap<String,Integer>();
    env0.put("a", 3);
    env0.put("c", 78);
    env0.put("baf", 666);
    env0.put("b", 111);
    env0.put("z", 12);
    // System.out.println(e1.eval(env0));
    // System.out.println(e2.eval(env0));
    // System.out.println(e3.eval(env0));

    System.out.println(e.toString());
  }
}

