using SimpleAPI.DTO;

namespace SimpleAPI.Interface.Data
{
    public interface ISimpleData
    {
        public IEnumerable<SimpleDTO> GetList();
        public String addPerson(SimpleDTO person);
    }
}
