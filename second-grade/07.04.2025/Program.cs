using System;
using System.Collections.Generic;

public class GenericList<T>
{
  List<T> items = new List<T>();

  public void Add(T item)
  {
    items.Add(item);
    Console.WriteLine($"Элемент {item} добавлен");
  }

  public void Remove(int index)
  {
    if (index >= 0 && index < items.Count)
    {
      items.RemoveAt(index);
      Console.WriteLine("Элемент удален");
    }
    else
    {
      Console.WriteLine("Неверный индекс");
    }
  }

  public T GetItem(int index)
  {
    if (index >= 0 && index < items.Count)
    {
      return items[index];
    }
    else
    {
      throw new IndexOutOfRangeException("Неверный индекс");
    }
  }

  public int Count()
  {
    return items.Count;
  }
}

class Program
{
  static void Main()
  {
    GenericList<string> stringList = new GenericList<string>();
    stringList.Add("text1");
    stringList.Add("text2");

    Console.WriteLine("Элемент по индексу 0: " + stringList.GetItem(0));

    stringList.Remove(1);

    GenericList<int> intList = new GenericList<int>();
    intList.Add(1);
    intList.Add(2);
    Console.WriteLine("Элемент по индексу 1: " + intList.GetItem(1));
  }
}