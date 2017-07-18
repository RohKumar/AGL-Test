using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agl.Test.Domain;

using Agl.Test.Data;

namespace Agl.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonData pd = new PersonData();
            DisplayAglPetsByOwner(pd.GetCatsByOwnerSex());

            Console.WriteLine();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        private static void DisplayAglPetsByOwner(Dictionary<string, List<Pet>> items)
        {
            foreach (var item in items)
            {
                Console.WriteLine("{0}", item.Key);
                foreach (var pet in item.Value)
                {
                    Console.WriteLine("\t{0}", pet.Name);
                }
            }
        }
    }
}
