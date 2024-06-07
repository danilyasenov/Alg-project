using System;
class Program
{

}
class Translator
{
    private Hashtable _translations;

    public Translator()
    {
        _translations = new Hashtable();
    }

    public bool Add(string word, string translation)
    {
        return _translations.Add(word, translation);
    }

    public bool Remove(string word)
    {
        return _translations.Remove(word);
    }

    public bool Contains(string word)
    {
        return _translations.ContainKey(word);
    }

    public string translate(string word)
    {
        try
        {
            return _translations.GetValue(word);
        }
        catch(KeyNotFoundException e)
        {
            return "Net takogo slova / Нет такого слова!";
        }

    }

    public void ClearTranslations()
    {
        _translations = new Hashtable();
    }

    public string TranslateSentence(string sentece)
    {
        string[] words = sentece.Split(' ');
        string translated = "";
        foreach( var word in words)
        {
            if (_translations.ContainKey(word))
            {
                translated += translate(word);
            }
            else
            {
                translated += "unknown words ";
            }
        }
        return translated;
    }
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

        IncreaseCapacity();

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
        int Index = GetIndex(key);
        if (buckets[Index]!= null)
        {
            var bucket = buckets[Index];
            var node = bucket.First;
            while(node != null)
            {
                if (node.Value.Key.Equals(key))
                {
                    bucket.Remove(node);
                    _count--;
                    return true;
                }
                node = node.Next;
            }
        }
        return false;
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
        int Index = GetIndex(key);

        if (buckets[Index] != null)
        {
            foreach (var item in buckets[Index])
            {
                if (item.Key.Equals(key))
                {
                    return item.Value;
                }
            }
        }

        throw new KeyNotFoundException($"The key '{key}' was not found in the hash table.");
    }

    private void IncreaseCapacity()
    {
        if(_count >= _capacity)
        {
            _capacity *= 2;
            LinkedList<Item>[] temp = new LinkedList<Item>[_capacity];

            foreach(var bucket in buckets)
            {
                if (bucket != null)
                {
                    foreach (var item in bucket)
                    {
                        int newBucketIndex = GetIndex(item.Key);
                        if (temp[newBucketIndex] == null)
                        {
                            temp[newBucketIndex] = new LinkedList<Item>();

                        }
                        temp[newBucketIndex].AddLast(item);
                    }
                }
            }
            buckets = temp;

        }
        return;
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
