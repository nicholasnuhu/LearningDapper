using Microsoft.Data.SqlClient;

namespace LearningDapper.Infrastructure.Interfaces
{
    public interface ISqlConnectionsFactory
    {
        SqlConnection CreateConnection();
    }
}