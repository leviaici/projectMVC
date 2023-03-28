using incercareProiect.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MvcMovie.Models;

public class VeganTypeViewModel
{
    public List<Vegan>? Vegans { get; set; }
    public SelectList? Types { get; set; }
    public string? DishType { get; set; }
    public string? SearchString { get; set; }
}