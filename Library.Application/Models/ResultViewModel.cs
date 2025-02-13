using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Library.Application.Models;

public class ResultViewModel
{

    public bool IsSucess { get; set; }
    public string Message { get; set; }

    public ResultViewModel(bool isSucess = true, string message="")
    {
        IsSucess = isSucess;
        Message = message;
    }

    public static ResultViewModel Sucess()
        => new();

    public static ResultViewModel Sucess(string message)
        => new(true, message);

    public static ResultViewModel Error(string message)
        => new(false, message);

}

public class ResultViewModel<T>: ResultViewModel
{

    public T? Data { get; set; }

    public ResultViewModel(T? data, bool isSucess = true, string message = "")
         : base(isSucess, message)
    {
        Data = data;
    }

    public static ResultViewModel<T> Sucess(T data)
        => new(data);

    public static ResultViewModel<T> Error(string message)
        => new(default, false, message);
}