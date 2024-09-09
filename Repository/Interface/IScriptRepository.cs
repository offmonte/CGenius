﻿using System.Collections.Generic;
using System.Threading.Tasks;
using CGenius.Models;

namespace CGenius.Repository.Interface
{
    public interface IScriptRepository
    {
        Task<IEnumerable<Script>> GetScripts();
        Task<Script> GetScript(int idScript);
        Task<Script> AddScript(Script script);
        Task<Script> UpdateScript(Script script);
        Task DeleteScript(int idScript);
    }
}