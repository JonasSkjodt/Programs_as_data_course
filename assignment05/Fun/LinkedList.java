// Generic LinkedList in Java 5.0
// sestoft@itu.dk 2004-03-02

// Compile with
//   javac LinkedList.java

class TestLinkedList {
  public static void main(String[] args) {
    LinkedList<Person> names = new LinkedList<Person>();
    names.add(new Person("Kristen"));
    names.add(new Person("Bjarne"));
    //    names.add(new Integer(1998));                 // Wrong, compile-time error
    names.add(new Person("Anders"));
    Person p = names.get(2);                      // No cast needed
    System.out.println(p.name);
    System.out.println(f(4));
    System.out.println(f("hfdshs"));
    System.out.println(f(f(7)));
    System.out.println(names.map(new Fun<Person, Integer>() {
      public Integer invoke(Person p) {
        return p.name.length();
      }
    }));
  }

  // Corresponds to SML function of type 'T -> 'T list
  public static <T> LinkedList<T> f(T x) {
    LinkedList<T> res = new LinkedList<T>();
    res.add(x);
    return res;
  }
}

class Person {
  public final String name;

  public Person(String name) { 
    this.name = name;
  }
}

class LinkedList<T> {
  private Node<T> first, last;  // Invariant: first==null iff last==null

  private static class Node<T> {
    public Node<T> prev, next;
    public T item;

    public Node(T item) {
      this.item = item; 
    }

    public Node(T item, Node<T> prev, Node<T> next) {
      this.item = item; this.prev = prev; this.next = next; 
    }
  }

  public LinkedList() {
    first = last = null;
  }

  public T get(int index) {
    return getNode(index).item;
  }

  private Node<T> getNode(int n) {
    Node<T> node = first;
    for (int i=0; i<n; i++)
      node = node.next;
    return node;
  }

  public boolean add(T item) { 
    if (last == null) // and thus first = null
      first = last = new Node<T>(item);
    else {
      Node<T> tmp = new Node<T>(item, last, null);
      last.next = tmp;
      last = tmp;
    }
    return true;
  }

  public boolean contains(T item) {
    Node<T> node = first;
    while (node != null) {
      if (item.equals(node.item)) 
        return true;
      node = node.next;
    }
    return false;
  }

  public String toString() {
    StringBuilder sb = new StringBuilder();
    sb.append("[");
    Node<T> node = first;
    while (node != null) {
      sb.append(node.item);
      node = node.next;
      if (node != null)
        sb.append(",");
    }
    sb.append("]");
    return sb.toString();    
  }

  // Corresponds to F# List.map of type 'T list * ('T -> 'R) -> 'R list
  public <R> LinkedList<R> map(Fun<T,R> f) {
    LinkedList<R> res = new LinkedList<R>();
    Node<T> node = first;
    while (node != null) {
      res.add(f.invoke(node.item));
      node = node.next;
    }
    return res;
  }

  /* 5.1
 * 
Implement a similar Java (or C#) method
static int[] merge(int[] xs, int[] ys) that takes two sorted arrays of ints and merges them into a sorted array of ints.
The method should build a new array, and should not modify the given arrays.
Two arrays xs and ys of integers may be built like this:
int[] xs = { 3, 5, 12 };
int[] ys = { 2, 3, 4, 7 };
 */
  static int[] merge(int[] xs, int[] ys) {
    int[] res = new int[xs.length + ys.length];
    int i = 0, j = 0, k = 0;
    
    // some while looops

    return res;
  }
}

// Corresponds to an F# or ML function type 'A -> 'R

interface Fun<A,R> {
  R invoke(A x);
}

