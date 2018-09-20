using System;
using System.IO;

namespace StringCompare
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("This application will remove all lines over the specified line length");
			Console.WriteLine("Before continuing, please move the source .txt file to your desktop and name it \"source.txt\"");
			Console.Write("Press enter to continue...");
			Console.ReadKey();
			Console.Write("Please enter the new desired line length: ");

			// Loops until user enters an integer value.
			bool again = true;
			int len = 0;
			while (again == true)
			{
				try
				{
					len = Convert.ToInt16(Console.ReadLine());
					again = false;
				}
				catch
				{
					Console.Write("Please enter an integer for the desired length: ");
				}
			}

			// Store path to local desktop in a string
			string desktop = (System.Environment.GetEnvironmentVariable("USERPROFILE")) + ("\\Desktop\\");

			// Temporary string[] object storing each line from our source.txt file.
			string[] sourceFile = System.IO.File.ReadAllLines(desktop + "source.txt");

			// Invoke StreamWriter class to create and write to a text file
			StreamWriter sWriter = new StreamWriter(desktop + "newFile.txt");

			// Iterate through each line in source.txt and appends to newFile.txt using the StreamWriter object "sWriter"
			foreach (string line in sourceFile)
			{
				if (line.Length <= len)
				{
					sWriter.WriteLine(line);
				}
			}
			sWriter.Close();
			Console.WriteLine("Finished writing file to " + desktop + "newFile.txt");
			Console.ReadKey();
		}
	}
}
