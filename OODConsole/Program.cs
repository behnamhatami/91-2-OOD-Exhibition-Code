using System;
using OOD.Model.ModelContext;
using System.Data.Entity;

namespace OODConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var db = new OodContext())
            {

            }
            Console.ReadKey();
        }
    }
}