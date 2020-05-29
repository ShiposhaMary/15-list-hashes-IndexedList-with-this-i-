using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexedList_with_this_i_
{
    public partial class MyList<T> : IEnumerable<T>
    {
        public T[] collection;
        int count = 0;
        public MyList()
        {
            collection = new T[100];
        }
        void Enlarge()
        {
            throw new NotImplementedException();
        }
        public void Add(T value)
        {
            if (count == collection.Length)
                Enlarge();
            collection[count++] = value;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
                yield return collection[i];
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= count) throw new IndexOutOfRangeException();
                return collection[index];
            }
            set
            {
                if (index < 0 || index >= count) throw new IndexOutOfRangeException();
                collection[index] = value;
            }
        }
        public int Count { get { return count; } }
        public bool Contains(T value)                                   //Пишем метод сравнения через virtual метод
        {                                                                // Equals.        
            for (int i = 0; i < count; i++)                                    
                if (collection[i].Equals(value)) return true;                                      
            return false;
        }
    }

    public class Program
    {
        public static void Main()
        {
            var list = new MyList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            foreach (var e in list)
                Console.WriteLine(e);
            Console.WriteLine();
            for (int i = 0; i < list.Count; i++)                 
              Console.WriteLine("'"+i+"'" +"="+ list[i]);                               
   //Возможно благодаря
   // переназначению функции this.  
            Console.ReadKey();
        }
    }

}
