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

			//Act

			//Assert
		}

		[TestMethod]
		public void Board_gets_constructed_with_3_by_3_dimensions()
		{
			//Arrange

			//Act

			//Assert
		}

		[TestMethod]
		public void GetValueAtLocation_returns_accurate_value()
		{
			//Arrange

			//Act

			//Assert
		}

		[TestMethod]
		public void GetValueAtLocation_throws_error_when_invalid_location_provided()
		{
			//Arrange

			//Act

			//Assert
		}

		[TestMethod]
		public void AnyMovesLeft_is_true_when_board_still_has_spaces_available()
		{
			//Arrange

			//Act

			//Assert
		}

		[TestMethod]
		public void AnyMovesLeft_is_false_when_board_still_has_no_spaces_available()
		{
			//Arrange

			//Act

			//Assert
		}

		[TestMethod]
		public void PlaceTokenOnBoard_puts_token_in_available_spot_on_board()
		{
			//Arrange

			//Act

			//Assert
		}

		[TestMethod]
		public void PlaceTokenOnBoard_throws_exception_when_spot_not_available_on_board()
		{
			//Arrange

			//Act

			//Assert
		}

		[TestMethod]
		public void isLocationTaken_returns_true_if_taken_by_X()
		{
			//Arrange

			//Act

			//Assert
		}

		[TestMethod]
		public void isLocationTaken_returns_true_if_taken_by_O()
		{
			//Arrange

			//Act

			//Assert
		}

		[TestMethod]
		public void isLocationTaken_returns_false_if_not_taken()
		{
			//Arrange

			//Act

			//Assert
		}

		[TestMethod]
		public void isLocationOnBoard_returns_true_if_location_on_board()
		{
			//Arrange

			//Act

			//Assert
		}

		[TestMethod]
		public void isLocationOnBoard_returns_false_if_row_off_board()
		{
			//Arrange

			//Act

			//Assert
		}

		[TestMethod]
		public void isLocationOnBoard_returns_false_if_column_off_board()
		{
			//Arrange

			//Act

			//Assert
		}

		[TestMethod]
		public void isLocationAvailableToPlay_returns_false_if_location_off_board()
		{
			//Arrange

			//Act

			//Assert
		}

		[TestMethod]
		public void isLocationAvailableToPlay_returns_false_if_location_is_taken()
		{
			//Arrange

			//Act

			//Assert
		}

		[TestMethod]
		public void isLocationAvailableToPlay_returns_true_if_location_on_board_and_location_is_not_taken()
		{
			//Arrange

			//Act

			//Assert
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
