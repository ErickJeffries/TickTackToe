using System;
using System.Collections.Generic;
using System.Text;
using TickTackToeGameLibrary;

namespace TickTackToeConsole
{
	public class ConsoleTickTackToeBoard : TickTackToeBoard
	{
		public ConsoleTickTackToeBoard() : base()
		{
		}

		public override void DisplayBoard()
		{
			Console.WriteLine("Display board here");
			Console.WriteLine($"{BoardDisplay.GetDescription(board[0, 0])}|{BoardDisplay.GetDescription(board[0, 1])}|{BoardDisplay.GetDescription(board[0, 2])}");
			Console.WriteLine($"_______");
			Console.WriteLine($"{BoardDisplay.GetDescription(board[1, 0])}|{BoardDisplay.GetDescription(board[1, 1])}|{BoardDisplay.GetDescription(board[1, 2])}");
			Console.WriteLine($"_______");
			Console.WriteLine($"{BoardDisplay.GetDescription(board[2, 0])}|{BoardDisplay.GetDescription(board[2, 1])}|{BoardDisplay.GetDescription(board[2, 2])}");
		}

		public override bool AnyMovesLeft()
		{
			var result = base.AnyMovesLeft();
			Console.WriteLine($"Any moves left: {result}");
			return result;
		}

		protected override bool isLocationTaken(int row, int column)
		{
			var result = base.isLocationTaken(row, column);
			Console.WriteLine($"Is location taken: {result}");
			return result;
		}

		protected override bool isLocationOnBoard(int row, int column)
		{
			var result = base.isLocationOnBoard(row, column);
			Console.WriteLine($"Is location on the board: {result}");
			return result;
		}

		protected override bool isLocationAvailableToPlay(int row, int column)
		{
			var result = base.isLocationAvailableToPlay(row, column);
			Console.WriteLine($"Is location available to play: {result}");
			return result;
		}

		public override void PlaceTokenOnBoard(TickTackToeToken token, int row, int column)
		{
			Console.WriteLine($"Place {token} at row {row}, column {column}");
			base.PlaceTokenOnBoard(token, row, column);
		}
	}
}
