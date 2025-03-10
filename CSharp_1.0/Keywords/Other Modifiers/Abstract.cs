using System;
/**
The abstract modifier indicates that the thing being modified has a missing or incomplete implementation.
The abstract modifier can be used with classes, methods, properties, indexers, and events. 
Use the abstract modifier in a class declaration to indicate that a class is intended only to be a base class of other classes, not instantiated on its own.
Members marked as abstract must be implemented by non-abstract classes that derive from the abstract class.

Abstract classes have the following features:

1. An abstract class cannot be instantiated.
2. An abstract class may contain abstract methods and accessors.
3. It is not possible to modify an abstract class with the sealed modifier because the two modifiers have opposite meanings. The sealed modifier prevents a class from being inherited and the abstract modifier requires a class to be inherited.
4. A non-abstract class derived from an abstract class must include actual implementations of all inherited abstract methods and accessors.

Use the abstract modifier in a method or property declaration to indicate that the method or property does not contain implementation.

Abstract methods have the following features:

1. An abstract method is implicitly a virtual method.
2. Abstract method declarations are only permitted in abstract classes.
3. Because an abstract method declaration provides no actual implementation, there is no method body; the method declaration simply ends with a semicolon and there are no curly braces ({ }) following the signature. 
    For example:
    public abstract void MyMethod();  
4. The implementation is provided by a method override, which is a member of a non-abstract class.
5. It is an error to use the static or virtual modifiers in an abstract method declaration.

Abstract properties behave like abstract methods, except for the differences in declaration and invocation syntax.

It is an error to use the abstract modifier on a static property.

An abstract inherited property can be overridden in a derived class by including a property declaration that uses the override modifier.

An abstract class must provide implementation for all interface members.

An abstract class that implements an interface might map the interface methods onto abstract methods. For example:

If you don't specify an access modifier for an abstract method, it defaults to private.

**/

namespace AbstractNamespace{

    public abstract class Shape{//abstarct in class indicates not initiated and only acts as base class.

        public string _color = "";

        protected Shape(string color){
            _color = color;
        }

        public abstract int X { get;  }
        public abstract int Y { get;  }
        public abstract int GetArea();

        //abstract static void Print(); - Error cannot be without implementation becz static 

        //public virtual abstract void Print(); - Error - Cannot have virtual keyword with abstract becz abstract itself implicitly virtual
    }

    public class Square : Shape{

        public int _side = 0;

        public Square(string color , int s) : base(color){
            _side = s;
        }

        public override int GetArea()//Must give implementation for abstract method in base class
        {
            return _side * _side;
        }

        public override int X {
            get{
                return 10+ _side;
            }
        }

        public override int Y {
            get{
                return 20+_side;
            }
        }
    }

    interface I
    {
        void M();
    }

    abstract class C : I
    {
        public abstract void M();//inherited interface must have defined method or implementation for all members
    }

    class B : C{
        public override void M(){
            Console.WriteLine("Print B Class");
        }

        //public abstract void Print(); - Error abstrcat method cannot contains in concreate class.
    }
    public class AbstractClass{
        public static void Main(){
            Console.WriteLine("Abstract Class");

            Square s = new Square("red",5);
            s._side = 10;
            Console.WriteLine(s.GetArea());
            Console.WriteLine(s.X + " - "+ s.Y + " Color is :"+ s._color); 
            //Shape ss = new Shape(); - Error not initiated 
        }
    }
}