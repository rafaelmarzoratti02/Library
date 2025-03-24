using FluentValidation;
using FluentValidation.AspNetCore;
using Library.Application.Commands.BookCommands.InsertBook;
using Library.Application.Commands.LoanCommands.InsertLoan;
using Library.Application.Models;
using Library.Application.Services;


using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Application;

public static class ApplicationModule
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services
            .AddServices()
            .AddHandlers()
            .AddValidators();
        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ILoanService, LoanService>();

        return services;
    }

    public static IServiceCollection AddHandlers(this IServiceCollection services)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining <InsertBookCommand>());
        services.AddTransient<IPipelineBehavior<InsertLoanCommand, ResultViewModel<int>>, ValidateInsertLoanCommandBehavior>();
        return services;
    }

    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation().AddValidatorsFromAssemblyContaining<InsertBookCommand>();
        return services;
    }
}
