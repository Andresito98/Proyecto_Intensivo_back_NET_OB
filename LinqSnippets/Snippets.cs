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


        // variables

        // ZIP

        // Repeat

        // ALL



    }
}