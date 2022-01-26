using System;
using System.IO;
using System.Collections.Generic;

namespace Journal
{
	class Application
	{
		static void Main(string[] args)
		{
			Program.Run();	
		}
	}

	public class Program
	{
		static List<string> DataArr = new List<string>();
		static string data;
		static bool Flag = true;

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
