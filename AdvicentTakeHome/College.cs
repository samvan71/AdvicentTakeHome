using System;
using System.Collections.Generic;
using System.Text;

namespace AdvicentTakeHome
{
    /// <summary>
    /// Contains the necessary data for a college record.
    /// </summary>
    public class College
    {
        /// <summary>
        /// Name of the College
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Tuition for a student who lives in the same state.
        /// </summary>
        public long InStateTuition { get; set; }

        /// <summary>
        /// Tuition for a student who lives in a different state.
        /// </summary>
        public long OutStateTuition { get; set; }

        /// <summary>
        /// Cost for a student's room and board.
        /// </summary>
        public long RoomAndBoardCost { get; set; }
    }
}
