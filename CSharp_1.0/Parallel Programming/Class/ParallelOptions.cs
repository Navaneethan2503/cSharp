/**
ParallelOptions Class
---------------------
Stores options that configure the operation of methods on the Parallel class.

    public class ParallelOptions

By default, methods on the Parallel class attempt to use all available processors, are non-cancelable, and target the default TaskScheduler (TaskScheduler.Default). ParallelOptions enables overriding these defaults.

Constructors:
----------------
ParallelOptions()	- Initializes a new instance of the ParallelOptions class.

Properties:
-----------
CancellationToken	- Gets or sets the CancellationToken associated with this ParallelOptions instance.
MaxDegreeOfParallelism	- Gets or sets the maximum number of concurrent tasks enabled by this ParallelOptions instance.
TaskScheduler	- Gets or sets the TaskScheduler associated with this ParallelOptions instance. Setting this property to null indicates that the current scheduler should be used.

Methods:
--------
Equals(Object)	- Determines whether the specified object is equal to the current object.(Inherited from Object)
GetHashCode()	- Serves as the default hash function.(Inherited from Object)
GetType()	- Gets the Type of the current instance.(Inherited from Object)
MemberwiseClone()	- Creates a shallow copy of the current Object.(Inherited from Object)
ToString()	- Returns a string that represents the current object.(Inherited from Object)


**/

