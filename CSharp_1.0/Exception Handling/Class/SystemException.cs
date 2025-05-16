/**
SystemException Class:
----------------------

Serves as the base class for system exceptions namespace.

    public class SystemException : Exception

Remarks
This class is provided as a means to differentiate between system exceptions and application exceptions. It is the base class of such exceptions as ArgumentException, FormatException, and InvalidOperationException.
Because SystemException serves as the base class of a variety of exception types, your code should not throw a SystemException exception, nor should it attempt to handle a SystemException exception unless you intend to re-throw the original exception.

SystemException uses the HRESULT COR_E_SYSTEM, that has the value 0x80131501.


Constructors:
-------------
SystemException()	- Initializes a new instance of the SystemException class.
SystemException(String, Exception)	- Initializes a new instance of the SystemException class with a specified error message and a reference to the inner exception that is the cause of this exception.
SystemException(String)	- Initializes a new instance of the SystemException class with a specified error message.



**/