/**

NullReferenceException Class
-----------------------------
The exception that is thrown when there is an attempt to dereference a null object reference.

    public class NullReferenceException : SystemException

Remarks
A NullReferenceException exception is thrown when you try to access a member on a type whose value is null. A NullReferenceException exception typically reflects developer error and is thrown in the following scenarios:
You can avoid most NullReferenceException exceptions in C# by using the null-conditional operator (?.) or the null-coalescing operator (??).
1.You forgot to instantiate a reference type.
2.You forgot to dimension an array before initializing it.
3. You get a null return value from a method, and then call a method on the returned type. This sometimes is the result of a documentation error; the documentation fails to note that a method call can return null. In other cases, your code erroneously assumes that the method will always return a non-null value.
4. You're using an expression (for example, you chained a list of methods or properties together) to retrieve a value and, although you're checking whether the value is null, the runtime still throws a NullReferenceException exception. This occurs because one of the intermediate values in the expression returns null. As a result, your test for null is never evaluated.
5. You're enumerating the elements of an array that contains reference types, and your attempt to process one of the elements throws a NullReferenceException exception.
6. A method when it accesses a member of one of its arguments, but that argument is null. The PopulateNames method in the following example throws the exception at the line names.Add(arrName);.
7. A list is created without knowing the type, and the list was not initialized. The GetList method in the following example throws the exception at the line emptyList.Add(value).


The following Microsoft intermediate language (MSIL) instructions throw NullReferenceException: callvirt, cpblk, cpobj, initblk, ldelem.<type>, ldelema, ldfld, ldflda, ldind.<type>, ldlen, stelem.<type>, stfld, stind.<type>, throw, and unbox.

NullReferenceException uses the HRESULT COR_E_NULLREFERENCE, which has the value 0x80004003.


**/
