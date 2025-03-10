using System;
using System.Drawing;
using AbstractNamespace;
/**
The virtual keyword is used to modify a method, property, indexer, or event declaration and allow for it to be overridden in a derived class. 
The implementation of a virtual member can be changed by an overriding member in a derived class.
When a virtual method is invoked, the run-time type of the object is checked for an overriding member. The overriding member in the most derived class is called, which might be the original member, if no derived class has overridden the member.

By default, methods are non-virtual. You cannot override a non-virtual method.
Virtual properties behave like virtual methods, except for the differences in declaration and invocation syntax.

A virtual inherited property can be overridden in a derived class by including a property declaration that uses the override modifier.

Key Points
Optional Override: Derived classes are not required to override a virtual method. If they don't, the base class implementation is used.
Access Modifiers: The access level of the overriding method must be the same as or less restrictive than the virtual method.
Base Keyword: You can call the base class implementation from the derived class using the base keyword.

**/
namespace VirtualNamespace{
    class Shape{
        public const double PI = 3.14;
        public virtual int _x { get; set; }

        public virtual int _y { get; set; }

        public virtual string _color { get; set; }

        protected Shape(int r, int h){
            _x = r;
            _y = h;
        }

        public virtual double Area(){
            return PI;
        }

        public virtual double GetPI(){
            Console.WriteLine("Shape Class Called");
            return PI;
        }
    }

    class Circle : Shape{

        public Circle(int r, int h) : base(r,h){

        }


        public override double Area()
        {
            return _x * _x;
        }

        public override double GetPI(){
            return base.GetPI();
        }
    }

    class Sphere : Shape{

        public Sphere(int r, int h): base(r,h){

        }

        public override string _color { 
            get{
                return _color;
            }

            set{
                if(!string.IsNullOrEmpty(value)){
                    _color = value;
                }
                else{
                    _color = "Undefined";
                }
            }
         }
        public override double Area(){
            return 4  * _x * _y + PI;
        }
    }
    class VirtualClass{
        public static void Main(){
            Console.WriteLine("Virtual Keyword");
            Circle c = new Circle(5,0);
            Sphere s = new Sphere(4,5);
            Console.WriteLine(c.Area());
            Console.WriteLine(s.Area());//When invoke Area method runtime will check the override method in object type if not found then runs original implementation.
            Console.WriteLine("Sphere Dot have implementation in class, so it runs original implemenations :"+s.GetPI());
            // s._color = "";
            // c._color = "";
            //Console.WriteLine("Circle :"+c._color + " - Sphere : "+ s._color);
        }
    }
}