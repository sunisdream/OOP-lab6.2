using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lab06___2
{
	abstract class MetroStation : IMetroStation
	{
		protected string name;
		protected int openYear;

		public MetroStation() { }
		public MetroStation(string n, int y)
		{
			name = n;
			openYear = y;
		}
		public static void AddItem(ref List<Hour> hours)
		{
			Hour newHour = new Hour();
			newHour.ReadName();
			newHour.ReadYear();
			newHour.ReadPassAmount();
			newHour.ReadComment();
			hours.Add(newHour);
		}

		public static List<Hour> ReadData()
		{
			List<Hour> hours = new List<Hour>();

			Console.WriteLine("Enter file name:");
			string filename = Console.ReadLine();

			try
			{
				StreamReader reader = new StreamReader(filename);
				string name = "";
				int year = 0;
				int passAm = 0;
				string com = "";
				try
				{
					while (!reader.EndOfStream)
					{
						name = reader.ReadLine();
						year = Convert.ToInt32(reader.ReadLine());
						passAm = Convert.ToInt32(reader.ReadLine());
						com = reader.ReadLine();
						hours.Add(new Hour(name, year, passAm, com));
					}
				}
				catch (FormatException)
				{
					Console.WriteLine("Wrong format!");
				}

				reader.Close();
			}
			catch (FileNotFoundException)
			{
				Console.WriteLine("There's no such file with name {0}", filename);
			}
			return hours;
		}

		public static void DeleteItem(ref List<Hour> hours)
		{
			Console.WriteLine("Enter index of item to delete:");
			try
			{
				int ind = Convert.ToInt32(Console.ReadLine());
				hours.RemoveAt(ind);
			}
			catch (FormatException)
			{
				Console.WriteLine("Wrong format!");
			}
		}

		public static void EditItem(ref List<Hour> hours)
		{
			Console.WriteLine("Enter index of item to edit:");
			try
			{
				int ind = Convert.ToInt32(Console.ReadLine());
				hours[ind].ReadName();
				hours[ind].ReadYear();
				hours[ind].ReadPassAmount();
				hours[ind].ReadComment();
			}
			catch (FormatException)
			{
				Console.WriteLine("Wrong format!");
			}
		}

		public static void OutputList(ref List<Hour> hours)
		{
			int size = hours.Count;
			for (int i = 0; i < size; i++)
			{
				Console.WriteLine("\nHour #{0}:", i + 1);
				hours[i].Output();
			}
		}

		public void ReadName()
		{
			Console.WriteLine("Enter metro station name:");
			name = Console.ReadLine();
		}

		public void ReadYear()
		{
			Console.WriteLine("Enter opening year of station:");
			try
			{
				openYear = Convert.ToInt32(Console.ReadLine());
			}
			catch (FormatException)
			{
				Console.WriteLine("Wrong format!");
			}
		}

		public abstract void ReadPassAmount();
		public abstract void ReadComment();
	}
}
