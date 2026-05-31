using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic_CoreTier.Interfaces.RepositoryInterfaces
{
    public interface IDbConnectionFactory
    {
        SqlConnection CreateConnection();
    }
}
