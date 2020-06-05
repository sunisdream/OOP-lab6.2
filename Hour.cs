using System;
using System.Collections.Generic;
using System.Text;

namespace Lab06___2
{
	class Hour : MetroStation
	{
		private int passengerAmount;
		private string comment;

		public Hour() { }
		public Hour(string n, int y, int passAm, string c) : base(n, y)
		{
			passengerAmount = passAm;
			comment = c;
		}

		public int GetPassengerAmount() { return passengerAmount; }
		public string GetComment() { return comment; }

		public override void ReadPassAmount()
		{
			Console.WriteLine("Enter passenger amount:");
			try
			{
				passengerAmount = Convert.ToInt32(Console.ReadLine());
			}
			catch (FormatException)
			{
				Console.WriteLine("Wrong format!");
			}
		}

		public override void ReadComment()
		{
			Console.WriteLine("Enter a comment:");
			comment = Console.ReadLine();
		}

		public void Output()
		{
			Console.WriteLine("Metro station name: {0}", name);
			Console.WriteLine("Year of opening: {0}", openYear);
			Console.WriteLine("Amount of passengers: {0}", passengerAmount);
			Console.WriteLine("Comment: {0}", comment);
		}

		public static int PassengersSum(ref List<Hour> hours)
		{
			int passSum = 0;
			foreach (Hour hour in hours)
			{
				passSum += hour.GetPassengerAmount();
			}
			return passSum;
		}

		public static Hour LeastPassengers(ref List<Hour> hours)
		{
			int leastPassengers = Int32.MaxValue;
			Hour leastPass = null;
			foreach (Hour hour in hours)
			{
				if (hour.GetPassengerAmount() < leastPassengers)
				{
					leastPassengers = hour.GetPassengerAmount();
					leastPass = hour;
				}
			}
			return leastPass;
		}

		public static Hour MostWordsInComment(ref List<Hour> hours)
		{
			int mostWords = 0;
			Hour mostCommHour = null;
			int curLen;
			foreach (Hour hour in hours)
			{
				curLen = hour.GetComment().Split(' ').Length;
				if (curLen > mostWords)
				{
					mostWords = curLen;
					mostCommHour = hour;
				}
			}
			return mostCommHour;
		}
	}
}
