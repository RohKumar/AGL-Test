using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Agl.Test.Domain;


namespace Agl.Test.Data
{
    public class PersonData 
    {
       
        DataContext Context = new DataContext();
        public Dictionary<string, List<Pet>> GetCatsByOwnerSex()
        {
            var query = from a in Context.Persons
                        where a.Pets != null
                        group a by Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(a.Gender) into g
                        select new
                        {
                            Gender = g.Key,
                            Pets = g.SelectMany(a => a.Pets)
                            .Where(b => b.Type.Equals("Cat", StringComparison.InvariantCultureIgnoreCase))
                            .OrderBy(b => b.Name)
                            .ToList(),
                        };

            var result = query.ToDictionary(a => a.Gender, a => a.Pets);

            return result;
        }
    }
}
