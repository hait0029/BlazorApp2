using System;
using System.Collections.Generic;

namespace BlazorApp2.Models;

public partial class Todolist
{
    public int Id { get; set; }

    public string? User { get; set; }

    public string? Name { get; set; }
}
