using Library.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Services;

public interface IBookService
{
    ResultViewModel<List<BookItemViewModel>> GetAll();
    ResultViewModel<BookViewModel> GetById(int id);
    ResultViewModel<int> Insert(CreateBookInputModel model);
    ResultViewModel Update(UpdateBookInputModel model);
    ResultViewModel Delete(int id);

}
