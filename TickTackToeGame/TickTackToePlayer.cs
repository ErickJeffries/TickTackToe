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
			Token = token;
		}

		public override string ToString()
		{
			return $"{Name} {Token.ToString()}'s";
		}
	}
}
