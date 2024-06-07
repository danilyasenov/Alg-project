using System;
class Program
{

}
class Translator
{

}
public class Hashtable
{
    private const int _InitCapacity = 10;
    private LinkedList<Item>[] buckets;
    private int _count;
    private int _capacity;

    public int Count => _count;

    public Hashtable()
    {
        _capacity = _InitCapacity;
        buckets = new LinkedList<Item>[_capacity];
        _count = 0;
    }

    private int GetIndex(string key)
    { 
    }

    private int GetHashCode(string key) 
    { 
    }

    public bool Add(string key,string value)
    { 
    }

    public bool Remove(string key)
    {

    }

    public bool ContainKey(string key)
    {

    }

    public string GetValue(string key)
    {

    }

    private void IncreaseCapacity()
    {

    }

}

public class Item
{
    public string Key { get; }
    public string Value { get; }

    public Item(string key, string value)
    {
        Key = key;
        Value = value;
    }


}
