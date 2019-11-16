using System;
using TickTackToeGameLibrary;

namespace TickTackToeConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			TickTackToeGame game = new ConsoleTickTackToeGame();
			game.SetupPlayers();
			game.StartGame();

			Console.WriteLine("End of Application");
		}
	}
}
