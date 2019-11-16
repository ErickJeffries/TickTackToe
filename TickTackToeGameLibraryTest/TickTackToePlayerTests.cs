using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TickTackToeGameLibrary;

namespace TickTackToeGameLibraryTest
{
	[TestClass]
	class TickTackToePlayerTests
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
			var token = TickTackToeBoard.TickTackToeToken.O;

			//Act & Assert
			Assert.ThrowsException<InvalidOperationException>(() => new TickTackToePlayer(name, token));
		}
	}
}
