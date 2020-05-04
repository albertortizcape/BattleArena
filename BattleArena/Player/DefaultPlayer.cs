using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace BattleArena.Entities.Player
{
    public class DefaultPlayer : Entity
    {
        public DefaultPlayer(string name, int life, int damage) : base(name, life, damage)
        {
        }
    }
}
