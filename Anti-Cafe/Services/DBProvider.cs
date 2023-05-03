using Anti_Cafe.DAL.Models;
using Anti_Cafe.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;

namespace Anti_Cafe.Services
{
    public class DBProvider: IDBProvider
    {
        readonly AnticafeContext _db;
        public DBProvider(AnticafeContext context)
        {
            _db = context;
        }
        public async Task<List<Statuette>> GetStattue()
        {
           var stattuets= await _db.Statuettes.ToListAsync();
            return stattuets;
        }
        public async Task<string> CReateStatuette(string name)
        {
            var statuette = new Statuette() { Id= Guid.NewGuid().ToString(), Name=name };
            try
            {
                var st = _db.Statuettes.FirstAsync(x => x.Name == name);
                return "Вже є така фігурка, змініть назву та повторіть знову";
            }
            catch
            {
                await _db.Statuettes.AddAsync(statuette);
                return null;
            }
           
        }
    }
}
