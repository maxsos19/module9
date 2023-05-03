using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itogi96
{
    class InvalidInputException : Exception
    {
        public InvalidInputException() : base("Ошибка ввода. Необходимо ввести 1 или 2.") { }
    }
    class Person
    {
        public string Surname { get; set; }

        public override string ToString()
        {
            return Surname;
        }
    }
    class PeopleList
    {
        private List<Person> _list = new List<Person>();

        public event EventHandler Sorted;

        public int Count
        {
            get { return _list.Count; }
        }

        public void Add(Person person)
        {
            _list.Add(person);
        }

        public void SortAscending()
        {
            _list.Sort((p1, p2) => p1.Surname.CompareTo(p2.Surname));
            OnSorted();
        }

        public void SortDescending()
        {
            _list.Sort((p1, p2) => p2.Surname.CompareTo(p1.Surname));
            OnSorted();
        }

        protected virtual void OnSorted()
        {
            EventHandler handler = Sorted;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                PeopleList people = new PeopleList();
                people.Sorted += People_Sorted;

                while (true)
                {
                    Console.Write("Введите фамилию или команду (1 - сортировка А-Я, 2 - сортировка Я-А): ");
                    string input = Console.ReadLine().Trim();

                    try
                    {
                        int command = int.Parse(input);
                        if (command == 1)
                        {
                            people.SortAscending();
                        }
                        else if (command == 2)
                        {
                            people.SortDescending();
                        }
                        else
                        {
                            throw new InvalidInputException();
                        }
                    }
                    catch (InvalidInputException e)
                    {
                        Console.WriteLine("Ошибка: " + e.Message);
                    }
                    catch (Exception)
                    {
                        people.Add(new Person { Surname = input });
                        Console.WriteLine("Добавлено: " + input);
                    }

                    Console.WriteLine("Список: " + people);
                }
            }

            private static void People_Sorted(object sender, EventArgs e)
            {
                Console.WriteLine("Список отсортирован.");
            }
        }
    }
}
