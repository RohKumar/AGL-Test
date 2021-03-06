﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

using Agl.Test.Domain;
using Newtonsoft.Json;

namespace Agl.Test.Data
{
    public class DataContext
    {
        public IQueryable<Person> Persons
        {
            get
            {
                return Task.Run(async () => await GetPersons()).Result;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public async Task<IQueryable<Person>> GetPersons()
        {
            var url = @"http://agl-developer-test.azurewebsites.net/people.json";
            using (var client = new HttpClient())
            using (var response = await client.GetAsync(url))
            using (var content = response.Content)
            {
                string json = await content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<List<Person>>(json);

                return result.AsQueryable();
            }
        }
    }
}
