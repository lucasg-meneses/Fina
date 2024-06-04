
using Fina.Api.Data;
using Fina.Core;
using Fina.Core.Enums;
using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Request.Transactions;
using Fina.Core.Response;
using Microsoft.EntityFrameworkCore;

namespace Fina.Api;

public class TransactionHandler(AppDbContext context) : ITransactionHandler
{
    public async Task<Response<Transaction?>> CreateAsync(CreateTransactionRequest request)
    {
        if (request is { TransactionType: ETransactionType.Withdraw, Amount: >= 0 })
        {
            request.Amount *= -1;
        }

        var Transaction = new Transaction
        {
            Amount = request.Amount,
            Title = request.Title,
            TransactionType = request.TransactionType,
            CategoryId  = request.CategoryId,
            UserId = request.UserId
        };

        try
        {
            await context.AddAsync(Transaction);
            await context.SaveChangesAsync();
            return new Response<Transaction?>(Transaction, 201, "Transação criada com sucesso");
        }
        catch
        {
            return new Response<Transaction?>(null, 400, "Não foi possivel criar a Transação");
        }
    }

    public async Task<Response<Transaction?>> DeleteAsync(DeleteTransactionRequest request)
    {
        try
        {
            var transaction = await context.Transactions
             .FirstOrDefaultAsync(x => x.UserId == request.UserId && x.Id == request.Id);
            if (transaction == null)
            {
                return new Response<Transaction?>(null, 404, "Transação não encontrada.");
            }

            context.Transactions.Remove(transaction);
            await context.SaveChangesAsync();

            return new Response<Transaction?>(transaction, message: "Transação deletada com sucesso");

        }
        catch
        {

            return new Response<Transaction?>(null, 400, "Não Foi possivel deletar a Transação.");
        };
    }

    public async Task<PagedResponse<List<Transaction>?>> GetByPeriodAsync(GetTransactionByPeriodRequest request)
    {
        try
        {
            request.StartDate ??= DateTime.Now.GetFirstDay();
            request.EndDate ??= DateTime.Now.GetLastDay();
        }
        catch
        {
            return new PagedResponse<List<Transaction>?>(null, code: 400, message: "Não foi possivel definir um periodo das transações");
        }

        try
        {
            var query = context
                        .Transactions
                        .AsNoTracking()
                        .Where(x => x.PaidOrReceiveAt >= request.StartDate &&
                                    x.PaidOrReceiveAt <= request.EndDate &&
                                    x.UserId == request.UserId)
                        .OrderBy(x => x.PaidOrReceiveAt);
            var transactions = await query
                        .Skip((request.PageNumber - 1) * request.PageSize)
                        .Take(request.PageSize)
                        .ToListAsync();
            var count = await query.CountAsync();

            return new PagedResponse<List<Transaction>?>(transactions, count, request.PageNumber, request.PageSize);


        }
        catch
        {
            return new PagedResponse<List<Transaction>?>(null, 400, message: "Não foi possivel listar as Transações");
        }

    }

    public async Task<Response<Transaction?>> GetByIdAsync(GetTransactionByIdRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<Response<Transaction?>> UpdateAsync(UpdatedTransactionRequest request)
    {
        throw new NotImplementedException();
    }

}
