using Anti_Cafe.DAL.Models;

namespace Anti_Cafe.Interfaces
{
    public interface IDBProvider
    {
        public Task<List<Statuette>> GetStattue();
        public Task<string> CReateStatuette(string name);
    }
}
