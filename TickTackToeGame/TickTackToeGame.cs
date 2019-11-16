using System;
using System.Collections.Generic;
using System.Text;

namespace TickTackToeGameLibrary
{
	public abstract class TickTackToeGame
	{
		public TickTackToePlayer Player1 { get; protected set; }
		public TickTackToePlayer Player2 { get; protected set; }
		public TickTackToeBoard Board { get; private set; }

		public enum TickTackToeGameResult { XWins, OWins, InProgress, CatsGame };
		public int Round { get; protected set; }

		public TickTackToeGame(TickTackToeBoard board)
		{
			Board = board;
			Round = 1;
		}

		public virtual TickTackToePlayer ChangeActivePlayer(TickTackToePlayer player)
		{
			if (player == Player1)
				return Player2;
			return Player1;
		}


		public virtual bool HasGameBeenWon(TickTackToeBoard.TickTackToeToken playerTurnToken)
		{
			if (isWinnerByRow(playerTurnToken)) return true;
			if (isWinnerByColumn(playerTurnToken)) return true;
			if (isWinnerByDiaganal(playerTurnToken)) return true;

			return false;
		}

		private bool isWinnerByRow(TickTackToeBoard.TickTackToeToken playerTurnToken)
		{
			for (var row = 0; row < Board.BoardRowCount; row++)
				if (isWinningRow(row, playerTurnToken)) return true;

			return false;
		}
		private bool isWinningRow(int row, TickTackToeBoard.TickTackToeToken playerTurnToken)
		{
			for (var column = 1; column < Board.BoardColumnCount; column++)
				if (Board.GetValueAtLocation(row, column) != playerTurnToken) return false;

			return true;
		}

		private bool isWinnerByColumn(TickTackToeBoard.TickTackToeToken playerTurnToken)
		{
			for (var column = 0; column < Board.BoardColumnCount; column++)
				if (isWinningColumn(column, playerTurnToken)) return true;

			return false;
		}
		private bool isWinningColumn(int column, TickTackToeBoard.TickTackToeToken playerTurnToken)
		{
			for (var row = 1; row < Board.BoardRowCount; row++)
				if (Board.GetValueAtLocation(row, column) != playerTurnToken) return false;

			return true;
		}

		private bool isWinnerByDiaganal(TickTackToeBoard.TickTackToeToken playerTurnToken)
		{
			if (isWinningFirstDiagonal(playerTurnToken)) return true;
			if (isWinningSecondDiagonal(playerTurnToken)) return true;

			return false;
		}
		private bool isWinningFirstDiagonal(TickTackToeBoard.TickTackToeToken playerTurnToken)
		{
			for (var d = 0; d < Board.BoardRowCount; d++)
				if (Board.GetValueAtLocation(d, d) != playerTurnToken)
					return false;
			return true;
		}
		private bool isWinningSecondDiagonal(TickTackToeBoard.TickTackToeToken playerTurnToken)
		{
			for (var d = 0; d < Board.BoardRowCount; d++)
				if (Board.GetValueAtLocation(d, Board.BoardRowCount - d - 1) != playerTurnToken)
					return false;
			return true;
		}

		public virtual TickTackToeGameResult CheckTurnResult(TickTackToeBoard.TickTackToeToken playerTurnToken)
		{
			if (!Board.AnyMovesLeft())
				return TickTackToeGameResult.CatsGame;

			if (this.HasGameBeenWon(playerTurnToken))
			{
				switch (playerTurnToken)
				{
					case TickTackToeBoard.TickTackToeToken.O:
						return TickTackToeGameResult.OWins;
					case TickTackToeBoard.TickTackToeToken.X:
						return TickTackToeGameResult.XWins;
					default: throw new ArgumentException(message: "invalid enum value", paramName: nameof(playerTurnToken));
				}
			}

			return TickTackToeGameResult.InProgress;
		}

		public abstract void StartGame();

		public abstract void SetupPlayers();

		public abstract TickTackToeGameResult TakeTurn(TickTackToePlayer player);
	}
}
