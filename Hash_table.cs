

using System;
using System.Collections.Generic;
namespace hastable
{
    public class hashtable_mosh
    {
        private class Entry
        {
            public int key;
            public int value;
            public Entry(int key, int value)
            {
                this.key = key;
                this.value = value;
            }
        }
        private LinkedList<Entry>[] entries;
        public hashtable_mosh(int size)
        {
            entries = new LinkedList<Entry>[size];
        }
        public void put(int key, int value)
        {
            var index = hash(key);
            if (entries[index] == null)
            {
                entries[index] = new LinkedList<Entry>();
            }
            foreach (var e in entries[index])
            {
                if (key == e.key)
                {
                    e.value = value;
                    return;
                }
            }
            entries[index].AddLast(new Entry(key, value));
        }
        public int get(int key)
        {
            key = hash(key);
            if (entries[key] != null)
            {
                foreach (var e in entries[key])
                {
                    if (key == e.key)
                    {
                        return e.value;
                    }
                }
            }
            Console.WriteLine("no elemnet found");
            return -1;
        }
        private int hash(int key)
        {

            return key % entries.Length;
        }
        public void remove(int key)
        {
            key = hash(key);
            if (entries[key] != null)
            {
                foreach (var i in entries[key])
                {
                    if (key == i.key)
                    {
                        entries[key].Remove(i);
                        return;
                    }
                }
            }
            Console.WriteLine("no element found in hashtable");
        }
        public bool check(int key)
        {
            return entries[key] == null;
        }
    }
    public class Hashtable_abd<T>
    {
        List<LinkedList<T>> value = new List<LinkedList<T>>();
        int[] key = new int[10];

        public Hashtable_abd(int size)
        {
            for (int count = 0; count < size; count++)
            {
                value.Add(new LinkedList<T>());
            }
        }
        private int hash(int i)
        {
            return i % key.Length;
        }
        public void put(int key1, T value1)
        {
            key1 = hash(key1);
            if (value[key1].Contains(value1))
            {
                return;
            }
            value[key1].AddLast(value1);
        }
        public LinkedList<T> get(int key1)
        {
            key1 = hash(key1);
            return value[key1];
        }
        public void revmove(int key)
        {
            if (full(key) || value[key].Count == 0)
            {
                Console.WriteLine("no element to remove");
                return;
            }
            value[key].RemoveFirst();
        }
        private bool full(int key1)
        {
            return (key1 >= key.Length || key1 < 0);
        }
    }
    public static class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[4];
            var unique1 = new Hashtable_abd<int>(4);
            array[0] = 2;
            array[1] = 7;
            array[2] = 11;
            array[3] = 15;
            twosum(array, 9, unique1);
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("(");
                foreach (var j in unique1.get(i))
                {
                    Console.Write(j + " ");
                }
                Console.WriteLine(")");
            }
        }
        static void twosum(int[] array, int target, Hashtable_abd<int> abd)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int count = i + 1; count < array.Length; count++)
                {
                    if (Math.Abs(array[i] + array[count]) == target)
                    {
                        abd.put(i, i);
                        abd.put(i, count);
                    }
                }
            }
        }
        static void Uniqueepair(int[] array, int target, Hashtable_abd<int> unique1)
        {
            int count = 0;
            for (int i = 0; i < 7; i++)
            {
                for (count = i + 1; count < 7; count++)
                {
                    if (Math.Abs(array[i] - array[count]) == target)
                    {
                        unique1.put(i, array[count]);
                    }
                }
            }
        }
        static char Most_Repeted(string line)
        {
            Dictionary<char, int> pairs = new Dictionary<char, int>();
            foreach (char c in line)
            {
                if (pairs.ContainsKey(c))
                {
                    pairs[c]++;
                }
                else
                {
                    pairs[c] = 0;
                }
            }
            int high = 0;
            char word = ' ';
            foreach (KeyValuePair<char, int> c in pairs)
            {
                if (c.Value > high)
                {
                    word = c.Key;
                    high = c.Key;
                }
            }
            return word;
        }
        static char Repeted(string line)
        {
            Dictionary<char, int> pairs = new Dictionary<char, int>();
            foreach (char c in line)
            {
                if (pairs.ContainsKey(c))
                {
                    pairs[c]++;
                }
                else
                {
                    pairs[c] = 0;
                }
            }
            foreach (KeyValuePair<char, int> c in pairs)
            {
                if (c.Value == 1)
                {
                    return c.Key;
                }
            }
            return ' ';
        }
        static char fist_repeted(string line)
        {
            HashSet<int> pairs = new HashSet<int>();
            foreach (char c in line)
            {
                if (pairs.Contains(c))
                {
                    return c;
                }
                pairs.Add(c);
            }
            return char.MinValue;
        }

    }
}
