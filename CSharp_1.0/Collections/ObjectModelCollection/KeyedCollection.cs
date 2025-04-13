using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
/**
Provides the abstract base class for a collection whose keys are embedded in the values.

The KeyedCollection<TKey,TItem> class provides both O(1) indexed retrieval and keyed retrieval that approaches O(1). It is an abstract type, or more accurately an infinite set of abstract types, because each of its constructed generic types is an abstract base class. To use KeyedCollection<TKey,TItem>, derive your collection type from the appropriate constructed type.

The KeyedCollection<TKey,TItem> class is a hybrid between a collection based on the IList<T> generic interface and a collection based on the IDictionary<TKey,TValue> generic interface. Like collections based on the IList<T> generic interface, KeyedCollection<TKey,TItem> is an indexed list of items. Like collections based on the IDictionary<TKey,TValue> generic interface, KeyedCollection<TKey,TItem> has a key associated with each element.

Unlike dictionaries, an element of KeyedCollection<TKey,TItem> is not a key/value pair; instead, the entire element is the value and the key is embedded within the value. For example, an element of a collection derived from KeyedCollection\<String,String> (KeyedCollection(Of String, String) in Visual Basic) might be "John Doe Jr." where the value is "John Doe Jr." and the key is "Doe"; or a collection of employee records containing integer keys could be derived from KeyedCollection\<int,Employee>. The abstract GetKeyForItem method extracts the key from the element.

By default, the KeyedCollection<TKey,TItem> includes a lookup dictionary that you can obtain with the Dictionary property. When an item is added to the KeyedCollection<TKey,TItem>, the item's key is extracted once and saved in the lookup dictionary for faster searches. This behavior is overridden by specifying a dictionary creation threshold when you create the KeyedCollection<TKey,TItem>. The lookup dictionary is created the first time the number of elements exceeds that threshold. If you specify -1 as the threshold, the lookup dictionary is never created.

When the internal lookup dictionary is used, it contains references to all the items in the collection if TItem is a reference type, or copies of all the items in the collection if TItem is a value type. Thus, using the lookup dictionary may not be appropriate if TItem is a value type.

You can access an item by its index or key by using the Item[] property. You can add items without a key, but these items can subsequently be accessed only by index.

**/
namespace ObjectModelCollections{
    public class SimpleOrder : KeyedCollection<int, OrderItem>
    {

        // This is the only method that absolutely must be overridden,
        // because without it the KeyedCollection cannot extract the
        // keys from the items. The input parameter type is the
        // second generic type argument, in this case OrderItem, and
        // the return value type is the first generic type argument,
        // in this case int.
        //
        protected override int GetKeyForItem(OrderItem item)
        {
            // In this example, the key is the part number.
            return item.PartNumber;
        }
    }

    // This class represents a simple line item in an order. All the
    // values are immutable except quantity.
    //
    public class OrderItem
    {
        public readonly int PartNumber;
        public readonly string Description;
        public readonly double UnitPrice;

        private int _quantity = 0;

        public OrderItem(int partNumber, string description,
            int quantity, double unitPrice)
        {
            this.PartNumber = partNumber;
            this.Description = description;
            this.Quantity = quantity;
            this.UnitPrice = unitPrice;
        }

        public int Quantity
        {
            get { return _quantity; }
            set
            {
                if (value<0)
                    throw new ArgumentException("Quantity cannot be negative.");

                _quantity = value;
            }
        }

        public override string ToString()
        {
            return String.Format(
                "{0,9} {1,6} {2,-12} at {3,8:#,###.00} = {4,10:###,###.00}",
                PartNumber, _quantity, Description, UnitPrice,
                UnitPrice * _quantity);
        }
    }

    class KeyedCollections{
        public static void Main(){
            Console.WriteLine("Keyed Collections.");
            SimpleOrder weekly = new SimpleOrder();

        // The Add method, inherited from Collection, takes OrderItem.
        //
            weekly.Add(new OrderItem(110072674, "Widget", 400, 45.17));
            weekly.Add(new OrderItem(110072675, "Sprocket", 27, 5.3));
            weekly.Add(new OrderItem(101030411, "Motor", 10, 237.5));
            weekly.Add(new OrderItem(110072684, "Gear", 175, 5.17));

            Display(weekly);

            // The Contains method of KeyedCollection takes the key,
            // type, in this case int.
            //
            Console.WriteLine("\nContains(101030411): {0}",
                weekly.Contains(101030411));

            // The default Item property of KeyedCollection takes a key.
            //
            Console.WriteLine("\nweekly[101030411].Description: {0}",
                weekly[101030411].Description);

            // The Remove method of KeyedCollection takes a key.
            //
            Console.WriteLine("\nRemove(101030411)");
            weekly.Remove(101030411);
            Display(weekly);

            // The Insert method, inherited from Collection, takes an
            // index and an OrderItem.
            //
            Console.WriteLine("\nInsert(2, New OrderItem(...))");
            weekly.Insert(2, new OrderItem(111033401, "Nut", 10, .5));
            Display(weekly);

            // The default Item property is overloaded. One overload comes
            // from KeyedCollection<int, OrderItem>; that overload
            // is read-only, and takes Integer because it retrieves by key.
            // The other overload comes from Collection<OrderItem>, the
            // base class of KeyedCollection<int, OrderItem>; it
            // retrieves by index, so it also takes an Integer. The compiler
            // uses the most-derived overload, from KeyedCollection, so the
            // only way to access SimpleOrder by index is to cast it to
            // Collection<OrderItem>. Otherwise the index is interpreted
            // as a key, and KeyNotFoundException is thrown.
            //
            Collection<OrderItem> coweekly = weekly;
            Console.WriteLine("\ncoweekly[2].Description: {0}",
                coweekly[2].Description);

            Console.WriteLine("\ncoweekly[2] = new OrderItem(...)");
            coweekly[2] = new OrderItem(127700026, "Crank", 27, 5.98);

            OrderItem temp = coweekly[2];

            // The IndexOf method inherited from Collection<OrderItem>
            // takes an OrderItem instead of a key
            //
            Console.WriteLine("\nIndexOf(temp): {0}", weekly.IndexOf(temp));

            // The inherited Remove method also takes an OrderItem.
            //
            Console.WriteLine("\nRemove(temp)");
            weekly.Remove(temp);
            Display(weekly);

            Console.WriteLine("\nRemoveAt(0)");
            weekly.RemoveAt(0);
            Display(weekly);
        }
        private static void Display(SimpleOrder order)
        {
            Console.WriteLine();
            foreach( OrderItem item in order )
            {
                Console.WriteLine(item);
            }
        }
    }
}