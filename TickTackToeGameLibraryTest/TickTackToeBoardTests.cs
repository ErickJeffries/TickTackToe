using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TickTackToeGameLibrary;

namespace TickTackToeGameLibraryTest
{
	[TestClass]
	public class TickTackToeBoardTests
	{
		[TestMethod]
		public void BoardRowCount_gets_row_count()
		{
			//Arrange
			var board = new Testboard(TickTackToeBoard.TickTackToeToken.Available);

			//Act
			var rowCount = board.BoardRowCount;

			//Assert
			Assert.AreEqual(Testboard.RowCount, rowCount);
		}

		[TestMethod]
		public void BoardColumnCount_gets_column_count()
		{
			//Arrange
			var board = new Testboard(TickTackToeBoard.TickTackToeToken.Available);
			//Act
			var columnCount = board.BoardColumnCount;
			//Assert
			Assert.AreEqual(Testboard.ColumnCount, columnCount);
		}

		[TestMethod]
		public void Board_is_constructed_with_all_available_slots()
		{
			//Arrange
			var board = new StandardTestBoard();
			var result = true;

			//Act
			foreach (var playableSpace in board.Board)
			{
				if (playableSpace != TickTackToeBoard.TickTackToeToken.Available)
					result = false;
			}

			//Assert
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void Board_gets_constructed_with_3_by_3_dimensions()
		{
			//Arrange
			var board = new StandardTestBoard();

			//Act
			var columns = board.BoardColumnCount;
			var rows = board.BoardRowCount;

			//Assert
			Assert.IsTrue(columns == 3);
			Assert.IsTrue(rows == 3);
		}

		[TestMethod]
		public void GetValueAtLocation_returns_accurate_value()
		{
			//Arrange
			var board = new StandardTestBoard();
			var token = TickTackToeBoard.TickTackToeToken.O;
			int expectedRow = 1;
			int expectedColumn = 2;
			board.PlaceTokenOnBoard(token, expectedRow, expectedColumn);

			//Act
			var value = board.GetValueAtLocation(expectedRow, expectedColumn);

			//Assert
			Assert.AreEqual(token, value);
		}

		[TestMethod]
		public void GetValueAtLocation_throws_IndexOutOfRangeException_when_invalid_location_provided()
		{
			//Arrange
			var board = new StandardTestBoard();

			//Act & Assert
			Assert.ThrowsException<IndexOutOfRangeException>(() => board.GetValueAtLocation(4, 4));
		}

		[TestMethod]
		public void AnyMovesLeft_is_true_when_board_still_has_spaces_available()
		{
			//Arrange
			var board = new StandardTestBoard();

			//Act
			var result = board.AnyMovesLeft();

			//Assert
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void AnyMovesLeft_is_false_when_board_still_has_no_spaces_available()
		{
			//Arrange
			var board = new StandardTestBoard();
			board.PlaceTokenOnBoard(TickTackToeBoard.TickTackToeToken.X, 0, 0);
			board.PlaceTokenOnBoard(TickTackToeBoard.TickTackToeToken.X, 0, 1);
			board.PlaceTokenOnBoard(TickTackToeBoard.TickTackToeToken.X, 0, 2);

			board.PlaceTokenOnBoard(TickTackToeBoard.TickTackToeToken.O, 1, 0);
			board.PlaceTokenOnBoard(TickTackToeBoard.TickTackToeToken.O, 1, 1);
			board.PlaceTokenOnBoard(TickTackToeBoard.TickTackToeToken.O, 1, 2);

			board.PlaceTokenOnBoard(TickTackToeBoard.TickTackToeToken.O, 2, 0);
			board.PlaceTokenOnBoard(TickTackToeBoard.TickTackToeToken.O, 2, 1);
			board.PlaceTokenOnBoard(TickTackToeBoard.TickTackToeToken.O, 2, 2);

			//Act
			var result = board.AnyMovesLeft();

			//Assert
			Assert.IsFalse(result);
		}

		[TestMethod]
		public void PlaceTokenOnBoard_puts_token_in_available_spot_on_board()
		{
			//Arrange
			var board = new StandardTestBoard();
			int column = 1;
			int row = 1;
			var valueBeforePlacement = board.GetValueAtLocation(row, column);

			//Act
			board.PlaceTokenOnBoard(TickTackToeBoard.TickTackToeToken.O, row, column);
			var valueAfterPlacement = board.GetValueAtLocation(row, column);

			//Assert
			Assert.AreEqual(TickTackToeBoard.TickTackToeToken.Available, valueBeforePlacement);
			Assert.AreNotEqual(valueBeforePlacement, valueAfterPlacement);
		}

		[TestMethod]
		public void PlaceTokenOnBoard_puts_token_in_correct_spot_on_board()
		{
			//Arrange
			var board = new StandardTestBoard();
			int column = 1;
			int row = 1;
			var valueBeforePlacement = board.GetValueAtLocation(row, column);

			//Act
			board.PlaceTokenOnBoard(TickTackToeBoard.TickTackToeToken.O, row, column);
			var valueAfterPlacement = board.GetValueAtLocation(row, column);

			//Assert
			Assert.AreNotEqual(valueBeforePlacement, valueAfterPlacement);
			//TODO check to make sure no other elements in the array were changed (will need to use a fake/moq for this)
		}

		[TestMethod]
		public void PlaceTokenOnBoard_puts_correct_token_in_spot_on_board()
		{
			//Arrange
			var board = new StandardTestBoard();
			int column = 1;
			int row = 1;
			var token = TickTackToeBoard.TickTackToeToken.O;

			//Act
			board.PlaceTokenOnBoard(token, row, column);
			var valueAfterPlacement = board.GetValueAtLocation(row, column);

			//Assert
			Assert.AreEqual(token, valueAfterPlacement);
		}

		[TestMethod]
		public void PlaceTokenOnBoard_throws_exception_when_spot_not_available_on_board()
		{
			//Arrange
			var board = new StandardTestBoard();

			//Act
			board.PlaceTokenOnBoard(TickTackToeBoard.TickTackToeToken.X, 1, 1);

			//Assert
			Assert.ThrowsException<InvalidOperationException>(() => board.PlaceTokenOnBoard(TickTackToeBoard.TickTackToeToken.O, 1, 1));
		}

		[TestMethod]
		public void isLocationTaken_returns_true_if_taken_by_X()
		{
			//Arrange
			var board = new Testboard(TickTackToeBoard.TickTackToeToken.Available);
			int column = 2;
			int row = 1;
			board.PlaceTokenOnBoard(TickTackToeBoard.TickTackToeToken.X, row, column);

			//Act
			var result = board.isLocationTakenWrapper(row, column);

			//Assert
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void isLocationTaken_returns_true_if_taken_by_O()
		{
			//Arrange
			var board = new Testboard(TickTackToeBoard.TickTackToeToken.Available);
			int column = 2;
			int row = 1;
			board.PlaceTokenOnBoard(TickTackToeBoard.TickTackToeToken.O, row, column);

			//Act
			var result = board.isLocationTakenWrapper(row, column);

			//Assert
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void isLocationTaken_returns_false_if_not_taken()
		{
			//Arrange
			var board = new Testboard(TickTackToeBoard.TickTackToeToken.Available);

			//Act (no action needed)

			//Assert
			Assert.IsFalse(board.isLocationTakenWrapper(1, 1));
		}

		[TestMethod]
		public void isLocationOnBoard_returns_true_if_location_on_board()
		{
			//Arrange
			var board = new Testboard(TickTackToeBoard.TickTackToeToken.Available);

			//Act (no action needed)

			//Assert
			Assert.IsTrue(board.isLocationOnBoardWrapper(0, 0));
		}

		[TestMethod]
		public void isLocationOnBoard_returns_false_if_row_off_board()
		{
			//Arrange
			var board = new Testboard(TickTackToeBoard.TickTackToeToken.Available);

			//Act (no action needed)

			//Assert
			Assert.IsFalse(board.isLocationOnBoardWrapper(Testboard.RowCount+1, 0));
		}

		[TestMethod]
		public void isLocationOnBoard_returns_false_if_column_off_board()
		{
			//Arrange
			var board = new Testboard(TickTackToeBoard.TickTackToeToken.Available);

			//Act

			//Assert
			Assert.IsFalse(board.isLocationOnBoardWrapper(0, Testboard.ColumnCount+1));
		}

		[TestMethod]
		public void isLocationAvailableToPlay_returns_false_if_location_off_board()
		{
			//Arrange
			var board = new Testboard(TickTackToeBoard.TickTackToeToken.Available);

			//Act

			//Assert
			Assert.IsFalse(board.isLocationAvailableToPlayWrapper(Testboard.RowCount+1, Testboard.ColumnCount + 1));
		}

		[TestMethod]
		public void isLocationAvailableToPlay_returns_false_if_location_is_taken()
		{
			//Arrange
			var board = new Testboard(TickTackToeBoard.TickTackToeToken.Available);
			int column = 2;
			int row = 1;
			board.PlaceTokenOnBoard(TickTackToeBoard.TickTackToeToken.O, row, column);

			//Act

			//Assert
			Assert.IsFalse(board.isLocationAvailableToPlayWrapper(row, column));
		}

		[TestMethod]
		public void isLocationAvailableToPlay_returns_true_if_location_on_board_and_location_is_not_taken()
		{
			//Arrange
			var board = new Testboard(TickTackToeBoard.TickTackToeToken.Available);

			//Act

			//Assert
			Assert.IsTrue(board.isLocationAvailableToPlayWrapper(0,0));
		}

		private class StandardTestBoard : TickTackToeBoard
		{
			public TickTackToeToken[,] Board { get => base.board; }
			public override void DisplayBoard()
			{
				throw new NotImplementedException();
			}
		}

		private class Testboard : TickTackToeBoard
		{
			public const int RowCount = 2;
			public const int ColumnCount = 4;
			public Testboard(TickTackToeToken defaultToken)
			{
				board = new TickTackToeToken[RowCount, ColumnCount] { { defaultToken, defaultToken, defaultToken, defaultToken }, { defaultToken, defaultToken, defaultToken, defaultToken } };
			}

			public bool isLocationTakenWrapper(int row, int column)
			{
				return base.isLocationTaken(row, column);
			}

			public bool isLocationOnBoardWrapper(int row, int column)
			{
				return base.isLocationOnBoard(row, column);
			}

			public bool isLocationAvailableToPlayWrapper(int row, int column)
			{
				return base.isLocationAvailableToPlay(row, column);
			}

			public override void DisplayBoard()
			{
				throw new NotImplementedException();
			}
		}
	}
}
