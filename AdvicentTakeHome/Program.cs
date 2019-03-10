using System;
using System.Collections.Generic;

namespace AdvicentTakeHome
{
    class Program
    {
        static void Main(string[] args)
        {
            using (CSVDataAccess dataAccess = new CSVDataAccess())
            {
                CollegeCostManager costManager = new CollegeCostManager();

                string input = string.Empty;

                // Enter quit to exit the loop.
                while (input != "Quit")
                {
                    // Get the needed information.
                    Console.WriteLine("Enter college to find, or quit to quit: ");
                    string collegeName = Console.ReadLine();

                    if (collegeName.ToLower() == "quit")
                    {
                        break;
                    }

                    Console.WriteLine("Is student out of their home state? (Y/N)");
                    bool isOutOfState = Console.ReadLine().ToLower() == "y";

                    Console.WriteLine("Include room and board? (Y/N)");
                    bool includeRoomAndBoard = Console.ReadLine().ToLower() == "y";

                    // Execute the method.
                    try
                    {
                        Console.WriteLine(costManager.GetCollegeCost(collegeName, includeRoomAndBoard, isOutOfState));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}
