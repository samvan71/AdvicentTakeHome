using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdvicentTakeHome
{
    /// <summary>
    /// Retrieves college data from a CSV file.
    /// </summary>
    public class CSVDataAccess : IDataAccess
    {
        private static string CSV_FILE_NAME = @"college_costs.csv";
        private static char FILE_DELIMITER = ',';
        private static int HEADER_LINES = 1;
        private CSVDataAccess instance;

        /// <summary>
        /// Removes the instance.
        /// </summary>
        public void Dispose()
        {
            instance = null;
        }

        /// <summary>
        /// Retrieves the singleton instance.
        /// </summary>
        public IDataAccess GetDataAccess()
        {
            if (instance == null)
            {
                instance = new CSVDataAccess();
            }

            return instance;
        }

        /// <summary>
        /// Gets the college cost information.
        /// </summary>
        /// <returns>List of College information.</returns>
        public List<College> LoadCollegeInformation()
        {
            List<College> colleges = new List<College>();

            using (var reader = new StreamReader(CSV_FILE_NAME))
            {
                // Skip over the files header lines.
                for (int i = 0; i < HEADER_LINES; i++)
                {
                    reader.ReadLine();
                }

                // Read the csv file.
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(FILE_DELIMITER);

                    long.TryParse(values[1], out long inState);
                    long.TryParse(values[2], out long outState);
                    long.TryParse(values[3], out long roomAndBoard);

                    colleges.Add(new College()
                    {
                        Name = values[0],
                        InStateTuition = inState,
                        OutStateTuition = outState,
                        RoomAndBoardCost = roomAndBoard
                        
                    });
                }
            }

            return colleges;
        }
    }
}
