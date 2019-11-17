using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TickTackToeGameLibrary;

namespace TickTackToeGameLibraryTest
{
	[TestClass]
	public class TickTackToeGameTests
	{
		[TestMethod]
		public void ChangeActivePlayer_swaps_players()
		{
			//Arrange

			//Act

			//Assert
		}

		public void ChangeActivePlayer_throws_exception_when_players_not_setup()
		{
			//Arrange

			//Act

			//Assert
		}

		public void HasGameBeenWon_returns_true_when_game_won_by_row()
		{
			//Arrange
			//Act
			//Assert
		}

		public void HasGameBeenWon_returns_true_when_game_won_by_column()
		{
			//Arrange
			//Act
			//Assert
		}

		public void HasGameBeenWon_returns_true_when_game_won_by_top_left_bottom_right_diaganol()
		{
			//Arrange
			//Act
			//Assert
		}

		public void HasGameBeenWon_returns_true_when_game_won_by_bottom_left_top_right_diaganol()
		{
			//Arrange
			//Act
			//Assert
		}

		public void HasGameBeenWon_returns_false_when_game_still_in_progress()
		{
			//Arrange
			//Act
			//Assert
		}

		public void CheckTurnResult_returns_cats_game_when_no_moves_left_and_no_winner()
		{
			//Arrange
			//Act
			//Assert
		}

		public void CheckTurnResult_returns_a_winner_when_no_moves_left_but_there_is_a_winner()
		{
			//Arrange
			//Act
			//Assert
		}

		public void CheckTurnResult_returns_X_winner_when_x_has_won()
		{
			//Arrange
			//Act
			//Assert
		}

		public void CheckTurnResult_returns_O_winner_when_o_has_won()
		{
			//Arrange
			//Act
			//Assert
		}

		public void CheckTurnResult_throws_exception_when_invalid_token_wins()
		{
			//Arrange
			//Act
			//Assert
		}

		public void CheckTurnResult_returns_InProgress_when_no_winner_and_moves_remain()
		{
			//Arrange
			//Act
			//Assert
		}

		private class TestGame : TickTackToeGame
		{
			public TestGame() : base(new TestBoard())
			{

			}
			public override void SetupPlayers()
			{
				throw new NotImplementedException();
			}

			public override void StartGame()
			{
				throw new NotImplementedException();
			}

			public override TickTackToeGameResult TakeTurn(TickTackToePlayer player)
			{
				throw new NotImplementedException();
			}
		}

		public class TestBoard : TickTackToeBoard
		{
			public override void DisplayBoard()
			{
				throw new NotImplementedException();
			}
		}
	}
}
