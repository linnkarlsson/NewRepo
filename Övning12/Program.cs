using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace övning_12
{
    public struct Person
    {
        public string firstName;
        public string phoneNumber;
        public string email;
        //hallå hej
    }


    class Program
    {
        private static bool FindName(Person[] myList, string name)//metoden steg 1, letar upp om namnet finns.
        {
            bool result = false;
            {
                for (int i = 0; i < myList.Length; i++)
                {
                    if (myList[i].firstName == name)
                    {
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }
        private static int FindIndex(Person[] myList, string name)//finns namnet så kollar findindex efter vilket index namnet finns på.
        {
            int result = -1;

            for (int i = 0; i < myList.Length; i++)
            {
                if (myList[i].firstName == name)
                {
                    result = i;
                    break;
                }
            }

            return result;
        }
        private static Person[] RemoveName(Person[] myList, string name)//metod för att radera indexet där namnet finns.
        {
            Person[] newNames = myList;

            if (FindName(myList, name))
            {
                int IndexToRemove = FindIndex(myList, name);
                if (IndexToRemove >= 0 && IndexToRemove < myList.Length - 1)
                {
                    newNames = new Person[myList.Length];//här töms newNames

                    int counter = 0;
                    for (int i = 0; i < myList.Length; i++)
                    {
                        if (IndexToRemove != i)//så länge det inte är samma som i
                        {
                            newNames[counter] = myList[i];//kopierar
                            counter++;//loopar igen
                        }
                    }
                }

            }
            else
            {
                Console.WriteLine($"Namn {name} finns inte i listan");
            }
            return newNames;//returnerar den nya listan utan namnet vi har raderat.
        }
        private static Person[] AddName(Person[] myList, string name, string phoneNumber, string email)
        {
            Person[] newList = new Person[myList.Length + 1];

            for (int i = 0; i < myList.Length; i++)
            {
                newList[i] = myList[i];
            }
            Person newPerson = new Person();
            newPerson.firstName = name;
            newPerson.phoneNumber = phoneNumber;
            newPerson.email = email;
            newList[newList.Length - 1] = newPerson;

            return newList;

        }
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                MartinsMetod();
            }
            Person[] myList = new Person[2];

            Person tmp = new Person();

            tmp.firstName = "Linn";
            tmp.phoneNumber = "0768588030";
            tmp.email = "linn_karlsson92@hotmail.com";
            myList[0] = tmp;

            tmp.firstName = "Nina";
            tmp.phoneNumber = "0768588030";
            tmp.email = "ninizzzz@hotmail.com";
            myList[1] = tmp;

            for (int i = 0; i < myList.Length; i++)
            {
                Console.WriteLine($"{myList[i].firstName} {myList[i].phoneNumber} {myList[i].email}");
            }

            Console.WriteLine("Din nya lista: ");
            myList = AddName(myList, "Hanna", "075", "blabla");
            for (int i = 0; i < myList.Length; i++)
            {
                Console.WriteLine($"{myList[i].firstName} {myList[i].phoneNumber} {myList[i].email}");
            }

            Console.WriteLine("Efter vi raderat ser listan ut som följande: ");
            myList = RemoveName(myList, "Nina");
            for (int i = 0; i < myList.Length; i++)
            {
                Console.WriteLine($"{myList[i].firstName} {myList[i].phoneNumber} {myList[i].email}");
            }

        }

        public static void MartinsMetod()
        {
            Console.WriteLine("Martin är bäst");
        }
    }
}
