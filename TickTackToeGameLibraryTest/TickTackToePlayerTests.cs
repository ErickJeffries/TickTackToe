using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TickTackToeGameLibrary;

namespace TickTackToeGameLibraryTest
{
	[TestClass]
	public class TickTackToePlayerTests
	{
		[TestMethod]
		public void ToString_Displays_Name_And_token()
		{
			//Arrange
			string name = "Short Name";
			var token = TickTackToeBoard.TickTackToeToken.O;
			var player = new TickTackToePlayer(name, token);

			//Act
			var result = player.ToString();

			//Assert
			Assert.IsTrue(result.Contains(name));
			Assert.IsTrue(result.Contains(token.ToString()));
		}

		[TestMethod]
		public void Cant_create_player_with_available_token()
		{
			//Arrange
			string name = "Short Name";
			var token = TickTackToeBoard.TickTackToeToken.Available;

			//Act & Assert
			Assert.ThrowsException<InvalidOperationException>(() => new TickTackToePlayer(name, token));
		}

		[TestMethod]
		public void Can_create_player_with_X_token()
		{
			//Arrange
			string name = "Short Name";
			var token = TickTackToeBoard.TickTackToeToken.X;

			//Act
			var player = new TickTackToePlayer(name, token);

			//Assert
			Assert.IsTrue(player.Token == token);
		}

		[TestMethod]
		public void Can_create_player_with_O_token()
		{
			//Arrange
			string name = "Short Name";
			var token = TickTackToeBoard.TickTackToeToken.O;

			//Act
			var player = new TickTackToePlayer(name, token);

			//Assert
			Assert.IsTrue(player.Token == token);
		}
	}
}
