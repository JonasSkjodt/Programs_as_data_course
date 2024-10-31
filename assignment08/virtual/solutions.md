# 9.1
We have written down the explanation for the bytecode in the files: selsort.jvmbytecode and selsort.il 

# 9.3

We ran the initial code and had the following error

```
Exception: java.lang.OutOfMemoryError thrown from the UncaughtExceptionHandler in thread "Thread-0"

Exception in thread "main" java.lang.OutOfMemoryError: Java heap space
```

The problem is there is no garbage collector


This code could be a way to deal with garbage collection

```
public synchronized int get() {
    if (head.next == null) 
      return -999;
    Node first = head;
    head = first.next;
    first.next = null; //garbage collector
    return head.item;
  }
```

After the head has stored its information from first.next, first.next is then set to null to break the link to the rest of the list. The first node is no longer referenced to allow the garbage collector to reclaim its memory.