using System;
using System.IO;
using System.Collections.Generic;

namespace Journal
{
	class Application
	{
		static void Main(string[] args)
		{
			// Running the Program...
			Program.Run();	
		}
	}

	public class Program
	{
		//Variable Declaration
		static List<string> DataArr = new List<string>();
		static string data;
		static bool Flag = true;

		// Method to handle recording...
		public static void Record()
		{
			while (data != "stop")
			{
				Console.Write(">> ");
				data = Console.ReadLine();
				if (data != "stop")
					DataArr.Add(data);
			}
			Flag = false;
			SaveData(DataArr);
		}

		// Method to Run the whole program...
		public static void Run()
		{
			string input;
			do
			{
				Console.Write("> ");
				input = Console.ReadLine();
				if (input == "start")
					Record();
			} while (Flag);
		}

		// Method to Save All data to a file...
		public static void SaveData(List<string> arr)
		{
			DateTime curr = DateTime.Now;
			string path = $"{curr.ToString("MM-dd-yyyy-[HH:mm:ss]")}.txt";
			using (StreamWriter sw = File.CreateText(path))
			{
				sw.WriteLine("\nCaptain's Journal");
				sw.WriteLine($"{curr}\n");
				foreach (var item in arr)
					sw.WriteLine(item);
				sw.WriteLine("\nJean-Luc Picard");
			}
		}
	}
}
