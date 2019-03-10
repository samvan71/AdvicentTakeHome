using System;
using System.Collections.Generic;
using System.Text;

namespace AdvicentTakeHome
{
    /// <summary>
    /// Interface of methods for Data Access for the College Cost Manager.
    /// </summary>
    public interface IDataAccess : IDisposable
    {
        /// <summary>
        /// Retrieves college information from a source.
        /// </summary>
        /// <returns>A List of College records.</returns>
        List<College> LoadCollegeInformation();

        /// <summary>
        /// Retrieves the singleton version of the data access.
        /// </summary>
        /// <returns></returns>
        IDataAccess GetDataAccess();
    }
}
