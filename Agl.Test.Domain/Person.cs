using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agl.Test.Domain
{
    public class Person
    {
        public int Age { get; set; }

        public string Gender { get; set; }

        public string Name { get; set; }

        public ICollection<Pet> Pets { get; set; }

    }
}
