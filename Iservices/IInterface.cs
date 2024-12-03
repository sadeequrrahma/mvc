using mvc.Models;

namespace mvc.Iservices
{
    public interface IInterface
    {
        Task<int> AddInvoice(invoice invoice);
        Task<bool> UpdateInvoice(invoice invoice);
        Task<bool> DeleteInvoice(int id);
        Task<IEnumerable<invoice>> GetAllInvoice();
        Task<invoice?> GetInvoiceById(int id);

    }
}
