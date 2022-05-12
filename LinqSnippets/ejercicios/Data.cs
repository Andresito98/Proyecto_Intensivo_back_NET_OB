using LinqSnippets.ejercicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqSnippets
{
    public class Data
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public int? Curso { get; set; }
        public Alumno[] Alumnoss { get; set; } = new Alumno[0];
    }
}
