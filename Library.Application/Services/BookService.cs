using Library.Application.Models;
using Library.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Services;

internal class BookService : IBookService
{
    private readonly BooksDbContext _context;

    public BookService(BooksDbContext context)
    {
        _context = context;
    }

  

    public ResultViewModel<List<BookItemViewModel>> GetAll()
    {
        var books = _context.Books.Where(e => !e.IsDeleted);
        var model = books.Select(x => BookItemViewModel.FromEntity(x)).ToList();

        return ResultViewModel<List<BookItemViewModel>>.Sucess(model);
    }

    public ResultViewModel<BookViewModel> GetById(int id)
    {
        var book = _context.Books.SingleOrDefault(e => e.Id == id);

        if (book is null)
        {
            return ResultViewModel<BookViewModel>.Error("Projeto não existe!");
        }

        var model = BookViewModel.FromEntity(book);

        return ResultViewModel<BookViewModel>.Sucess(model);
    }

    public ResultViewModel<int> Insert(CreateBookInputModel model)
    {
        var book = model.ToEntity();
        _context.Books.Add(book);
        _context.SaveChanges();

        return ResultViewModel<int>.Sucess(book.Id);
    }

    public ResultViewModel Update(UpdateBookInputModel model)
    {

        var book = _context.Books.FirstOrDefault(e => e.Id == model.IdBook);

        if (book is null)
        {
            return ResultViewModel.Error("Livro não existe!");
        }

        book.Update(model.Title, model.Autor, model.ISBN, model.AnoDePublicacao);
        _context.Books.Update(book);
        _context.SaveChanges();

        return ResultViewModel.Sucess();
    }

    public ResultViewModel Delete(int id)
    {
        var book = _context.Books.FirstOrDefault(e => e.Id == id);

        if (book is null)
        {
            return ResultViewModel.Error("Livro não existe!");
        }

        book.SetAsDeleted();
        _context.Books.Update(book);
        _context.SaveChanges();

        return ResultViewModel.Sucess();
    }
}
