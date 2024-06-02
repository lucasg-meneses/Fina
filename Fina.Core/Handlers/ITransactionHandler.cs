using System.Transactions;
using Fina.Core.Request.Transactions;
using Fina.Core.Response;

namespace Fina.Core.Handlers
{

    public interface ITransactionHandler
    {
        Task<Response<Transaction?>> CreateAsync(CreateTransactionRequest request);
        Task<Response<Transaction?>> DelateAsync(DeleteTransactionRequest request);
        Task<Response<Transaction?>> UpdateAsync(UpdatedTransactionRequest request);
        Task<Response<Transaction?>> GetByIdAsync(GetTransactionByIdRequest request);
        Task<PagedResponse<List<Transaction>?>> GetAllAsync(GetTransactionByPeriodRequest request);
    }
}
