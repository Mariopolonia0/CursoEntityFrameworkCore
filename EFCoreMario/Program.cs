using EFCoreMario.DAL;
using EFCoreMario.Models;
using System;
using System.Linq;

namespace EFCoreMario
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Mario");

            var context = new SchoolContext();
            /*var studentsWithSameName = context.Students
                                              .Where(s => s.Name == GetName())
                                              .ToList();*/

            Guardar(context, "hola");
            Modificar(context, "Yeuri");
            Eliminar(context);
            
        }

        public static string GetName()
        {
            return "Mario";
        }


        static public void Guardar(SchoolContext contexto,String name)
        {
            var std = new Student()
            {
                Name = name,
            };
            contexto.Students.Add(std);
            contexto.SaveChanges();
        }

        static public void Modificar(SchoolContext contexto, String name)
        {
            var std = contexto.Students.First<Student>();
            std.Name = name;
            contexto.SaveChanges();
        }

        static public void Eliminar(SchoolContext contexto)
        {
            var std = contexto.Students.First<Student>();
            contexto.Students.Remove(std);
            contexto.SaveChanges();
        }
    }
}
