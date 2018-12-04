using Dapper;
using Finance.Application.Repositories;
using Finance.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Finance.Infrastructure.SQLServer.Repositories
{
    public class CustomerReadOnlyRepository : ICustomerReadOnlyRepository, ICustomerWriteOnlyRepository
    {
        private readonly string _connectionString;

        public CustomerReadOnlyRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task Add(Customer customer)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string insertCustomerSQL = "INSERT INTO Customer (Id, Name, CPF) VALUES (@Id, @Name, @CPF)";
                DynamicParameters customerParameters = new DynamicParameters();
                customerParameters.Add("@id", customer.Id);
                customerParameters.Add("@name", (string)customer.Name, DbType.AnsiString);
                customerParameters.Add("@CPF", (string)customer.CPF, DbType.AnsiString);

                int customerRows = await db.ExecuteAsync(insertCustomerSQL, customerParameters);
            }
        }

        public async Task<Customer> Get(Guid id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string customerSQL = "SELECT * FROM Customer WHERE Id = @Id";
                Entities.Customer customer = await db
                    .QueryFirstOrDefaultAsync<Entities.Customer>(customerSQL, new { id });

                if (customer == null)
                    return null;

                string accountSQL = "SELECT * FROM Account WHERE CustomerId = @Id";
                IEnumerable<Guid> accounts = await db
                    .QueryAsync<Guid>(accountSQL, new { id });

                AccountCollection accountCollection = new AccountCollection();

                foreach (Guid accountId in accounts)
                {
                    accountCollection.Add(accountId);
                }

                Customer result = Customer.Load(
                    customer.Id,
                    customer.Name,
                    customer.CPF,
                    accountCollection);

                return result;
            }
        }

        public async Task Update(Customer customer)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string updateCustomerSQL = "UPDATE Customer SET Name = @Name, CPF = @CPF WHERE Id = @Id";
                int rowsAffected = await db.ExecuteAsync(updateCustomerSQL, customer);
            }
        }
    }
}
