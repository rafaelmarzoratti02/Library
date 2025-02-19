﻿using Library.Application.Models;
using Library.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Queries.BookQueries.GetAllBooks;

internal class GetAllBooksHandler : IRequestHandler<GetAllBooksCommand, ResultViewModel<List<BookItemViewModel>>>
{

    private readonly BooksDbContext _context;

    public GetAllBooksHandler(BooksDbContext context)
    {
        _context = context;
    }

    public async Task<ResultViewModel<List<BookItemViewModel>>> Handle(GetAllBooksCommand request, CancellationToken cancellationToken)
    {
        var books = await _context.Books.Where(e => !e.IsDeleted).ToListAsync();

        var model = books.Select(x => BookItemViewModel.FromEntity(x)).ToList();

        return ResultViewModel<List<BookItemViewModel>>.Sucess(model);
    }
}
