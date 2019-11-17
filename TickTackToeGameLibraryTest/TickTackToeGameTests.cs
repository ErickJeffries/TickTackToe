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
			string player1Name = "player one";
			var player1Token = TickTackToeBoard.TickTackToeToken.X;

			string player2Name = "player two";
			var player2Token = TickTackToeBoard.TickTackToeToken.O;

			var board = new TestBoard();

			var game = new TestGame(board);
			game.SetPlayer1(player1Name, player1Token);
			game.SetPlayer2(player2Name, player2Token);

			//Act
			var result = game.ChangeActivePlayer(game.Player1);

			//Assert
			Assert.AreEqual(game.Player2, result);
		}

		[TestMethod]
		public void ChangeActivePlayer_throws_exception_when_players_param_not_setup()
		{
			//Arrange
			var board = new TestBoard();
			var game = new TestGame(board);
			TickTackToePlayer player = null;

			//Act

			//Assert
			Assert.ThrowsException<InvalidOperationException>(() => game.ChangeActivePlayer(player));
		}

		[TestMethod]
		public void ChangeActivePlayer_throws_exception_when_player2_property_not_setup()
		{
			//Arrange
			var board = new TestBoard();
			var game = new TestGame(board);

			//Act

			//Assert
			Assert.ThrowsException<InvalidOperationException>(() => game.ChangeActivePlayer(game.Player2));
		}

		[TestMethod]
		public void ChangeActivePlayer_throws_exception_when_player1_property_not_setup()
		{
			//Arrange
			var board = new TestBoard();
			var game = new TestGame(board);

			//Act

			//Assert
			Assert.ThrowsException<InvalidOperationException>(() => game.ChangeActivePlayer(game.Player1));
		}

		[TestMethod]
		public void HasGameBeenWon_returns_true_when_game_won_by_row()
		{
			//Arrange
			var board = new TestBoard();
			var token = TickTackToeBoard.TickTackToeToken.O;
			board.PlaceTokenOnBoard(token, 0, 0);
			board.PlaceTokenOnBoard(token, 0, 1);
			board.PlaceTokenOnBoard(token, 0, 2);
			var game = new TestGame(board);

			//Act
			var result = game.HasGameBeenWon(token);
			//Assert
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void HasGameBeenWon_returns_true_when_game_won_by_column()
		{
			//Arrange
			var board = new TestBoard();
			var token = TickTackToeBoard.TickTackToeToken.O;
			board.PlaceTokenOnBoard(token, 0, 0);
			board.PlaceTokenOnBoard(token, 1, 0);
			board.PlaceTokenOnBoard(token, 2, 0);
			var game = new TestGame(board);

			//Act
			var result = game.HasGameBeenWon(token);
			//Assert
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void HasGameBeenWon_returns_true_when_game_won_by_top_left_bottom_right_diaganol()
		{
			//Arrange
			var board = new TestBoard();
			var token = TickTackToeBoard.TickTackToeToken.O;
			board.PlaceTokenOnBoard(token, 0, 0);
			board.PlaceTokenOnBoard(token, 1, 1);
			board.PlaceTokenOnBoard(token, 2, 2);
			var game = new TestGame(board);

			//Act
			var result = game.HasGameBeenWon(token);
			//Assert
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void HasGameBeenWon_returns_true_when_game_won_by_bottom_left_top_right_diaganol()
		{
			//Arrange
			var board = new TestBoard();
			var token = TickTackToeBoard.TickTackToeToken.O;
			board.PlaceTokenOnBoard(token, 0, 2);
			board.PlaceTokenOnBoard(token, 1, 1);
			board.PlaceTokenOnBoard(token, 2, 0);
			var game = new TestGame(board);

			//Act
			var result = game.HasGameBeenWon(token);
			//Assert
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void HasGameBeenWon_returns_false_when_game_still_in_progress()
		{
			//Arrange
			var board = new TestBoard();
			var token = TickTackToeBoard.TickTackToeToken.O;
			board.PlaceTokenOnBoard(token, 0, 0);
			board.PlaceTokenOnBoard(token, 0, 1);
			var game = new TestGame(board);

			//Act
			var result = game.HasGameBeenWon(token);
			//Assert
			Assert.IsFalse(result);
		}

		[TestMethod]
		public void CheckTurnResult_returns_cats_game_when_no_moves_left_and_no_winner()
		{
			//Arrange
			var board = new TestBoard();
			var token1 = TickTackToeBoard.TickTackToeToken.O;
			var token2 = TickTackToeBoard.TickTackToeToken.X;

			//no winner
			board.PlaceTokenOnBoard(token1, 0, 0);
			board.PlaceTokenOnBoard(token2, 0, 1);
			board.PlaceTokenOnBoard(token2, 0, 2);

			//no winner
			board.PlaceTokenOnBoard(token2, 1, 0);
			board.PlaceTokenOnBoard(token1, 1, 1);
			board.PlaceTokenOnBoard(token2, 1, 2);

			//no winner
			board.PlaceTokenOnBoard(token1, 2, 0);
			board.PlaceTokenOnBoard(token1, 2, 1);
			board.PlaceTokenOnBoard(token2, 2, 2);
			var game = new TestGame(board);

			//Act
			var result = game.CheckTurnResult(token1);
			//Assert
			Assert.IsTrue(result == TickTackToeGame.TickTackToeGameResult.CatsGame);
		}

		[TestMethod]
		public void CheckTurnResult_returns_a_winner_when_no_moves_left_but_there_is_a_winner()
		{
			//Arrange
			var board = new TestBoard();
			var token1 = TickTackToeBoard.TickTackToeToken.O;
			var expectedWinner = TickTackToeGame.TickTackToeGameResult.OWins;
			var token2 = TickTackToeBoard.TickTackToeToken.X;

			//winner
			board.PlaceTokenOnBoard(token1, 0, 0);
			board.PlaceTokenOnBoard(token1, 0, 1);
			board.PlaceTokenOnBoard(token1, 0, 2);

			//no winner
			board.PlaceTokenOnBoard(token2, 1, 0);
			board.PlaceTokenOnBoard(token1, 1, 1);
			board.PlaceTokenOnBoard(token2, 1, 2);

			//no winner
			board.PlaceTokenOnBoard(token1, 2, 0);
			board.PlaceTokenOnBoard(token1, 2, 1);
			board.PlaceTokenOnBoard(token2, 2, 2);
			var game = new TestGame(board);

			//Act
			var result = game.CheckTurnResult(token1);
			//Assert
			Assert.IsTrue(result == expectedWinner);
		}

		[TestMethod]
		public void CheckTurnResult_returns_X_winner_when_x_has_won()
		{
			//Arrange
			var board = new TestBoard();
			var token = TickTackToeBoard.TickTackToeToken.X;

			board.PlaceTokenOnBoard(token, 0, 0);
			board.PlaceTokenOnBoard(token, 0, 1);
			board.PlaceTokenOnBoard(token, 0, 2);

			var game = new TestGame(board);

			//Act
			var result = game.CheckTurnResult(token);
			//Assert
			Assert.IsTrue(result == TickTackToeGame.TickTackToeGameResult.XWins);
		}

		[TestMethod]
		public void CheckTurnResult_returns_O_winner_when_o_has_won()
		{
			//Arrange
			var board = new TestBoard();
			var token = TickTackToeBoard.TickTackToeToken.O;

			board.PlaceTokenOnBoard(token, 0, 0);
			board.PlaceTokenOnBoard(token, 0, 1);
			board.PlaceTokenOnBoard(token, 0, 2);

			var game = new TestGame(board);

			//Act
			var result = game.CheckTurnResult(token);
			//Assert
			Assert.IsTrue(result == TickTackToeGame.TickTackToeGameResult.OWins);
		}

		[TestMethod]
		public void CheckTurnResult_throws_exception_when_invalid_token_wins()
		{
			//Arrange
			var board = new TestBoard();
			var token = TickTackToeBoard.TickTackToeToken.Available;

			var game = new TestGame(board);

			//Act
			//Assert
			Assert.ThrowsException<ArgumentException>(() => game.CheckTurnResult(token));
		}

		[TestMethod]
		public void CheckTurnResult_returns_InProgress_when_no_winner_and_moves_remain()
		{
			//Arrange
			var board = new TestBoard();
			var token = TickTackToeBoard.TickTackToeToken.O;

			board.PlaceTokenOnBoard(token, 0, 0);
			board.PlaceTokenOnBoard(token, 0, 2);

			var game = new TestGame(board);

			//Act
			var result = game.CheckTurnResult(token);
			//Assert
			Assert.IsTrue(result == TickTackToeGame.TickTackToeGameResult.InProgress);
		}

		private class TestGame : TickTackToeGame
		{
			public TestGame(TickTackToeBoard board) : base(board)
			{

			}

			public void SetPlayer1(string name, TickTackToeBoard.TickTackToeToken token)
			{
				Player1 = new TickTackToePlayer(name, token);
			}

			public void SetPlayer2(string name, TickTackToeBoard.TickTackToeToken token)
			{
				Player2 = new TickTackToePlayer(name, token);
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
