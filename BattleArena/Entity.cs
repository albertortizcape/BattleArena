using System;
using System.Collections.Generic;
using System.Text;

namespace BattleArena.Entities
{
    public abstract class Entity
    {
        public Entity(string name, int life, int damage)
        {
            Name = name;
            Life = life;
            Damage = damage;
        }

        public string Name { get; set; }

        public int Life { get; set; }

        public int Damage { get; set; }
    }
}
