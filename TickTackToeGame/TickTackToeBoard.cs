using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;


//TODO make the board bigger
//TODO put the coordinance on the grid
namespace TickTackToeGameLibrary
{
	public abstract class TickTackToeBoard
	{
		protected TickTackToeToken[,] board = new TickTackToeToken[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };

		public enum TickTackToeToken
		{
			[BoardDisplay(" ")]
			Available,
			[BoardDisplay("X")]
			X,
			[BoardDisplay("O")]
			O
		}

		public int BoardRowCount { get => board.GetLength(0); }
		public int BoardColumnCount { get => board.GetLength(1); }

		public TickTackToeBoard()
		{
		}

		public virtual TickTackToeToken GetValueAtLocation(int row, int column) => board[row, column];

		public virtual bool AnyMovesLeft()
		{
			foreach (var playableSpace in board)
			{
				if (playableSpace == TickTackToeBoard.TickTackToeToken.Available)
					return true;
			}
			return false;
		}

		public virtual void PlaceTokenOnBoard(TickTackToeToken token, int row, int column)
		{
			if (isLocationAvailableToPlay(row, column))
				board[row, column] = token;
			else
				throw new InvalidOperationException("That location is not available");
		}

		protected virtual bool isLocationTaken(int row, int column)
		{
			return board[row, column] != TickTackToeToken.Available;
		}

		protected virtual bool isLocationOnBoard(int row, int column)
		{
			var validRow = row >= 0 && row <= board.GetLength(0);
			var validColumn = column >= 0 && column <= board.GetLength(1);
			return validRow && validColumn;
		}

		protected virtual bool isLocationAvailableToPlay(int row, int column)
		{
			return isLocationOnBoard(row, column) && !isLocationTaken(row, column);
		}

		public abstract void DisplayBoard();
	}
}
