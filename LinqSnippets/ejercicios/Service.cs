using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqSnippets.ejercicios;

namespace LinqSnippets
{
    public class Service
    {

        // Buscar usuarios por email
        static public void UsersEmail()
        {
            string[] emails =
            {
                "prueba1@gmal.com",
                "prueba2@gmal.com",
                "prueba3@gmal.com",
                "prueba4@gmal.com",
                "prueba5@gmal.com",
                "prueba6@gmal.com",
                "prueba7@gmal.com"
            };

            // Coge en la lista todos los datos que contengan @ 
            var emailsList = from email in emails where email.Contains("@") select email;

            foreach (var audi in emailsList)
            {
                Console.WriteLine(audi);
            }

        }


        // Buscar alumnos mayores de edad
        static public void LinqNumbers()
        {
            List<int> numbers = new List<int> { 10, 22, 13, 34, 35, 6, 67, 48, 19 };

            // Busca los numeros que sean mayor a 17 y ordenalos por orden ascendente

            var processedNumbersList =
                numbers
                    .Select(num => num > 17)
                    .OrderBy(num => num);
        }


        static public void Alumnos()
        {

            var dataAlumnos = new[]
            {
                new Data()
                {
                    Id = 1,
                    Name = "Alumno 1",
                    Alumnoss = new[]
                    {
                        new Alumno
                        {
                            Id = 1,
                            Name = "Andrés",
                            Email = "andres@imaginagroup.com",
                            Curso = 1
                        },
                        new Alumno
                        {
                            Id = 2,
                            Name = "Pepe",
                            Email = "pepe@imaginagroup.com",
                            Curso = 0
                        },
                        new Alumno
                        {
                            Id = 3,
                            Name = "Juan",
                            Email = "juan@imaginagroup.com",
                            Curso = 15
                        },
                        new Alumno
                        {
                            Id = 4,
                            Name = "Juanjo",
                            Email = "juanjo@imaginagroup.com",
                            Curso = 3
                        }
                    }
                },
                new Data()
                {
                    Id = 2,
                    Name = "Alumno 2",
                    Alumnoss = new[]
                    {
                        new Alumno
                        {
                            Id = 5,
                            Name = "Paco",
                            Email = "paco@imaginagroup.com",
                            Curso = 0
                        },
                        new Alumno
                        {
                            Id = 6,
                            Name = "Marta",
                            Email = "marta@imaginagroup.com",
                            Curso = 0
                        },
                        new Alumno
                        {
                            Id = 7,
                            Name = "Pilar",
                            Email = "pilar@imaginagroup.com",
                            Curso = 3
                        },
                        new Alumno
                        {
                            Id = 8,
                            Name = "Pablo",
                            Email = "pablo@imaginagroup.com",
                            Curso = 8
                        }
                    }
                }


            };

            // El de mayor de edad se puede hacer igual a este
            // Buscar alumnos que tengan al menos un curso 
            bool alumnoConMasDe1Curso =
                dataAlumnos.Any(datos =>
                    datos.Alumnoss.Any(alumno => alumno.Curso > 0));

        }







    }

}
