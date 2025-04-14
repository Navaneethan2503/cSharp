using System;
/**
out (generic modifier) 
----------------------
For generic type parameters, the out keyword specifies that the type parameter is covariant. You can use the out keyword in generic interfaces and delegates.

Covariance enables you to use a more derived type than that specified by the generic parameter. This allows for implicit conversion of classes that implement covariant interfaces and implicit conversion of delegate types. Covariance and contravariance are supported for reference types, but they are not supported for value types.

An interface that has a covariant type parameter enables its methods to return more derived types than those specified by the type parameter. For example, because in .NET Framework 4, in IEnumerable<T>, type T is covariant, you can assign an object of the IEnumerable(Of String) type to an object of the IEnumerable(Of Object) type without using any special conversion methods.

A covariant delegate can be assigned another delegate of the same type, but with a more derived generic type parameter.

In a generic interface, a type parameter can be declared covariant if it satisfies the following conditions:

The type parameter is used only as a return type of interface methods and not used as a type of method arguments.

There is one exception to this rule. If in a covariant interface you have a contravariant generic delegate as a method parameter, you can use the covariant type as a generic type parameter for this delegate. For more information about covariant and contravariant generic delegates, see Variance in Delegates and Using Variance for Func and Action Generic Delegates.

The type parameter is not used as a generic constraint for the interface methods.


in (Generic Modifier) :
-----------------------
For generic type parameters, the in keyword specifies that the type parameter is contravariant. You can use the in keyword in generic interfaces and delegates.

Contravariance enables you to use a less derived type than that specified by the generic parameter. This allows for implicit conversion of classes that implement contravariant interfaces and implicit conversion of delegate types. Covariance and contravariance in generic type parameters are supported for reference types, but they are not supported for value types.

A type can be declared contravariant in a generic interface or delegate only if it defines the type of a method's parameters and not of a method's return type. In, ref, and out parameters must be invariant, meaning they are neither covariant nor contravariant.

An interface that has a contravariant type parameter allows its methods to accept arguments of less derived types than those specified by the interface type parameter. For example, in the IComparer<T> interface, type T is contravariant, you can assign an object of the IComparer<Person> type to an object of the IComparer<Employee> type without using any special conversion methods if Employee inherits Person.

A contravariant delegate can be assigned another delegate of the same type, but with a less derived generic type parameter.


**/
namespace Keywords{
    // Covariant interface.
    interface ICovariant<out R> { }

    // Extending covariant interface.
    interface IExtCovariant<out R> : ICovariant<R> { }

    // Implementing covariant interface.
    class Sample<R> : ICovariant<R> { }

    class Control{}

    class Button: Control{}

        // Contravariant interface.
    interface IContravariant<in A> { }

    // Extending contravariant interface.
    interface IExtContravariant<in A> : IContravariant<A> { }

    // Implementing contravariant interface.
    class Sample1<A> : IContravariant<A> { }


    

    class INOUTGenericClass{
        // Covariant delegate.
        public delegate R DCovariant<out R>();

        // Methods that match the delegate signature.
        public static Control SampleControl()
        { return new Control(); }

        public static Button SampleButton()
        { return new Button(); }

        // Contravariant delegate.
        public delegate void DContravariant<in A>(A argument);

        // Methods that match the delegate signature.
        public static void SampleControl(Control control)
        { }
        public static void SampleButton(Button button)
        { }

        public static void Main(){
            Console.WriteLine("INOUT Generic Class.");
            ICovariant<Object> iobj1 = new Sample<Object>();
            ICovariant<String> istr1 = new Sample<String>();

            // You can assign istr to iobj because
            // the ICovariant interface is covariant.
            iobj1 = istr1;

            // Instantiate the delegates with the methods.
            DCovariant<Control> dControl = SampleControl;
            DCovariant<Button> dButton = SampleButton;

            // You can assign dButton to dControl
            // because the DCovariant delegate is covariant.
            dControl = dButton;

            // Invoke the delegate.
            dControl();


            IContravariant<Object> iobj = new Sample1<Object>();
            IContravariant<String> istr = new Sample1<String>();

            // You can assign iobj to istr because
            // the IContravariant interface is contravariant.
            istr = iobj;

            // Instantiating the delegates with the methods.
            DContravariant<Control> dControl1 = SampleControl;
            DContravariant<Button> dButton1 = SampleButton;

            // You can assign dControl to dButton
            // because the DContravariant delegate is contravariant.
            dButton1 = dControl1;

            // Invoke the delegate.
            dButton1(new Button());
        }
    }
}