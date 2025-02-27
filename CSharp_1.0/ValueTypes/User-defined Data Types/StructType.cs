using System;
using System.Runtime.InteropServices;
using EnumType;
/**
structure (or struct) is a value type used to encapsulate data and related functionality
You use the struct keyword to define a structure type.

Key Characteristics:
    Value Type: Structs are value types, meaning they are stored on the stack and are copied when passed to methods or assigned to another variable.
    Lightweight: They are typically used for small data structures that contain primarily data and little or no behavior.
    No Inheritance: Structs do not support inheritance, but they can implement interfaces.
    Default Constructor: Structs cannot have a default constructor (a constructor without parameters), but they can have parameterized constructors.
    Immutability: It's common practice to make structs immutable by making all fields readonly and providing a constructor to initialize them.

When to Use Structs:
    When you need a small, lightweight object.
    When you want to avoid the overhead of heap allocation.
    When you need to encapsulate a few related variables.

Structure types have value semantics. That is, a variable of a structure type contains an instance of the type. By default, variable values are copied on assignment, passing an argument to a method, and returning a method result. For structure-type variables, an instance of the type is copied.

Typically, you use structure types to design small data-centric types that provide little or no behavior. For example, .NET uses structure types to represent a number (both integer and real), a Boolean value, a Unicode character, a time instance. If you're focused on the behavior of a type, consider defining a class. Class types have reference semantics. That is, a variable of a class type contains a reference to an instance of the type, not the instance itself.

Because structure types have value semantics, we recommend you define immutable structure types.

readonly struct is a special kind of struct that ensures all its fields are immutable. This means once an instance of the struct is created, its fields cannot be modified. Using readonly struct can help improve performance and ensure data integrity, especially in multi-threaded environments.

Key Points:
    Immutability: All fields in a readonly struct must be readonly, ensuring that the data cannot be changed after the struct is created.
    Performance: Readonly structs can lead to performance optimizations because the compiler can make certain assumptions about the immutability of the data.
    Thread Safety: Immutability makes readonly structs inherently thread-safe, as their state cannot be changed after creation.

Readonly Instance Members:
   Assignment Restriction: Within a readonly instance member (like a method or property), you cannot assign values to the instance fields of the struct. This ensures that the struct remains immutable.
Calling Non-Readonly Members:
    Copy Creation: When a readonly member calls a non-readonly member, the compiler creates a copy of the struct instance. The non-readonly member operates on this copy, not the original instance.
    No Modification of Original: Since the non-readonly member works on a copy, any modifications it makes do not affect the original struct instance.

The compiler declares a get accessor of an automatically implemented property as readonly, regardless of presence of the readonly modifier in a property declaration.

The init accessor allows you to set the property or indexer during object initialization, but it becomes immutable afterward. This is particularly useful for creating immutable objects with properties that can only be set during initialization.
public readonly double X { get; init; }

you can apply the readonly modifier to static fields of a struct, but not to other static members like properties or methods. This ensures that the value of the static field cannot be changed after it is initialized, providing immutability and potential performance optimizations.

You can define record structure types. Record types provide built-in functionality for encapsulating data. You can define both record struct and readonly record struct types. A record struct can't be a ref struct. 

new keyword is used to initialize them in a way that ensures all their fields are properly set up. This is different from primitive value types like int, long, char, float, and enum, which have default values and do not require explicit initialization with new.

When using the new keyword, any properties or fields not explicitly set in the constructor will be initialized to their default values.
If you do not use the new keyword, you must manually initialize all fields or properties before using them.

Default Constructor:
If you create an instance of the struct without using the new keyword, you must manually initialize each field or property before using them:

Point p;
p.X = 3;
p.Y = 4; // You must manually initialize Y
Console.WriteLine($"X: {p.X}, Y: {p.Y}"); // Output: X: 3, Y: 4

The with expression to create a copy of a structure-type instance with specified properties or fields modified. This is known as nondestructive mutation, as it allows you to create a new instance with some changes without modifying the original instance.

/ Creating an instance of Point
Point p1 = new Point(3, 4);

// Creating a new instance with modified properties using the with expression
Point p2 = p1 with { X = 5 };

all fields of a struct must be definitely assigned when the struct is created because structs directly store their data. The default value of a struct initializes all fields to their default values (e.g., 0 for numeric types, false for bool, '\0' for char, and null for reference types). When a constructor is invoked, all fields must be definitely assigned. Here are the mechanisms to initialize fields:

Field Initializers:
You can add field initializers directly to any field or auto-implemented property.

public struct Point
{
    public int X { get; set; } = 0; // Field initializer
    public int Y { get; set; } = 0; // Field initializer
}

Size of a Struct:
The size of a struct in C# depends on the size of its fields. You can determine the size of a struct using the System.Runtime.InteropServices.Marshal.SizeOf method or the sizeof operator in an unsafe context.

Structs can be declared in various scopes:

    Namespace Scope: Directly within a namespace.
    Class or Struct Scope: Nested within a class or another struct.
    Method Scope: As a local struct within a method (though this is less common).

Constructors in a Struct:
Structs can have multiple constructors, but there are some restrictions:

Parameterless Constructor: Starting with C# 10, structs can have a parameterless constructor, but it is not required.
Parameterized Constructors: Structs can have multiple parameterized constructors.

Limitations with the design of a structure type
    Structs have most of the capabilities of a class type. There are some exceptions:

    A structure type can't inherit from other class or structure type and it can't be the base of a class. However, a structure type can implement interfaces.
    You can't declare a finalizer within a structure type.
    Before C# 11, a constructor of a structure type must initialize all instance fields of the type.

Passing structure-type variables by reference
When you pass a structure-type variable to a method as an argument or return a structure-type value from a method, the whole instance of a structure type is copied. Pass by value can affect the performance of your code in high-performance scenarios that involve large structure types. You can avoid value copying by passing a structure-type variable by reference. Use the ref, out, in, or ref readonly method parameter modifiers to indicate that an argument must be passed by reference. Use ref returns to return a method result by reference.



**/
namespace StructType{

    public struct Car{
        public string color { get; set; }
        public int seatsAvailable { get; set;}
        public string Brand { get; set; }

        public Car(){
            Console.WriteLine("Struct initated :"+Brand);
        }
        public Car(string colorName, int seatsCount, string BrandName ){
            color = colorName;
            seatsAvailable = seatsCount;
            Brand = BrandName;
        }

        public Car(string colorName){
            color = colorName;
        }

        public string DisplayBrandName(){
            return Brand;
        }

        public string DisplayAllInfo(){
            return $"Brand Name - {Brand}, Available Seats : {seatsAvailable}, color : {color}";
        }

        public void updateColorName(string colorName){
            color = colorName;
        }

        public void updateSeatCount(int count){
            seatsAvailable = count;
        }

        public void updateBrand(string BrandName){
            Brand = BrandName;
        }
    }
    public class StructType{

        public readonly struct Coordinates{
            public double x_axes { get; init; }
            public double y_axex { get; init; }

            public Coordinates(double x, double y){
                x_axes = x;
                y_axex = y;
            }

            public  double PrintCoordinates(){
                return (x_axes + y_axex);
            }
        }
        
        public struct Measurement{
            readonly public int Length { get; init; }
            readonly public int Breath { get; init; }

            Coordinates axes = new Coordinates();


            public Measurement(int LengthL, int BreathB){
                Length = LengthL;
                Breath = BreathB;
            }

            public double Diameter {get; set;} = 3.0;

            public readonly int CalculateTotal(){
                Console.Write("Total Length Is :");
                updateDiameter((double)Length*Breath);//Creates Copy of this new struct instance and applys / calls this method
                return (Length*Breath);
            }

            public void updateDiameter(double dia){
                Diameter = dia;
            }

            public Measurement updateAxes(Measurement measurement){
                measurement.Diameter = 10;
                Console.WriteLine("update Diamether in inside method :"+measurement.Diameter);
                return measurement;
            }

            public enum Centimeter{
                OneCM = 1,
                twoCM ,
                threeCM = 3
            }

            public struct Test{
                public double CMx { get; set;}
                public double CMy { get; set; }
            }

            public Test TestsMethos(Test t, Centimeter c){
                if(c == Centimeter.OneCM){
                    Diameter = t.CMx*t.CMy;
                    t.CMx = 100;
                }
                return t;
            }
        }
        
        public struct Shape{
            public string Name { get; set; }
            public string Color { get; set; }
            public int Size { get; set; }
            public double x { get; set; }
            public double y { get; set; }
        }
        public static void Main(){
            Console.WriteLine("Struct Types");
            Car audiCar = new Car();
            Console.WriteLine("Available seats :"+audiCar.seatsAvailable);
            Console.WriteLine(audiCar.DisplayAllInfo());

            Car benzCar = new Car("White",5,"benzCar");
            Console.WriteLine(benzCar.DisplayAllInfo());

            Car benzDuplicate = benzCar;
            benzDuplicate.color = "Red";
            benzDuplicate.seatsAvailable = 4;
            Console.WriteLine(benzDuplicate.DisplayAllInfo());

            benzCar.updateColorName("White-ShaddowGrey");
            Console.WriteLine(benzCar.DisplayAllInfo());

            Console.WriteLine("Struct Array");
            Car[] Cars = new Car[3];
            foreach(Car c in Cars){
                Console.WriteLine(c.DisplayAllInfo());
            }

            Cars[0].Brand = "Apple";
            Cars[1].Brand = "Ball";
            Cars[2].Brand = "Cat";
            
            Console.WriteLine("Updated Brand Names :");
            foreach(Car c in Cars){
                Console.WriteLine(c.DisplayAllInfo());
            }

            Coordinates coordinate = new Coordinates(3.2,1.5);
            Console.WriteLine(coordinate.PrintCoordinates());

            Measurement measurement = new Measurement(1,4);
            System.Console.WriteLine("Before CalculateTotal :"+measurement.Diameter);
            System.Console.WriteLine(measurement.CalculateTotal());
            System.Console.WriteLine("After CalculateTotal :"+measurement.Diameter);

            Console.WriteLine("Default of Measurement :"+ default(Measurement));

            Measurement measurementDuplicate = measurement with { Length = 5, Diameter = 4};
            System.Console.WriteLine(measurementDuplicate.CalculateTotal());

            System.Console.WriteLine("Before update Axes method Diameter is :"+ measurementDuplicate.Diameter);
            System.Console.WriteLine(measurementDuplicate.updateAxes(measurementDuplicate));
            Console.WriteLine("After Update Axes Method Diameter is:"+measurementDuplicate.Diameter);

            System.Console.WriteLine("Size :"+Marshal.SizeOf(typeof(Measurement)));
            
            Measurement.Test tInstance = new Measurement.Test();
            tInstance.CMx = 10;
            tInstance.CMy = 20;

            Console.WriteLine("Strcut Before tInstance :"+ tInstance.CMx);
            Measurement.Test copy = measurementDuplicate.TestsMethos(tInstance,Measurement.Centimeter.OneCM);


            Console.WriteLine("After TestMEthod Diameter :"+measurementDuplicate.Diameter);
            Console.WriteLine($"Struct After Change C :"+copy.CMx);
            Console.WriteLine("Strcut After tInstance :"+ tInstance.CMx);
        }
    }
}