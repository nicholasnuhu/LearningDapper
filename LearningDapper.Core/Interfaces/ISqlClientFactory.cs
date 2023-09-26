using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningDapper.Core.Interfaces
{
    public interface ISqlClientFactory
    {
        Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters);

        Task SaveData<T>(string storedProcedure, T parameter);
    }
}