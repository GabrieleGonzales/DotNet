using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Caching.Memory;
using SimpleAPI.DTO;
using SimpleAPI.Interface.Data;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace SimpleAPI.Data
{
    public class SimpleData : ISimpleData
    {
        private readonly IMemoryCache _memoryCache;

        public SimpleData(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        public IEnumerable<SimpleDTO> GetList()
        {
            addDefaultList();
            _memoryCache.TryGetValue("List", out List<SimpleDTO> lst);
            return lst;
        }

        public void addDefaultList()
        {
            _memoryCache.TryGetValue("List", out List<SimpleDTO> lst);
            if (lst == null)
            {
                _memoryCache.CreateEntry("List");
                List<SimpleDTO> listAux = mockDB();
                _memoryCache.Set("List", listAux);
            }

        }

        public string addPerson(SimpleDTO person)
        {
            addDefaultList();
            _memoryCache.TryGetValue("List", out List<SimpleDTO> lst);
            lst.Add(person);
            _memoryCache.Set("List", lst);
            return ("ok");
        }


        private List<SimpleDTO> mockDB()
        {
            //This simulates a DB fetch.
            //Maybe in the future :)

            List<SimpleDTO> listAux = new List<SimpleDTO>();
            listAux.Add(new SimpleDTO
            {
                Name = "Gabi",
                Age = 30
            });
            listAux.Add(new SimpleDTO
            {
                Name = "Gilbe",
                Age = 32
            });
            listAux.Add(new SimpleDTO
            {
                Name = "Rafa",
                Age = 95
            });
            listAux.Add(new SimpleDTO
            {
                Name = "Brusios",
                Age = 20
            });

            return listAux;
        }

    }
}