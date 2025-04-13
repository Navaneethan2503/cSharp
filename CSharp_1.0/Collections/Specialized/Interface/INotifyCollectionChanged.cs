using System;
using System.Collections.Specialized;
/**
Notifies listeners of dynamic changes, such as when an item is added and removed or the whole list is cleared.

public interface INotifyCollectionChanged

You can enumerate over any collection that implements the IEnumerable interface. However, to set up dynamic bindings so that insertions or deletions in the collection update the UI automatically, the collection must implement the INotifyCollectionChanged interface. This interface exposes the CollectionChanged event that must be raised whenever the underlying collection changes.

WPF provides the ObservableCollection<T> class, which is a built-in implementation of a data collection that exposes the INotifyCollectionChanged interface. For an example, see How to: Create and Bind to an ObservableCollection.

The individual data objects within the collection must satisfy the requirements described in the Binding Sources Overview.

Before implementing your own collection, consider using ObservableCollection<T> or one of the existing collection classes, such as List<T>, Collection<T>, and BindingList<T>, among many others.

If you have an advanced scenario and want to implement your own collection, consider using IList, which provides a non-generic collection of objects that can be individually accessed by index and provides the best performance.

Events:
--------
CollectionChanged - Occurs when the collection changes.

**/
namespace INotifyCollections{
    class INotifyCollectionsClass{
        public static void Main(){
            Console.WriteLine("INotify Collections ");
        }
    }
}