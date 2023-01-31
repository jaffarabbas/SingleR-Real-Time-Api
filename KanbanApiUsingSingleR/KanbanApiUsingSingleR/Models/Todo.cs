using System;
using System.Collections.Generic;

namespace KanbanApiUsingSingleR.Models;

public partial class Todo
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public DateTime? Createdat { get; set; }
}
