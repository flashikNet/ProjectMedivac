using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Game : EntityBase
    {
        public required User PlayerA {  get; set; }
        public required User PlayerB { get; set; }
        public required int ResultA {  get; set; }
        public required int ResultB { get; set;}
        public required string Map {  get; set; }
        public required bool AConfirmation { get; set; }
        public required bool BConfirmation { get; set; }


    }
}
