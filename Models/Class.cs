using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RpgFight.Models.Joins;

namespace RpgFight.Models
{
    public class Class
    {
        public int Id { get; set; }
        public List<ClassEffect>? ClassEffects { get; set; }
    }
}