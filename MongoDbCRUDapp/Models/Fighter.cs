using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbCRUDapp.Models
{
    internal class Fighter
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FightingStyle {  get; set; }
        public string SpecialAbility { get; set; }
        public int Hp {  get; set; }
    }
}
