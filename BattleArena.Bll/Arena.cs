using System.Collections.Generic;
using System.Linq;
using BattleArena.Entities;

namespace BattleArena.Bll
{
    public class Arena : IArena
    {
        private Entity _player1;
        private Entity _player2;
        private List<Turn> _turns;

        public Arena(Entity player1, Entity player2)
        {
            _player1 = player1;
            _player2 = player2;

            // No initiative is declared, so the first player in attack is the first player in the constructor
            _turns = new List<Turn> {new Turn(1, _player1)};
        }

        public bool ArePlayersAlive()
        {
            return _player1.Life > 0 && _player2.Life > 0;
        }

        public string WhoAttacksFirst()
        {
            return _player1.Name;
        }

        public Turn WhichTurnIs()
        {
            return _turns.Last();
        }

        public Entity WhoAttacksNow()
        {
            return _turns.Last().Entity;
        }

        public void NextTurn()
        {
            Turn actualTurn = WhichTurnIs();
            Entity player = WhoAttacksNow();

            if (player.Name == _player1.Name)
            {
                _turns.Add(new Turn(actualTurn.TurnNumber++, _player2));
            }
            else
            {
                _turns.Add(new Turn(actualTurn.TurnNumber++, _player1));
            }
        }

        public void Attack()
        {
            Entity player = WhoAttacksNow();

            if (player.Name == _player1.Name)
            {
                _player2.Life = _player2.Life - _player1.Damage;
                if (_player2.Life < 0)
                {
                    _player2.Life = 0;
                }
            }
            else
            {
                _player1.Life = _player1.Life - _player2.Damage;
                if (_player1.Life < 0)
                {
                    _player1.Life = 0;
                }
            }
        }
    }
}
