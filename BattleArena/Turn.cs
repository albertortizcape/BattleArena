using System;
using System.Collections.Generic;
using System.Text;

namespace BattleArena.Entities
{
    public class Turn
    {
        public Turn(int number, Entity entity)
        {
            TurnNumber = number;
            Entity = entity;
        }

        public int TurnNumber { get; set; }

        public Entity Entity { get; set; }
    }
}
