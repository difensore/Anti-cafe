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
        public async Task<List<Statuette>> CReateStatuette(string name)
        {           
            try
            {
                var st = _db.Statuettes.Single(x => x.Name == name);
                return null;
            }
            catch
            {
                var statuette = new Statuette() { Id = Guid.NewGuid().ToString(), Name = name, InUse = 0 };
                await _db.Statuettes.AddAsync(statuette);
                _db.SaveChanges();
                return await _db.Statuettes.ToListAsync();
            }
           
        }
    }
}
