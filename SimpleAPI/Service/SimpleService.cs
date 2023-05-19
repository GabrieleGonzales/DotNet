using Microsoft.Extensions.Caching.Memory;
using SimpleAPI.DTO;
using SimpleAPI.Interface.Data;
using SimpleAPI.Interface.Service;

namespace SimpleAPI.Service
{
    public class SimpleService : ISimpleService
    {
        private readonly ISimpleData _simpleData;
        
        public SimpleService(ISimpleData simpleData)
        {
            _simpleData = simpleData;
        }

        public String addPerson(SimpleDTO person)
        {
            return _simpleData.addPerson(person);    
        }

        public IEnumerable<SimpleDTO> GetList()
        {
            return _simpleData.GetList();
        }
    }
}
