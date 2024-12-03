using Dapper;
using mvc.Database; // Ensure you have a DbContext for connection handling
using mvc.Iservices;
using mvc.Models;
using System.Data;

namespace mvc.Repository
{
    public class invoice : IInterface
    {
        private readonly database _context;

        public invoice(database context)
        {
            _context = context;
        }

        public async Task<int> AddInvoice(Models.invoice invoice)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@CustomerName", invoice.customername);
            parameters.Add("@Address", invoice.address);
            parameters.Add("@description", invoice.description);
            parameters.Add("@Quantity", invoice.quantity);
            parameters.Add("@Discount1", invoice.discount1);
            parameters.Add("@Discount2", invoice.discount2);
            parameters.Add("@AddTax", invoice.addtax);
            parameters.Add("@Date", invoice.date);
            parameters.Add("@AreaId", invoice.Areaid);
            parameters.Add("@BatchNo", invoice.batchno);
            parameters.Add("@Price", invoice.price);
            parameters.Add("@ExpiryDate", invoice.expirydate);
            parameters.Add("@mdelete",invoice.mdelete);

            using (var conn = _context.CreateConnection())
            {
                var result = await conn.ExecuteAsync("AddInvoice", parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<IEnumerable<Models.invoice>> GetAllInvoice()
        {
            using (var conn = _context.CreateConnection())
            {
                return await conn.QueryAsync<Models.invoice>("GetAllInvoices", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<Models.invoice?> GetInvoiceById(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@InvoiceNo", id);

            using (var conn = _context.CreateConnection())
            {
                return await conn.QueryFirstOrDefaultAsync<Models.invoice>("GetInvoiceById", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<bool> UpdateInvoice(Models.invoice invoice)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@InvoiceNo", invoice.invoiceno);
            parameters.Add("@CustomerName", invoice.customername);
            parameters.Add("@Address", invoice.address);
            parameters.Add("@description", invoice.description);
            parameters.Add("@Quantity", invoice.quantity);
            parameters.Add("@Discount1", invoice.discount1);
            parameters.Add("@Discount2", invoice.discount2);
            parameters.Add("@AddTax", invoice.addtax);
            parameters.Add("@Date", invoice.date);
            parameters.Add("@AreaId", invoice.Areaid);
            parameters.Add("@BatchNo", invoice.batchno);
            parameters.Add("@Price", invoice.price);
            parameters.Add("@ExpiryDate", invoice.expirydate);

            using (var conn = _context.CreateConnection())
            {
                var result = await conn.ExecuteAsync("UpdateInvoice", parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<bool> DeleteInvoice(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@InvoiceNo", id);

            using (var conn = _context.CreateConnection())
            {
                var result = await conn.ExecuteAsync("DeleteInvoice", parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }
    }
}
