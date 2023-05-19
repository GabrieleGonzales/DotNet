using SimpleAPI.DTO;

namespace SimpleAPI.Interface.Service
{
    public interface ISimpleService
    {
        public IEnumerable<SimpleDTO> GetList();
        public String addPerson(SimpleDTO person);
    }
}
