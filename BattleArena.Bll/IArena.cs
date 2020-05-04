using System;
using System.Collections.Generic;
using System.Text;
using BattleArena.Entities;

namespace BattleArena.Bll
{
    public interface IArena
    {
        bool ArePlayersAlive();
        string WhoAttacksFirst();
        Turn WhichTurnIs();
        Entity WhoAttacksNow();
        void NextTurn();
        void Attack();
    }
}
