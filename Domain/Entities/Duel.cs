using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Duel :EntityBase
    {
        public List<User> LineupA {  get; set; }
        public List<User> LineupB { get; set; }
        public required Team TeamA { get; set; }
        public required Team TeamB { get; set; } 
        public required DateTime StartTime { get; set; }
        public required List<Game> Games { get; set; }
    }
}
