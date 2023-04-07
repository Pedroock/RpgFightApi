using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RpgFight.Models;

namespace RpgFight.Services.HttpContextService
{
    public interface IHttpContextService
    {
        public int GetCurrentUserId();
        public Task<ServiceResponse<Character>> GetCurrentCharacter(); 
        public Task<ServiceResponse<Enemy>> GetCurrentEnemy();
    }
}