using System;
/**
Properties combine aspects of both fields and methods. 
To the user of an object, a property appears to be a field; accessing the property requires the same syntax. 
To the implementer of a class, a property is one or two code blocks, representing a get accessor and/or a set or init accessor. 
The code block for the get accessor is executed when the property is read; the code block for the set or init accessor is executed when the property is assigned a value. 
A property without a set accessor is considered read-only. 
A property without a get accessor is considered write-only. 
A property that has both accessors is read-write. 
You can use an init accessor instead of a set accessor to enable the property to be set as part of object initialization but otherwise make it read-only.

Unlike fields, properties aren't classified as variables. Therefore, you can't pass a property as a ref or out parameter.

Properties are declared in the class block by specifying the access level of the field, followed by the type of the property, followed by the name of the property, and followed by a code block that declares a get-accessor and/or a set accessor. 
For example:
public class Person
{
    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
}

Get Accessors:
----------------
The body of the get accessor resembles that of a method. It must return a value of the property type. 
The C# compiler and Just-in-time (JIT) compiler detect common patterns for implementing the get accessor, and optimizes those patterns.

For example, a get accessor that returns a field without performing any computation is likely optimized to a memory read of that field. Automatically implemented properties follow this pattern and benefit from these optimizations. However, a virtual get accessor method can't be inlined because the compiler doesn't know at compile time which method might actually be called at run time.

The get accessor must be an expression-bodied member(=>), or end in a return or throw statement, and control can't flow off the accessor body.

The set accessor:
------------------

The set accessor resembles a method whose return type is void. 
It uses an implicit parameter called value, whose type is the type of the property. 
The compiler and JIT compiler also recognize common patterns for a set or init accessor. 
Those common patterns are optimized, directly writing the memory for the backing field.

It's an error to use the implicit parameter name, value, for a local variable declaration in a set accessor.


The init accessor:
--------------------
The code to create an init accessor is the same as the code to create a set accessor except that you use the init keyword instead of set. 
The difference is that the init accessor can only be used in the constructor or by using an object-initializer.


Remarks:
---------
1. Properties can be marked as public, private, protected, internal, protected internal, or private protected. These access modifiers define how users of the class can access the property. The get and set accessors for the same property can have different access modifiers.
2. A property can be declared as a static property by using the static keyword. Static properties are available to callers at any time, even if no instance of the class exists. 
3. A property can be marked as a virtual property by using the virtual keyword. Virtual properties enable derived classes to override the property behavior by using the override keyword.
4. A property overriding a virtual property can also be sealed, specifying that for derived classes it's no longer virtual.
5.  a property can be declared abstract. Abstract properties don't define an implementation in the class, and derived classes must write their own implementation.

It is an error to use a virtual, abstract, or override modifier on an accessor of a static property.

Automatically implemented properties:
-------------------------------------------
A property definition contains declarations for a get and set accessor that retrieves and assigns the value of that property:
public string? FirstName { get; set; }

The compiler generates a hidden backing field for the property. The compiler also implements the body of the get and set accessors. Any attributes are applied to the automatically implemented property. You can apply the attribute to the compiler-generated backing field by specifying the field: tag on the attribute.

Expression body definitions:
Property accessors often consist of single-line statements. The accessors assign or return the result of an expression. You can implement these properties as expression-bodied members. Expression body definitions consist of the => token followed by the expression to assign to or retrieve from the property.

Beginning with C# 13, you can create partial properties in partial classes. The implementing declaration for a partial property can't be an automatically implemented property. An automatically implemented property uses the same syntax as a declaring partial property declaration.

**/
namespace properties{

    public class Date
    {
        public int Age { get; init; }

        public Date(string lName){
            this.FirstName = lName;
        }
        //The real location of a property's data is often referred to as the property's "backing store." It's common for properties to use private fields as a backing store. 
        // The field is marked private in order to make sure that it can only be changed by calling the property. 
        private string _color = "";// Backing store

        public string Color{
            get {
                return _color;
            }

            set{
                _color = value;
            }
        }

        private int _month = 7;  // Backing store

        public int Month
        {
            get => _month;
            set
            {
                //validation
                if ((value > 0) && (value < 13))
                {
                    _month = value;
                }
            }
        }

        //Automatically compiler creates the backing store to it and generate the code for get and set.
        //Automatically implemented properties provide simplified syntax for simple property declarations
        public string NameBrand { get; set; }

        
        public required string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; }

        public string NameAlise => $"{FirstName} {LastName}";

        //The get accessor can be used to return the field value or to compute it and return it.
        private string _name;
        public string Name {
            get => _name != null ? _name : "NA";

            set => _name = value;
        }

        public string Test {
            get ;

            set;
        }

    }

    abstract class Shape
    {

        public abstract double Area
        {
            get;
            set;
        }
    }

    class Square : Shape
    {
        public double side;

        //constructor
        public Square(double s) => side = s;

        public override double Area
        {
            get => side * side;
            set => side = System.Math.Sqrt(value);
        }
    }

    class properties{
        public static void Main(){
            Console.WriteLine("Properties ...");
            Date obj = new Date("Navaneethan"){ FirstName = "nickil", Age = 24 };
            //When you assign a value to the property, the set accessor is invoked by using an argument that provides the new value.
            //obj.Name = "Navaneethan S";
            //When you access the property, the get accessor is invoked.
            Console.WriteLine(obj.FirstName);
            Console.WriteLine("Age is :"+obj.Age);

            //obj.Age = 12; - init cannot be assigned after object creation.

            //obj.Test = 100;


            //override of property
            Square s = new Square(10.0);
            Console.WriteLine("Side of Square :"+s.side);
            s.side = 20.0;
            Console.WriteLine("Side of Square :"+s.side);


        }
    }
}