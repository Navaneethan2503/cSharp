using System;
/**
The override modifier is required to extend or modify the abstract or virtual implementation of an inherited method, property, indexer, or event.

An override method provides a new implementation of the method inherited from a base class. The method that is overridden by an override declaration is known as the overridden base method. An override method must have the same signature as the overridden base method. override methods support covariant return types. In particular, the return type of an override method can derive from the return type of the corresponding base method.

You cannot override a non-virtual or static method. The overridden base method must be virtual, abstract, or override.

An override declaration cannot change the accessibility of the virtual method. Both the override method and the virtual method must have the same access level modifier.

You cannot use the new, static, or virtual modifiers to modify an override method.

An overriding property declaration must specify exactly the same access modifier, type, and name as the inherited property. Read-only overriding properties support covariant return types. The overridden property must be virtual, abstract, or override.

Key Points
Must Override: The override keyword must be used in a derived class to override a virtual, abstract, or override method from the base class.
Same Signature: The overriding method must have the same signature as the method it overrides.
Access Modifiers: The access level of the overriding method must be the same as or less restrictive than the overridden method.
Base Keyword: You can call the base class implementation from the derived class using the base keyword.

**/

namespace OverrideNamespace{

    abstract class Employee{

        public int _basePay;

        public virtual string Name { get; set; }

        public int Age { get; set; }

        public Employee(int basePay, string name, int age){
            _basePay = basePay;
            Name = name;
            Age = age;
        }

        public abstract int GetAdditionalBonus();

        public virtual void PrintDetails(){
            Console.WriteLine("{0}, Age: {1} and salaray is {2}",Name,Age,_basePay);
        }

    }

    class RegularEmployee : Employee{

        protected int _bonus { get; set; }

        public RegularEmployee(int basic, string name, int age, int bonus) : base(basic,name,age){
            _bonus = bonus;
        }

        public override int GetAdditionalBonus()
        {
            Console.WriteLine("Regular Class called");
            return _basePay + _bonus + 1000;
        }

    }

    class SaleEmployee : RegularEmployee{

        public SaleEmployee(int basic, string name, int age, int bonus) : base(basic,name,age,bonus){

        }

        public override int GetAdditionalBonus()
        {
            Console.WriteLine("SaleEmployee Class called");
            Console.WriteLine("No additional Bonus");
            return _basePay + _bonus;
        }


    }
    class OverrideClass{
        public static void Main(){
            Console.WriteLine("Override Access Modifiers :");

            RegularEmployee e1 = new RegularEmployee(1200,"navaneethan",24,1000);
            Console.WriteLine("e1 :"+e1.GetAdditionalBonus());
            SaleEmployee s1 = new SaleEmployee(1000,"nickil",25,500);
            Console.WriteLine("s1 :"+s1.GetAdditionalBonus());

            RegularEmployee s2 = new SaleEmployee(1100, "kalpna",40,500);
            Console.WriteLine("S2 :"+s2.GetAdditionalBonus());//when invoked the virtual method it checks the object type for implementation not variable type.

            Employee e2 = new RegularEmployee(1600,"mangu",22,1000);
            e2.PrintDetails();
            s2.PrintDetails();
            e1.PrintDetails();//Called original implementation where dervired class not having the implementation.
        
        }
    }
}