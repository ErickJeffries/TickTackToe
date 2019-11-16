using System;
using System.Collections.Generic;
using System.Text;

namespace TickTackToeGameLibrary
{
	public class TickTackToePlayer
	{
		public string Name { get; private set; }
		public TickTackToeBoard.TickTackToeToken Token { get; private set; }

		public TickTackToePlayer(string name, TickTackToeBoard.TickTackToeToken token)
		{
			Name = name;

			if (token == TickTackToeBoard.TickTackToeToken.Available)
				throw new InvalidOperationException($"{TickTackToeBoard.TickTackToeToken.Available} is not a valid token");

			Token = token;
		}

		public override string ToString()
		{
			return $"{Name} {Token.ToString()}'s";
		}
	}
}
