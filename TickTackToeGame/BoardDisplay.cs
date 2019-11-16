using System;
using System.Collections.Generic;
using System.Reflection;
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

		public static string GetDescription(Enum en)
		{
			Type type = en.GetType();
			MemberInfo[] memInfo = type.GetMember(en.ToString());
			if (memInfo != null && memInfo.Length > 0)
			{
				object[] attrs = memInfo[0].GetCustomAttributes(typeof(BoardDisplay), false);
				if (attrs != null && attrs.Length > 0)
					return ((BoardDisplay)attrs[0]).Text;
			}
			return en.ToString();
		}
	}
}
