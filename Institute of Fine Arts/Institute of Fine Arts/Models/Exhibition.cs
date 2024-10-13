using System;
using System.Collections.Generic;

namespace Institute_of_Fine_Arts.Models;

public partial class Exhibition
{
    public int ExhibitionId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string Location { get; set; } = null!;

    public DateTime Date { get; set; }

    public string? OrganizerDetails { get; set; }

    public virtual ICollection<PaintEx> PaintExes { get; set; } = new List<PaintEx>();
}
