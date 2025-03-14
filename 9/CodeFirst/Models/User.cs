using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeFirst.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Name { get; set; }
    [Required]
    public int Age { get; set; }

    public string Pass { get; set; } = null!;
}
