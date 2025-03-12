using System;
using System.Collections.Generic;

namespace CodeFirst.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int Age { get; set; }

    public string Pass { get; set; } = null!;
}
