using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstOne.Data;
using FirstOne.Models;
using FirstOne.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace FirstOne.Repository
{
    public class ScriptRepository : IScriptRepository
    {
        private readonly dbContext _dbContext;

        public ScriptRepository(dbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Script>> GetScripts()
        {
            return await _dbContext.Scripts.ToListAsync();
        }

        public async Task<Script> GetScript(int idScript)
        {
            return await _dbContext.Scripts.FirstOrDefaultAsync(s => s.IdScript == idScript);
        }

        public async Task<Script> AddScript(Script script)
        {
            var result = await _dbContext.Scripts.AddAsync(script);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Script> UpdateScript(Script script)
        {
            var existingScript = await _dbContext.Scripts.FirstOrDefaultAsync(s => s.IdScript == script.IdScript);
            if (existingScript != null)
            {
                existingScript.DescricaoScript = script.DescricaoScript;
                existingScript.IdPlano = script.IdPlano;

                await _dbContext.SaveChangesAsync();
                return existingScript;
            }

            return null;
        }

        public async void DeleteScript(int idScript)
        {
            var script = await _dbContext.Scripts.FirstOrDefaultAsync(s => s.IdScript == idScript);
            if (script != null)
            {
                _dbContext.Scripts.Remove(script);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
