using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RpgFight.Models;
using RpgFight.Dtos.User;
using RpgFight.Dtos.Armor;
using RpgFight.Dtos.Character;
using RpgFight.Dtos.Class;
using RpgFight.Dtos.Effect;
using RpgFight.Dtos.Enemy;
using RpgFight.Dtos.Skill;
using RpgFight.Dtos.Weapon;

namespace RpgFight
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, GetUserDto>();
            CreateMap<GetUserDto, User>();
            CreateMap<Armor, GetArmorDto>();
            CreateMap<Character, GetCharacterDto>();
            CreateMap<Class, GetClassDto>();
            CreateMap<Effect, GetEffectDto>();
            CreateMap<Enemy, GetEnemyDto>();
            CreateMap<Skill, GetSkillDto>();
            CreateMap<Weapon, GetWeaponDto>();
        }
    }
}