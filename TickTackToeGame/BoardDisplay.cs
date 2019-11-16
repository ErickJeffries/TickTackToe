using System;
using System.Collections.Generic;
using System.Text;

namespace TickTackToeGameLibrary
{
	public class BoardDisplay : Attribute
	{
		public string Text;

		public BoardDisplay(string text)
		{
			Text = text;
		}
	}
}
