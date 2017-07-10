//.Net4.5 - tested on dotnetfiddle
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Program
{
	private static string IsPalindrome(string val)
	{

		if (string.IsNullOrEmpty(val)) return "UNDETERMINED";

		//https://stackoverflow.com/questions/1152887/can-you-reverse-order-a-string-in-one-line-with-linq-or-a-lambda-expression
		var reversed = new string(Enumerable.Range(1, val.Length).Select(i => val[val.Length - i]).ToArray());
    	var result = string.Compare(val, reversed, true);
		if (result == 0) return "TRUE";

		return "FALSE";

	}

	private static string AngleTM(string time)
	{
		var hour = 0;
		var min = 0;
		//https://en.wikipedia.org/wiki/Clock_angle_problem
		if (string.IsNullOrEmpty(time) ||
			time.Length <5 ||
			!int.TryParse(time.Substring(0,2), out hour) ||
			!int.TryParse(time.Substring(3,2), out min)) {
			hour = DateTime.Now.Hour;
			min = DateTime.Now.Minute;
		}

		var ang = 0.5 * (60 * hour - 11 * min);
		if (ang > 180) ang = 360 - ang;
		return String.Format("{0} degrees", ang);
	}

	private static string SPC()
	{
		var res = new StringBuilder();
		for (int i= 1; i <=100; i++)
		{
			var me = i.ToString();
			res.Append(
				(i % 3 == 0 && i % 5 == 0)? "POP":
					(i % 3 == 0)? "SNAP" :
					(i % 5 == 0)? "CRACKLE" :
					me
				);
		}

		return res.ToString();
	}

	public static void Main()
	{
		//1. IsPalindrome
		Console.WriteLine("1. IsPalindrome");
		Console.WriteLine(IsPalindrome("emordnilaP"));
		Console.WriteLine(IsPalindrome(""));
		Console.WriteLine(IsPalindrome("a"));
		Console.WriteLine(IsPalindrome("Kayak"));
		Console.WriteLine(IsPalindrome("No lemon, no melon"));
		Console.WriteLine();

		//3. AngleTM
		Console.WriteLine("3. AngleTM");
		Console.WriteLine(AngleTM(null));
		Console.WriteLine(AngleTM(""));
		Console.WriteLine(AngleTM("12:00:00"));
		Console.WriteLine(AngleTM("12:15:00"));
		Console.WriteLine(AngleTM("11:40:00"));
		Console.WriteLine();

		//5. CRACKlEPOPSNAP
		Console.WriteLine("5. CRACKlEPOPSNAP");
		Console.WriteLine(SPC());

	}
}
