using Anti_Cafe.DAL.Models;

namespace Anti_Cafe.Interfaces
{
    public interface IDBProvider
    {
        public Task<List<Statuette>> GetStatuette();
        public Task<List<Statuette>> CReateStatuette(string name);
        public  Task<List<Statuette>> DeleteStatuette(string name);
    }
}
