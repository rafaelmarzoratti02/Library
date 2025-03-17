using FluentValidation;
using Library.Application.Commands.BookCommands.InsertBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Validators;

public class InsertBookValidator : AbstractValidator<InsertBookCommand>
{
    public InsertBookValidator()
    {
        RuleFor(x => x.ISBN)
            .Length(13)
            .WithMessage("ISBN deve ter 13 caracteres");
        RuleFor(x => x.Autor)
            .MaximumLength(50)
            .WithMessage("Nome do autor não pode ter mais de 50 caracteres");
    }
}
