using System;
/**
Supports cloning, which creates a new instance of a class with the same value as an existing instance.

The ICloneable interface enables you to provide a customized implementation that creates a copy of an existing object. The ICloneable interface contains one member, the Clone method, which is intended to provide cloning support beyond that supplied by Object.MemberwiseClone. For more information about cloning, deep versus shallow copies, and examples, see the Object.MemberwiseClone method.

Methods:
--------
Clone()	- Creates a new object that is a copy of the current instance.
    public object Clone();
    The resulting clone must be of the same type as, or compatible with, the original instance.
    An implementation of Clone can perform either a deep copy or a shallow copy. In a deep copy, all objects are duplicated; in a shallow copy, only the top-level objects are duplicated and the lower levels contain references. Because callers of Clone cannot depend on the method performing a predictable cloning operation, we recommend that ICloneable not be implemented in public APIs.

**/
namespace IClonableNamespace{
    class IClonableClass{
        public static void Main(){
            Console.WriteLine("IClonable Interface...");
        }
    }
}