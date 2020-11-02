using Microsoft.Extensions.Configuration;
using PSCore.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace PSCore.Repositories
{
    public class UserRepository : Repository<HVNUser>, IUserRepository
    {
        public IConfiguration Configuration { get; }

        public UserRepository(IConfiguration config)
        {
            Configuration = config;
        }

        public HVNUser Me()
        {
            string connStr = Configuration.GetConnectionString("PSDbConnection");

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("sp_me", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@caller_name", "c1306948");

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows)
                            throw new Exception("wrong_account");

                        if (reader.Read())
                        {
                            return new HVNUser()
                            {
                                userName = reader["user_name"].ToString(),
                                userAccountName = reader["user_ad"].ToString()
                            };
                        }
                        else
                            return null;
                    }
                }
            }

        }

        public async Task<HVNUser> GetHVNUserAsync(CancellationToken cancellationToken)
        {
            return this.Me();
        }

        public Task<HVNUser> GetHVNUserByIdAsync(Guid orderId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<HVNUser>> GetHVNUserByGuidAsync(Guid customerId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
