﻿using Library.Core.Entities;

namespace Library.Application.Models;

public class CreateUserInputModel
{
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime Birthdate { get; set; }

    public User ToEntity()
     => new(Name, Email, Birthdate);
}
