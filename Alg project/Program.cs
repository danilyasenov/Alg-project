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
        return GetHashCode(key) % _capacity;
    }

    private int GetHashCode(string key) 
    {
        int hashcode = 0;
        foreach(char c in key)
        {
            hashcode += c;
        }
        return hashcode;
    }

    public bool Add(string key,string value)
    {
        if (ContainKey(key)) { return false; }

        int bucketInd = GetIndex(key);

        if (buckets[bucketInd] == null)
        {
            buckets[bucketInd] = new LinkedList<Item>();
        }
        buckets[bucketInd].AddLast(new Item(key, value));
        _count++;
        return true;
    }

    public bool Remove(string key)
    {

    }
    public bool ContainKey(string key)
    {
        int bucketInd = GetIndex(key);

        if (buckets[bucketInd] != null)
        {
            foreach(var Item in buckets[bucketInd])
            {
                if (Item.Key.Equals(key))
                {
                    return true;
                }
            }
        }
        return false;

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
