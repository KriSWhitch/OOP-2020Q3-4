using System;
using System.Collections.Generic;

namespace _8_5
{
    class TextFormatter : IComparable, IEquatable<String>
    {
        public string str;
        public TextFormatter()
        {
            str = "";
        }

        public TextFormatter(string str)
        {
            this.str = str;
        }

        public (int sumOfPoints, int sumOfComma) Count()
        {
            var result = (sumOfComma: 0, sumOfPoints: 0);
            char[] inputStringToChar = str.ToCharArray();
            for (var i = 0; i < inputStringToChar.Length; i++)
            {
                if (inputStringToChar[i] == ',')
                {
                    result.sumOfComma++;
                }

                if (inputStringToChar[i] == '.')
                {
                    result.sumOfPoints++;
                }

            }
            return result;
        }


        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            TextFormatter otherString = obj as TextFormatter;
            if (otherString != null)
                return (this.str.ToCharArray()[1]).CompareTo(otherString.str.ToCharArray()[1]);
            else
                throw new ArgumentException("Object is not a String");
        }

        public bool Equals(string str)
        {
            return (this.str.ToCharArray()[0] == str.ToCharArray()[0]);
        }

        public static int Compare(Object x, Object y)
        {
            if (x.ToString().Length == y.ToString().Length)
                return string.Compare(x.ToString(), y.ToString());
            else if (x.ToString().Length > y.ToString().Length)
                return 1;
            else
                return -1;
        }

        public List<String> SplitText()
        {
            string[] strArray = str.Split(',');
            List <String> stringList = new List<String>();
            for (var i = 0; i < strArray.Length; i++)
            {
                stringList.Add(strArray[i]);
            }
            stringList.Sort(Compare);
            return stringList;
        }

    }


    class Book<T>
    {
        public class List<T>
        {
            public T[] array;
            public List() 
            {
                array = new T[] { };
            }

            public List(T[] array)
            {
                this.array = array;
            }

            public void AppendToEnd(T value)
            {
                T[] result = new T[array.Length + 1];
                result[result.Length - 1] = value;
                for (int i = array.Length - 1; i >= 0; i--)
                {
                    result[i] = array[i];
                }
                this.array = result;
            }

            public void RemoveFromEnd()
            {
                if (array.Length == 0) throw new Exception("В массиве должен быть хотя бы один элемент!");
                T[] result = new T[array.Length - 1];
                for (int i = 0; i < array.Length - 1; i++)
                    result[i] = array[i];
                this.array = result;
            }

            int CountElementsInList()
            {
                return array.Length;
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            TextFormatter obj1 = new TextFormatter(".csda,af.sd.,.asdfaasdf,asdfasdfas,freoklv,cplv");
            Console.WriteLine(obj1.Count());
            List<String> list1 = obj1.SplitText();

            foreach (string el in list1)
            {
                Console.WriteLine(el);
            }

            TextFormatter obj2 = new TextFormatter(",asdfasdfas,freoklv,cplv");
            TextFormatter obj3 = new TextFormatter(".csda,af.sdasdfasdfas,freoklv,cplv");
            TextFormatter obj4 = new TextFormatter(".csasdfaasdf,asdfasdfas,freoklv,cplv");
            TextFormatter[] objArray = new TextFormatter[] {obj1, obj2, obj3, obj4 };
            Book<TextFormatter>.List<TextFormatter> listik = new Book<TextFormatter>.List<TextFormatter>(objArray);
            listik.RemoveFromEnd();
            foreach(var el in listik.array)
            {
                Console.WriteLine(el.str);
            }
        }
    }
}