using System;
using System.Collections.Generic;
using System.Text;
using BattleArena.Entities;
using BattleArena.Entities.Player;
using Xunit;

namespace BattleArena.UnitTest
{
    public class ArenaWithTwoPlatersShould
    {
        private Arena _Arena;
        private readonly string player1Name = "Jesús";
        private readonly string player2Name = "Alberto";

        public ArenaWithTwoPlatersShould()
        {
            var player1 = new DefaultPlayer(player1Name, 100, 5);
            var player2 = new DefaultPlayer(player2Name, 100, 5);

            _Arena = new Arena(player1, player2);
        }

        [Theory]
        [InlineData("Jesús", 100, 5, "Alberto", 100, 5)]
        [InlineData("Jesús", 1, 5, "Alberto", 1, 5)]
        public void Know_if_player_are_Alive(string namePlayer1, int lifePlayer1, int damagePlayer1, string namePlayer2, int lifePlayer2, int damagePlayer2)
        {
            var player1 = new DefaultPlayer(namePlayer1, lifePlayer1, damagePlayer1);
            var player2 = new DefaultPlayer(namePlayer2, lifePlayer2, damagePlayer2);

            var arena = new Arena(player1, player2);

            bool result = arena.ArePlayersAlive();
            Assert.True(result);
        }

        [Fact]
        public void Know_who_Attacks_First()
        {
            string playerName = _Arena.WhoAttacksFirst();
            Assert.Equal(playerName, player1Name);
        }

        [Theory]
        [InlineData(1, "Alberto")]
        [InlineData(2, "Jesús")]
        public void Know_who_Attacks_Now(int numberOfTurns, string playerName)
        {
            for(int i = 0; i < numberOfTurns; i++)
            {
                _Arena.NextTurn();
            }

            Entity player = _Arena.WhoAttacksNow();
            Assert.Equal(player.Name, playerName);
        }

        [Theory]
        [InlineData("Jesús", 100, 5, "Alberto", 100, 5, 95)]
        [InlineData("Jesús", 1, 5, "Alberto", 1, 5, 0)]
        public void Attack_Player(string namePlayer1, int lifePlayer1, int damagePlayer1, string namePlayer2, int lifePlayer2, int damagePlayer2, int lifePostAttack)
        {
            var player1 = new DefaultPlayer(namePlayer1, lifePlayer1, damagePlayer1);
            var player2 = new DefaultPlayer(namePlayer2, lifePlayer2, damagePlayer2);

            var arena = new Arena(player1, player2);
            arena.Attack();

            Assert.Equal(player2.Life, lifePostAttack);
        }

        [Theory]
        [InlineData("Jesús", 100, 5, "Alberto", 100, 5, 0)]
        //[InlineData("Jesús", 1, 5, "Alberto", 1, 5, 0)]
        public void Combat_Unit_Death(string namePlayer1, int lifePlayer1, int damagePlayer1, string namePlayer2, int lifePlayer2, int damagePlayer2, int lifePostAttack)
        {
            var player1 = new DefaultPlayer(namePlayer1, lifePlayer1, damagePlayer1);
            var player2 = new DefaultPlayer(namePlayer2, lifePlayer2, damagePlayer2);

            var arena = new Arena(player1, player2);

            while (arena.ArePlayersAlive())
            {
                arena.Attack();
                arena.NextTurn();
            }

            Assert.Equal(player2.Life, lifePostAttack);
        }
    }
}
