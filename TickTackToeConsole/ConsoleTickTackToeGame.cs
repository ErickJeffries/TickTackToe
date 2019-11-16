using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TickTackToeGameLibrary;

namespace TickTackToeConsole
{
	public class ConsoleTickTackToeGame : TickTackToeGame
	{
		public ConsoleTickTackToeGame() : base(new ConsoleTickTackToeBoard())
		{
		}

		public override void SetupPlayers()
		{
			Console.WriteLine("Setting up players");
			Console.WriteLine("Hello, please input Player 1's name");
			var player1Name = Console.ReadLine();
			Console.WriteLine($"Welcome {player1Name}, enter 'X' to be X's, enter 'O' to be O's");
			var player1TokenResponse = Console.ReadLine();
			var player1Token = ParseToken(player1TokenResponse);
			Player1 = new TickTackToePlayer(player1Name, player1Token);

			Console.WriteLine("Hello, please input Player 2's name");
			var player2Name = Console.ReadLine();
			Console.WriteLine($"Welcome {player2Name}, enter 'X' to be X's, enter 'O' to be O's");
			var player2TokenResponse = Console.ReadLine();
			var player2Token = ParseToken(player2TokenResponse);
			Player2 = new TickTackToePlayer(player2Name, player2Token);
		}

		private TickTackToeBoard.TickTackToeToken ParseToken(string token)
		{
			if (token == "X" || token == "x")
				return TickTackToeBoard.TickTackToeToken.X;
			if (token == "O" || token == "o")
				return TickTackToeBoard.TickTackToeToken.O;
			throw new InvalidOperationException("{token} is not a valid Tick Tack Toe Token.");
		}

		public override TickTackToePlayer ChangeActivePlayer(TickTackToePlayer player)
		{
			Console.WriteLine("Changing Active Player");
			var result = base.ChangeActivePlayer(player);
			Console.WriteLine($"New Active Player: {result.ToString()}");
			return result;
		}

		public override void StartGame()
		{
			Console.WriteLine("Start Game");
			TickTackToeGameResult gameState;
			var activePlayer = Player1;
			do
			{
				Console.WriteLine($"Round {Round++}: ");
				Board.DisplayBoard();
				gameState = TakeTurn(activePlayer);
				activePlayer = ChangeActivePlayer(activePlayer);

			} while (gameState == TickTackToeGameResult.InProgress);
			Console.WriteLine($"{gameState} win");
			Console.WriteLine("Game Over");
		}

		public override TickTackToeGameResult TakeTurn(TickTackToePlayer player)
		{
			Console.WriteLine($"{player.ToString()} is taking their turn");
			Console.WriteLine($"{player.ToString()} enter the coordinates x,y to place your token");
			var result = ParseTakeTurnResponse(Console.ReadLine());
			this.Board.PlaceTokenOnBoard(player.Token, result.row, result.column);

			return this.CheckTurnResult(player.Token);
		}
		private (int row, int column) ParseTakeTurnResponse(string response)
		{
			var split = response.Split(',');
			return (int.Parse(split.First()), int.Parse(split.Last()));
		}


	}
}
