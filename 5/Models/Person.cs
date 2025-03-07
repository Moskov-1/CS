using Microsoft.AspNetCore.Mvc.Rendering; // for SelectListItem
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // for List
namespace Core_1.Models;


public class Person
{
    public int Id { get; set; }

    public string? Name { get; set; }
    public int Age { get; set; }
    [Required]
    [Display(Name = "Favorite Language")]
    public string? FavLang { get; set; }
    public string? Gender { get; set; }
    [Phone]
    public string? Phone { get; set; }

    [Required]
    [MinLength(4)]
    public string? Pass { get; set; }
    [Required]
    [Compare("Pass")]
    public string? ConfirmPass { get; set; }
}