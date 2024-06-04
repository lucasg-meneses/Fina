using Fina.Api.Data;
using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Request.Categories;
using Fina.Core.Response;
using Microsoft.EntityFrameworkCore;

namespace Fina.Api;

public class CategoryHandler(AppDbContext context) : ICategoryHandler
{
    public async Task<Response<Category?>> CreateAsync(CreateCategoryRequest request)
    {
        var category = new Category
        {
            UserId = request.UserId,
            Title = request.Title,
            Description = request.Description
        };

        try
        {
            await context.AddAsync(category);
            await context.SaveChangesAsync();
            return new Response<Category?>(category, 201, "Categoria criada com sucesso");
        }
        catch
        {
            return new Response<Category?>(null, 400, "Não foi possivel criar a categoria");
        }
    }

    public async Task<Response<Category?>> DeleteAsync(DeleteCategoryRequest request)
    {
        try
        {
            var category = await context.Categories
             .FirstOrDefaultAsync(x => x.UserId == request.UserId && x.Id == request.Id);
            if (category == null)
            {
                return new Response<Category?>(null, 404, "Categoria não encontrada.");
            }

            context.Categories.Remove(category);
            await context.SaveChangesAsync();

            return new Response<Category?>(category, message: "Categoria deletada com sucesso");

        }
        catch
        {

            return new Response<Category?>(null, 400, "Não Foi possivel deletar a categoria.");
        };
    }

    public async Task<PagedResponse<List<Category>?>> GetAllAsync(GetAllCategoryRequest request)
    {
        var query = context.Categories
        .AsNoTracking()
        .Where(x => x.UserId == request.UserId)
        .OrderBy(x => x.Title);
        var categories =  await query
                                .Skip((request.PageNumber - 1) * request.PageSize)
                                .Take(request.PageSize)
                                .ToListAsync();
        var count = await query.CountAsync();

        return new PagedResponse<List<Category>?>(categories, count,  request.PageNumber, request.PageSize);
    }

    public async Task<Response<Category?>> GetByIdAsync(GetCategoryByIdRequest request)
    {
        var category = await context.Categories
        .AsNoTracking()
        .FirstOrDefaultAsync(x => x.UserId == request.UserId && x.Id == request.Id);

        return category == null
            ? new Response<Category?>(null, 404, "Categoria não encontrada.")
            : new Response<Category?>(category, message: "Categoria encontrada com sucesso.");

    }

    public async Task<Response<Category?>> UpdateAsync(UpdatedCategoryRequest request)
    {
        try
        {
            var category = await context.Categories
            .FirstOrDefaultAsync(x => x.UserId == request.UserId && x.Id == request.Id);
            if (category == null)
            {
                return new Response<Category?>(null, 404, "Categoria não encontrada.");
            }

            category.Title = request.Title;
            category.Description = request.Description;
            context.Update(category);
            await context.SaveChangesAsync();

            return new Response<Category?>(category, message: "Categoria atualizada com sucesso");

        }
        catch
        {
            return new Response<Category?>(null, 400, "Não foi possivel atualizar a categoria");
        }

    }


}
