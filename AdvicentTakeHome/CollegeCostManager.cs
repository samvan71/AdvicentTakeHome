using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdvicentTakeHome
{
    /// <summary>
    /// Provides methods for getting college cost information and retrieving said information.
    /// </summary>
    class CollegeCostManager
    {
        private List<College> collegeData;

        public CollegeCostManager()
        {
            using (IDataAccess dataAccess = new CSVDataAccess())
            {
                collegeData = dataAccess.LoadCollegeInformation();
            }
        }

        public CollegeCostManager(IDataAccess dataAccess)
        {
            using (dataAccess)
            {
                collegeData = dataAccess.LoadCollegeInformation();
            }
        }

        /// <summary>
        /// Gets the cost of a designated college.
        /// </summary>
        /// <param name="collegeName">College who's cost is to be retrieved.</param>
        /// <param name="isRoomAndBoardRequest">Whether to include the room and board in the cost.</param>
        /// <param name="isOutState">Whether the student is from the same state the college is located in.</param>
        /// <returns></returns>
        public long GetCollegeCost(string collegeName, bool isRoomAndBoardRequest = true, bool isOutState = false)
        {
            long output;

            if (collegeName != string.Empty)
            {
                // Get the college.
                College college = collegeData.Where(c => c.Name == collegeName).FirstOrDefault();

                if (college != null)
                {
                    // Add up the costs that are necessary.
                    output = isOutState ? college.OutStateTuition : college.InStateTuition;
                    output += isRoomAndBoardRequest ? college.RoomAndBoardCost : 0;
                }
                else
                {
                    throw new Exception("Error: College not found");
                }
            }
            else
            {
                throw new Exception("Error: College name is required");
            }
            
            return output;
        }
    }
}
