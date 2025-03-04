using System;
/**
Arrays in C# are a fundamental data structure used to store a fixed-size sequential collection of elements of the same type. 

Arrays in C# are stored in a block of contiguous memory, meaning that all elements are placed next to each other in memory. This allows for efficient access and manipulation of the elements.

Memory Layout
When you declare an array, the runtime allocates a block of memory large enough to hold all the elements of the array. For example, if you declare an array of integers with 5 elements:

int[] numbers = new int[5];
The memory layout will look something like this:

Metadata | numbers[0] | numbers[1] | numbers[2] | numbers[3] | numbers[4] |

Accessing Elements
Accessing an element in an array is very efficient because the memory address of any element can be calculated directly using its index. The formula to calculate the address of an element is:

address = base_address + (index * size_of_element)
Where base_address is the starting address of the array, index is the position of the element, and size_of_element is the size of each element in bytes.

Metadata of Arrays in C#
In C#, arrays are reference types, and they include metadata that provides information about the array itself. This metadata is stored alongside the array elements in memory and includes:

Type Handle: Identifies the type of the array.
Length: Stores the number of elements in the array.
Rank: Indicates the number of dimensions of the array.

Value Types vs. Reference Types
Value Type Arrays: The actual data is stored in contiguous memory locations on the heap.
Reference Type Arrays: The array contains references (pointers) to the actual objects stored elsewhere in memory.

Stack and Heap: The reference to the array is stored on the stack if declared in a local scope, while the array object itself (metadata + elements) is stored on the heap12.
Garbage Collection: The CLR's garbage collector manages the deallocation of memory for arrays when they are no longer in use.

You declare an array by specifying the type of its elements. If you want the array to store elements of any type, you can specify object as its type. In the unified type system of C#, all types, predefined and user-defined, reference types and value types, inherit directly or indirectly from Object.

type[] arrayName;

An array is a reference type, so the array can be a nullable reference type. 

The element types might be reference types, so an array can be declared to hold nullable reference types

The following example declarations show the different syntax used to declare the nullability of the array or the elements:
type?[] arrayName; // non nullable array of nullable element types.
type[]? arrayName; // nullable array of non-nullable element types.
type?[]? arrayName; // nullable array of nullable element types.

Declaration and Initialization
You can declare and initialize an array in C# like this:

int[] numbers = new int[5]; // Declaration with size
int[] numbers = { 1, 2, 3, 4, 5 }; // Declaration with initialization

Uninitialized elements in an array are set to the default value for that type:
int[] numbers = new int[10]; // All values are 0
string[] messages = new string[10]; // All values are null.

An array can be single-dimensional, multidimensional, or jagged.

The number of dimensions are set when an array variable is declared. The length of each dimension is established when the array instance is created. These values can't be changed during the lifetime of the instance.
A jagged array is an array of arrays, and each member array has the default value of null.
Arrays are zero indexed: an array with n elements is indexed from 0 to n-1.
Array elements can be of any type, including an array type.
Array types are reference types derived from the abstract base type Array. All arrays implement IList and IEnumerable. You can use the foreach statement to iterate through an array. Single-dimensional arrays also implement IList<T> and IEnumerable<T>.

The elements of an array can be initialized to known values when the array is created. Beginning with C# 12, all of the collection types can be initialized using a Collection expression. Elements that aren't initialized are set to the default value. The default value is the 0-bit pattern. All reference types (including non-nullable types), have the values null. All value types have the 0-bit patterns. That means the Nullable<T>.HasValue property is false and the Nullable<T>.Value property is undefined. In the .NET implementation, the Value property throws an exception.

// Declare a single-dimensional array of 5 integers.
int[] array1 = new int[5];

// Declare and set array element values.
int[] array2 = [1, 2, 3, 4, 5, 6];

// Declare a two dimensional array.
int[,] multiDimensionalArray1 = new int[2, 3];

// Declare and set array element values.
int[,] multiDimensionalArray2 = { { 1, 2, 3 }, { 4, 5, 6 } };

// Declare a jagged array.
int[][] jaggedArray = new int[6][];

// Set the values of the first array in the jagged array structure.
jaggedArray[0] = [1, 2, 3, 4];

Creating an Alias for an Array Type
You can define an alias for an array type using the using directive. For example:

using IntArray = System.Int32[];
This allows you to use IntArray as an alias for int[]:

IntArray numbers = { 1, 2, 3, 4, 5 };
Console.WriteLine(numbers[0]); // Outputs: 1

1. Single-Dimensional Arrays
Also known as one-dimensional arrays, these are the simplest form of arrays. They store elements in a linear sequence.

int[] numbers = { 1, 2, 3, 4, 5 };

2. Multidimensional Arrays
These arrays can have two or more dimensions. The most common are two-dimensional arrays, which are often used to represent matrices or tables.

int[,] matrix = new int[3, 3];
matrix[0, 0] = 1;
You can also have three-dimensional arrays and beyond.

int[,,] cube = new int[3, 3, 3];

lower bound means index by default it is Zero.
A multidimensional Array can have different bounds for each dimension. An array can have a maximum of 32 dimensions.


3. Jagged Arrays
A jagged array is an array of arrays, where each "inner" array can have a different length. This is useful for representing structures like a triangle or a ragged matrix.

int[][] jaggedArray = new int[3][];
jaggedArray[0] = new int[2];
jaggedArray[1] = new int[3];
jaggedArray[2] = new int[4];
4. Implicitly Typed Arrays
Introduced in C# 3.0, these arrays allow the compiler to infer the type of the array based on the elements provided.

var numbers = new[] { 1, 2, 3, 4, 5 }; // Inferred as int[]

The elements of the array are initialized to the default value of the element type, 0 for integers. The second declaration declares an array of strings and initializes all seven values of that array. 

Array has a fixed capacity. To increase the capacity, you must create a new Array object with the required capacity, copy the elements from the old Array object to the new one, and delete the old Array.

The array size is limited to a total of 4 billion elements, and to a maximum index of 0X7FEFFFFF in any given dimension (0X7FFFFFC7 for byte arrays and arrays of single-byte structures).

The Array is not guaranteed to be sorted. You must sort the Array prior to performing operations (such as BinarySearch) that require the Array to be sorted.

Type that can stored in Array:
Value Types: int, float, double, char, bool, structs, etc.
Reference Types: Classes, interfaces, arrays, delegates.
Object Type: Allows storing elements of any type.
Nullable Types: For value types that need to represent null values.

The array variable holds a reference to the base address of the memory block allocated for the array.
The elements are stored in contiguous memory locations starting from this base address.
The reference allows efficient access to any element in the array using its index.

address = base_address + (index * size_of_element)

Performance
Access Time: Arrays provide O(1) time complexity for accessing elements by index, making them very efficient for read and write operations.
Iteration: Iterating through an array is generally fast due to the contiguous memory allocation, which improves cache performance.
Resizing: Arrays have a fixed size, so resizing an array involves creating a new array and copying elements, which can be costly in terms of performance.
Size
Memory Allocation: The size of an array in memory is determined by the size of its elements and the number of elements. For example, an array of 10 integers (each 4 bytes) will occupy 40 bytes for the elements, plus some additional bytes for metadata.
Metadata: Arrays in C# store metadata such as the length and type information. This metadata is stored alongside the array elements in memory1.
Memory Management
Heap Allocation: Arrays are reference types, so they are allocated on the heap. The array variable holds a reference to the memory location where the array is stored.
Garbage Collection: The .NET garbage collector manages the memory for arrays. When an array is no longer referenced, the garbage collector will eventually reclaim the memory.
Avoiding Allocations: To improve performance, it's important to minimize unnecessary memory allocations. Techniques such as using List<T> for dynamic collections or ArrayPool<T> for reusing arrays can help reduce allocations2.

Default Maximum Size
32-bit Systems: The maximum size of an array is limited by the available memory and the maximum value of an int, which is 2,147,483,647 elements. However, the total size of the array is also constrained by the 2 GB object size limit.
64-bit Systems: The same 2 GB object size limit applies by default, but you can configure the runtime to allow larger objects.
Configuring for Larger Arrays
In a 64-bit environment, you can enable the gcAllowVeryLargeObjects configuration setting to allow arrays larger than 2 GB. This setting allows:

Maximum Number of Elements: Up to 4,294,967,295 elements (UInt32.MaxValue).
Maximum Index in Any Dimension: 2,147,483,591 for byte arrays and arrays of single-byte structures, and 2,146,435,071 for other types12.

**/

namespace ArrayType{
    public class ArrayType{

        public void Print1DArray(int[] args){
            Console.WriteLine("Print the Array :");
            Console.WriteLine(string.Join(" ",args));
        }

        public int[] GetListofArray(){
            Console.WriteLine("GetListOfArray method send array list");
            return new int[]{1,2,3,4,5};
        }

        public void Print2D(int[,] array){
            Console.WriteLine("Print 2D Array :");
            for(int i = 0; i<array.Rank; i++){
                for(int j = 0; j < (array.Length/array.Rank); j++){
                    Console.Write(array[i,j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static void ShowSquares(int val)
        {
            Console.WriteLine("{0:d} squared = {1:d}", val, val*val);
        }

        public void PrintJaggedArray(int[][] array){
            Console.WriteLine("Print Jagged Array :");
            for(int i = 0; i<array.Length; i++){
                for(int j = 0; j < array[i].Length; j++){
                    Console.Write(array[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
        public static void Main(){
            System.Console.WriteLine("ArrayType :");

            //Single Dimention Array
            int[] _1DArrayWithSize = new int[5];//declaration with size
            int[] _1DArrayWithOutSize = {1,2,3,4,5};
            int[] _1DArrayCollectionExpression = [1,2,3,4,5];
            int[] _1DArrayInitializer = new int[]{1,2,3,4,5};
            var _1DinferArrayType = new int[] {1,2,3,4,5};
            string[] weekDays = ["Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"];

            //multi-dimensional Array
            int[,] _2DArraywithSize = new int[2,2];
            int[,,] _3DArrayWithSize = new int[2,3,4];
            int[,] _2DArrayWithOutSize = {{1,2,3},{4,5,6}};
            int[,] _2DArrayInitializer = new int[,]{{1,2,3},{4,5,6}};
            var _2DInferArrayType = new int[,]{{1,2,3},{4,5,6}};
            int[,,] array3D = new int[,,] { { { 1, 2, 3 }, { 4,   5,  6 } },
                                { { 7, 8, 9 }, { 10, 11, 12 } } };

            //Jagged Array
            int[][] _jaggedArrayWithSize = new int[2][];
            

            Console.WriteLine("1D Array :"+ string.Join(" ",_1DArrayWithOutSize));
            foreach(int i in _1DArrayCollectionExpression){
                Console.Write(i + " ");
            }
            Console.WriteLine();

            Console.WriteLine("Multi Dimensional Array :");
            Console.WriteLine("Rank :"+ _2DInferArrayType.Rank);
            Console.WriteLine("Length :"+ _2DInferArrayType.Length);
            for(int i = 0; i<_2DInferArrayType.Rank; i++){
                for(int j = 0; j < (_2DInferArrayType.Length/_2DInferArrayType.Rank); j++){
                    Console.Write(_2DInferArrayType[i,j] + " ");
                }
                Console.WriteLine();
            }

            //Pass and Return Array as Argument and Return Type;
            ArrayType arryObj = new ArrayType();
            arryObj.Print1DArray(arryObj.GetListofArray());

            //Reference Type - Changes that effect Original Value
            var copy = _1DArrayWithOutSize;
            copy[0] = 10;
            Console.WriteLine("Copied array and Updated _1DArrayWithOutSize:");
            arryObj.Print1DArray(_1DArrayWithOutSize);
            Console.WriteLine("Copied array and Updated copy:");
            arryObj.Print1DArray(copy);

            //multi dimention accessing the declared array
            arryObj.Print2D(_2DArraywithSize);//Only declared with size and default value will be assigned by new keywork or CLR;
            _2DArraywithSize[0,0] = 10;
            _2DArraywithSize[0,1] = 20;
            _2DArraywithSize[1,0] = 20;
            _2DArraywithSize[1,1] = 10;
            arryObj.Print2D(_2DArraywithSize);

            //jagged array
            _jaggedArrayWithSize[0] = new int[]{10,20,30};
            _jaggedArrayWithSize[1] = new int[]{100,200};
            Console.WriteLine("Print Jagged :");
            arryObj.PrintJaggedArray(_jaggedArrayWithSize);

            //Implicit Typed Array - Type of element in array is inferred while compiling. using new[] declaration.
            var inferred1DArray = new[] {23,24,25,26,27};
            arryObj.Print1DArray(inferred1DArray);
            int[][] c =
            [
                [1,2,3,4],
                [5,6,7,8]
            ];

            // jagged array of strings
            string[][] d =
            [
                ["Luca", "Mads", "Luke", "Dinesh"],
                ["Karen", "Suma", "Frances"]
            ];
            arryObj.PrintJaggedArray(c);
            Console.WriteLine();

            object[] anyTypeArray = new object[2];
            anyTypeArray[0] = 2;
            anyTypeArray[1] = "navaneethan";
            Console.WriteLine(string.Join(" - ",anyTypeArray ));

            //Array Properties
            Console.WriteLine("Isfixed Size :"+ _1DArrayWithOutSize.IsFixedSize);
            Console.WriteLine("IsReadOnly :"+ _1DArrayWithOutSize.IsReadOnly);
            Console.WriteLine("Max Length :"+_1DArrayWithOutSize.Length );
            Console.WriteLine("IsSynconization :"+_1DArrayWithOutSize.IsSynchronized);
            Console.WriteLine("Rank :"+_2DInferArrayType.Rank);

            //Methods
            Array.Sort(_1DArrayCollectionExpression);
            Console.WriteLine("Sorted Array :"+string.Join(" ", _1DArrayCollectionExpression));
            Console.WriteLine("Binary Search :"+  Array.BinarySearch(_1DArrayCollectionExpression,4));
            Array.Clear(_1DArrayCollectionExpression);
            Console.WriteLine("Length of Array after Cleared the array :"+ _1DArrayCollectionExpression.Length);

            // Creates and initializes a one-dimensional Array of type int.
            //Initializes a new instance of the Array class.
            Array my1DArray=Array.CreateInstance( typeof(int), 5 );
            Console.WriteLine(my1DArray.Length);

            //CopyTo Method
            _1DArrayWithOutSize.CopyTo(_1DArrayWithSize,0);//Copies all the elements of the current one-dimensional array to the specified one-dimensional array starting at the specified destination array index. The index is specified as a 32-bit integer.
            arryObj.Print1DArray(_1DArrayWithSize);
            Console.WriteLine("Above is the CopyTo Method to uninitialized Array");

            //Equal
            Console.WriteLine("Equal :"+ _1DArrayWithSize.Equals(_1DArrayWithOutSize));
            System.Console.WriteLine("Static Equals" + ArrayType.Equals(_1DArrayWithSize,_1DArrayWithOutSize));
            //Determines whether the specified object instances are considered equal.

            //Fill
            Array.Fill(_1DArrayWithSize,5);
            Console.WriteLine("Print the Fill Methods:");
            arryObj.Print1DArray(_1DArrayWithSize);

            //Find
            Console.WriteLine("Find Method:");
            Console.WriteLine(Array.Find(_1DArrayWithOutSize,x => x>3));//Searches for an element that matches the conditions defined by the specified predicate, and returns the first occurrence within the entire Array.
            Console.WriteLine("Find All :"+string.Join(" ",Array.FindAll(_1DArrayWithOutSize,x => x>3)));//Retrieves all the elements that match the conditions defined by the specified predicate.

            Action<int> action = new Action<int>(ShowSquares);
            
            //Foreach Apply Action on each element
            Console.WriteLine("Foreach Action Apply :");
            Array.ForEach(_1DArrayWithSize,action);

            //findIndex
            Console.WriteLine("FindIndex :"+ Array.FindIndex(_1DArrayWithOutSize,x => x>3));
            //Searches for an element that matches the conditions defined by the specified predicate, and returns the zero-based index of the first occurrence within the entire Array.

            //FindLast
            Console.WriteLine("FindLast :"+ Array.FindLast(_1DArrayWithSize, x => x==5));//Searches for an element that matches the conditions defined by the specified predicate, and returns the last occurrence within the entire Array.
            Console.WriteLine("FindLastIndex :" + Array.FindLastIndex(_1DArrayWithSize, x => x == 5));//Searches for an element that matches the conditions defined by the specified predicate, and returns the zero-based index of the last occurrence within the entire Array

            //Enumerator
            String[] myArr = new String[10];
            myArr[0] = "The";
            myArr[1] = "quick";
            myArr[2] = "brown";
            myArr[3] = "fox";
            myArr[4] = "jumps";
            myArr[5] = "over";
            myArr[6] = "the";
            myArr[7] = "lazy";
            myArr[8] = "dog";
            // Displays the values of the Array.
            int ii = 0;
            System.Collections.IEnumerator myEnumerator = myArr.GetEnumerator();
            Console.WriteLine( "The Array contains the following values from enumerator:" );
            while (( myEnumerator.MoveNext() ) && ( myEnumerator.Current != null )){
                Console.WriteLine( "[{0}] {1}", ii++, myEnumerator.Current );
            }

            Console.WriteLine("HashCode :"+_1DArrayWithSize.GetHashCode());
            Console.WriteLine("Type of Instance :"+_1DArrayWithSize.GetType());

            Console.WriteLine("GetLength Methods :"+ _2DArrayWithOutSize.GetLength(1));//An example of GetLength is GetLength(0), which returns the number of elements in the first dimension of the Array.
            //Get Length of specified dimention
            //This method is an O(1) operation.

            //LowerBound - get first occurance of specified dimension
            Console.WriteLine("LowerBound :"+_2DInferArrayType.GetLowerBound(1));
            //The index of the first element of the specified dimension in the array.
            //This method is an O(1) operation.

            //Upper
            Console.WriteLine("UpperBound :"+_2DInferArrayType.GetUpperBound(1));
            //Gets the index of the last element of the specified dimension in the array.
            //This method is an O(1) operation.

            //GetValue - Gets the value of the specified element in the current Array.
            Console.WriteLine("GetValue :"+_1DinferArrayType.GetValue(1));//1D
            Console.WriteLine("GetValue 2D :"+_2DArrayWithOutSize.GetValue(1,1));//2D
            Console.WriteLine("GetValue 3D :"+array3D.GetValue(1,1,1));//3D

            //IndexOf
            Console.WriteLine("IndexOf :"+ Array.IndexOf(_1DArrayWithOutSize,3));//1D - The index of the first occurrence of value in array, if found; otherwise, the lower bound of the array minus 1.

            _2DArraywithSize.Initialize();//Initialize - Initializes every element of the value-type Array by calling the parameterless constructor of the value type.

            Console.WriteLine("LastIndexOf :"+Array.LastIndexOf(_1DArrayWithSize,5));//Searches for the specified object and returns the index of the last occurrence within the entire one-dimensional Array.

            //Resize
            String[] myArrResize = {"The", "quick", "brown", "fox", "jumps",
            "over", "the", "lazy", "dog"};
            Console.WriteLine("Resize the Array :"+ string.Join(" ", myArrResize));
            Array.Resize(ref myArrResize,4);
            Console.WriteLine("After Resize the Array :"+ string.Join(" ", myArrResize));
            //This method allocates a new array with the specified size, copies elements from the old array to the new one, and then replaces the old array with the new one.
            //array must be a one-dimensional array.

            // If array is null, this method creates a new array with the specified size.

            // If newSize is greater than the Length of the old array, a new array is allocated and all the elements are copied from the old array to the new one. If newSize is less than the Length of the old array, a new array is allocated and elements are copied from the old array to the new one until the new one is filled; the rest of the elements in the old array are ignored. If newSize is equal to the Length of the old array, this method does nothing.

            // This method is an O(n) operation, where n is newSize.

            //Reverse
            Array.Reverse(_1DinferArrayType);
            System.Console.WriteLine("Reverse Arrays :");
            arryObj.Print1DArray(_1DinferArrayType);

            //SetValue 
            _1DArrayWithSize.SetValue(4,2);//1D
            Console.WriteLine("Value that set before in 1D :"+_1DArrayWithSize.GetValue(2));//1D
            _2DArraywithSize.SetValue(55,1,1);//2D
            arryObj.Print2D(_2DArraywithSize);
            // _jaggedArrayWithSize.SetValue(66,1,1,1);//3D
            // arryObj.PrintJaggedArray(_jaggedArrayWithSize);

            System.Console.WriteLine("ToString :"+_1DArrayWithSize.ToString());
            Console.WriteLine("TrueForALl :"+Array.TrueForAll(_1DinferArrayType, x => x>1));

        
        }
    }
}