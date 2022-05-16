using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqSnippets
{
    public class Snippets
    {
        static public void BasicLinQ()
        {
            string[] cars =
            {
                "VW Golf",
                "VW California",
                "Audi A3",
                "Audi A5",
                "Fiat Punto",
                "Seat Ibiza",
                "Seat León"
            };


            // 1. SELECT * of cars (SELECT ALL CARS)
            var carList = from car in cars select car;

            foreach (var car in carList)
            {
                Console.WriteLine(car);
            }

            // 2. SELECT WHERE car is Audi (SELECT AUDIS)
            var audiList = from car in cars where car.Contains("Audi") select car;

            foreach(var audi in audiList)
            {
                Console.WriteLine(audi);
            }

        }

        // Number Examples
        static public void LinqNumbers()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9};

            // Each Number multiplied by 3
            // Take all numbers, but 9
            // Order numers by ascending value

            var processedNumbersList =
                numbers
                    .Select(num => num * 3)
                    .Where(num => num != 9)
                    .OrderBy(num => num);
        }



        static public void SearchEamples()
        {
            List<string> textList = new List<string>
            {
                "a",
                "b",
                "c",
                "d",
                "e",
                "f",
                "g"

            };

            // 1. First of all elements
            var first = textList.First();

            // 2. First element that is "c"
            var cText = textList.First(text => text.Equals("c"));

            // 3. First element that contains "j"
            var jText = textList.First(text => text.Equals("j"));

            // 4. First element that contain "Z" or default
            var firstOrDefaultText = textList.FirstOrDefault(text => text.Contains("z")); // "" or element with "z"

            // 5. Last element that contain "Z" or default
            var lasttOrDefaultText = textList.LastOrDefault(text => text.Contains("z")); // "" or element with "z"

            // 6. Single Values
            var uniqueTexts = textList.Single();
            var uniqueOrDefaultTexts = textList.SingleOrDefault();

            int[] evenNumbers = { 0, 2, 4, 6, 8, };
            int[] otherEvenNumbers = { 0, 2, 6 };

            // Obtain { 4, 8 }
            var myEvenNumbers = evenNumbers.Except(otherEvenNumbers); 

        }



        static public void MultipleSelects()
        {
            // SELECT MANY
            string[] myOpinions =
            {
                "Opinion 1, text 1",
                "Opinion 2, text 2",
                "Opinion 3, text 3",
            };

            var myOpinionSelection = myOpinions.SelectMany(opinion => opinion.Split(","));

            var enterprises = new[]
            {
                new Enterprise()
                {
                    Id = 1,
                    Name = "Enterprise 1",
                    Employees = new[]
                    {
                        new Employee
                        {
                            Id = 1,
                            Name = "Andrés",
                            Email = "andres@imaginagroup.com",
                            Salary = 3000
                        },
                        new Employee
                        {
                            Id = 2,
                            Name = "Pepe",
                            Email = "pepe@imaginagroup.com",
                            Salary = 1000
                        },
                        new Employee
                        {
                            Id = 3,
                            Name = "Juan",
                            Email = "juan@imaginagroup.com",
                            Salary = 2000
                        },
                        new Employee
                        {
                            Id = 4,
                            Name = "Juanjo",
                            Email = "juanjo@imaginagroup.com",
                            Salary = 1500
                        }
                    }
                },
                new Enterprise()
                {
                    Id = 2,
                    Name = "Enterprise 2",
                    Employees = new[]
                    {
                        new Employee
                        {
                            Id = 5,
                            Name = "Paco",
                            Email = "paco@imaginagroup.com",
                            Salary = 2800
                        },
                        new Employee
                        {
                            Id = 6,
                            Name = "Marta",
                            Email = "marta@imaginagroup.com",
                            Salary = 4000
                        },
                        new Employee
                        {
                            Id = 7,
                            Name = "Pilar",
                            Email = "pilar@imaginagroup.com",
                            Salary = 5000
                        },
                        new Employee
                        {
                            Id = 8,
                            Name = "Pablo",
                            Email = "pablo@imaginagroup.com",
                            Salary = 2500
                        }
                    }
                }


            };
         // Elementos basicos de busqueda

            // Obtain all employes of all Enterprises
            var employeeList = enterprises.SelectMany(enterprise => enterprise.Employees);

            // Know if any a list is empty
            bool hasEnterprises = enterprises.Any();

            bool hasEmployees = enterprises.Any(enterprises => enterprises.Employees.Any());

            // All enterprises at least has a employee with at least 1000$ of salary
            bool hasEmployeeWithSalaryMoreThanOrEquals1000 =
                enterprises.Any(enterprises =>
                    enterprises.Employees.Any(employee => employee.Salary >= 1000));

        }

        // Elementos complejos de busqueda
        static public void linqCollections()
        {
            var firstList = new List<string>() { "a", "b", "c" };
            var secondtList = new List<string>() { "a", "c", "d" };

            // Las 2 maneras son lo mismo pero realizadas de diferentes formas
            // INNER JOIN --> Manera 1
            var commonResult = from element in firstList
                               join secondElement in secondtList
                               on element equals secondElement
                               select new { element, secondElement };

            // INNER JOIN --> Manera 2
            var commonResult2 = firstList.Join(
                    secondtList,
                    element => element,
                    secondElement => secondElement,
                    (element, secondElement) => new { element, secondElement }
                );


            // Minuto 12 al final de la sesion 3 
            // OUTER JOIN - LEFT
            var leftOuterJoin = from element in firstList
                                join secondElement in secondtList
                                on element equals secondElement
                                into temporalList
                                from temporalElement in temporalList.DefaultIfEmpty()
                                where element != temporalElement
                                select new { Element = element };

            // manera corta de hacerlo
            var leftOuterJoin2 = from element in firstList
                                 from secondElement in secondtList.Where(s => s == element).DefaultIfEmpty()
                                 select new { Element = element, SecondElement = secondElement };

            // OUTER JOIN - Right
            var rightOuterJoin = from secondElement in secondtList
                                 join element in firstList
                                on secondElement equals element
                                into temporalList
                                from temporalElement in temporalList.DefaultIfEmpty()
                                where secondElement != temporalElement
                                select new { Element = secondElement };


            // UNION --> cogeria lo de la izquierda y derecha pero no lo del medio
            var unionList = leftOuterJoin.Union(rightOuterJoin);
        }


        // SALTAR ELEMENTOS

        static public void SkipTakeLinq()
        {
            var myList = new[]
            {
                1,2,3,4,5,6,7,8,9,10
            };

            // SKIP

            //salta del 2 en adelante
            var skipTwoFirstValues = myList.Skip(2); // { 3,4,5,6,7,8,9,10 }

            //salta los 2 del final
            var skipLastFirstValues = myList.SkipLast(2); // { 1,2,3,4,5,6,7,8 }
             
            // te da los menos de 4
            var skipWhileSmallerTan4 = myList.SkipWhile(num => num < 4); // { 5,6,7,8 }


            // TAKE 

            // obtener los 2 primeros
            var takeFirstTwoValues = myList.Take(2); // { 1,2 }

            //obtener los 2 ultimos
            var takeLastTwoValues = myList.TakeLast(2); // { 9,10 }

            //obtener los elementos menores que 4
            var takeWhileSmallerThan4 = myList.TakeWhile(num => num < 4); // { 1,2,3}
        }


        // Paging with Skip & Take
        static public IEnumerable<T> GetPage<T>(IEnumerable<T> collection, int pageNumber, int resultsPerPage)
        {
            int startIndex = (pageNumber - 1) * resultsPerPage; 
            return collection.Skip(startIndex).Take(resultsPerPage);
        }

        // Variables
        // Devuelve el numero si esta por encima de la media
        static public void LinqVariables()
        {

            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var aboveAverage = from number in numbers
                               let average = numbers.Average()
                               let nSquared = Math.Pow(number, 2)
                               where nSquared > average
                               select number;

            Console.WriteLine("Avegare: {0}", numbers.Average());

            foreach (int number in aboveAverage)
            {
                Console.WriteLine("Number: {0} Square: {1} ", number, Math.Pow(number, 2));
            }

        }

        // ZIP
        static public void ZipLinq()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };
            string[] stringNumbers = { "one", "two", "three", "four", "five" };

            IEnumerable<string> zipNumbers = numbers.Zip(stringNumbers, (number, word) => number + "=" + word);

            // { "1=one", "2=two", ... }
        }

        // Repeat & Range
        static public void repeatRangeLinq()
        {
            // Generate collection from 1 - 1000 --> RANGE
            IEnumerable<int> first1000 = Enumerable.Range(1, 1000);

            // Repeat a value N times
            IEnumerable<string> fiveXs = Enumerable.Repeat("X", 5); // {"X","X","X","X","X"}

        }


        static public void studentsLinq()
        {

            var classRoom = new[]
            {
                new Student
                {
                    Id = 1,
                    Name = "Martín",
                    Grade = 90,
                    Certified = true,
                },
                new Student
                {
                    Id = 2,
                    Name = "Juan",
                    Grade = 50,
                    Certified = false,
                },
                new Student
                {
                    Id = 3,
                    Name = "Ana",
                    Grade = 96,
                    Certified = true,
                },
                new Student
                {
                    Id = 4,
                    Name = "Álvaro",
                    Grade = 10,
                    Certified = false,
                },
                new Student
                {
                    Id = 5,
                    Name = "Pedro",
                    Grade = 50,
                    Certified = true,
                }
            };


            var certifiedStudents = from student in classRoom
                                    where student.Certified
                                    select student;

            var notCertifiedStudents = from student in classRoom
                                       where student.Certified == false
                                       select student;

            var appovedStudentsNames = from student in classRoom
                                       where student.Grade >= 50 && student.Certified == true
                                       select student.Name;

        }

        // ALL
        static public void AllLinq()
        {
            var numbers = new List<int>() { 1, 2, 3, 4, 5 };
            bool allAreSmallerThan10 = numbers.All(x => x < 10); // true, devuelve todo lo que sea menos a 10
            bool allAreBiggerOrEqualThan2 = numbers.All(x => x >= 2); // false, devuelve todo lo que sea mayor a 2 

            var emptyList = new List<int>();
            bool allNumbersAreGreaterThan0 = numbers.All(x => x >= 0); // true

        }

        // Aggregate , === son funciones 1 detras de otra
        static public void aggregateQueries()
        {

            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Sum all numbers
            int sum = numbers.Aggregate((prevSum, current) => prevSum + current);

            // 0, 1 => 1
            // 1, 2 => 3
            // 3, 4 => 7
            // etc.


            string[] words = { "hello,", "my", "name", "is", "Martín" }; // hello, my name is Martín
            string greeting = words.Aggregate((prevGreeting, current) => prevGreeting + current);

            // "", "hello," => hello,
            // "hello,", "my" => hello, my
            // "hello, my", "name" => hello, my name
            // etc.
        }

        // Disctinct
        static public void distinctValues()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 5, 4, 3, 2, 1 };
            IEnumerable<int> distinctValues = numbers.Distinct(); // si metes entre () un numero te devolvera esos numeros
        }


        // GroupBy
        static public void groupByExamples()
        {

            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Obtain only even numbers and generate two groups
            var grouped = numbers.GroupBy(x => x % 2 == 0);

            // We will have two groups:
            // 1. The group that doesnt fit the condition (odd numbers)
            // 2. The group that fits the condition (even numbers)

            foreach (var group in grouped)
            {
                foreach (var value in group)
                {
                    Console.WriteLine(value); // 1,3,5,7,9 ... 2, 4, 6, 8 (first the odds and then the even)
                }
            }

            // Another Example
            var classRoom = new[]
            {
                new Student
                {
                    Id = 1,
                    Name = "Martín",
                    Grade = 90,
                    Certified = true,
                },
                new Student
                {
                    Id = 2,
                    Name = "Juan",
                    Grade = 50,
                    Certified = false,
                },
                new Student
                {
                    Id = 3,
                    Name = "Ana",
                    Grade = 96,
                    Certified = true,
                },
                new Student
                {
                    Id = 4,
                    Name = "Álvaro",
                    Grade = 10,
                    Certified = false,
                },
                new Student
                {
                    Id = 5,
                    Name = "Pedro",
                    Grade = 50,
                    Certified = true,
                }
            };


            var certifiedQuery = classRoom.GroupBy(student => student.Certified);

            // We obtain two groups
            // 1- Not certified students
            // 2- Certified Students


            foreach (var group in certifiedQuery)
            {
                Console.WriteLine("--------- {0} --------", group.Key);
                foreach (var student in group)
                {
                    Console.WriteLine(student.Name);
                }
            }

        }


        // Aqui empiezan el tema de las relaciones, en este caso Comment con Post
        static public void relationsLinq()
        {

            List<Post> posts = new List<Post>()
            {
                new Post()
                {
                    Id= 1,
                    Title = "My first post",
                    Content = "My first content",
                    Created = DateTime.Now,
                    Comments = new List<Comment>()
                    {
                        new Comment()
                        {
                            Id = 1,
                            Created = DateTime.Now,
                            Title = "My first comment",
                            Content = "My content"
                        },
                        new Comment()
                        {
                            Id = 2,
                            Created = DateTime.Now,
                            Title = "My second comment",
                            Content = "My other content"
                        }
                    }
                },
                new Post()
                {
                    Id= 2,
                    Title = "My second post",
                    Content = "My second content",
                    Created = DateTime.Now,
                    Comments = new List<Comment>()
                    {
                        new Comment()
                        {
                            Id = 3,
                            Created = DateTime.Now,
                            Title = "My other comment",
                            Content = "My new content"
                        },
                        new Comment()
                        {
                            Id = 4,
                            Created = DateTime.Now,
                            Title = "My other new comment",
                            Content = "My new content"
                        }
                    }
                }
            };


            var commentsContent = posts.SelectMany(
                    post => post.Comments,
                        (post, comment) => new { PostId = post.Id, CommentContent = comment.Content });

            // Nos devolveria el id del post y el commentario de cada uno de ello




        }


        }
    }