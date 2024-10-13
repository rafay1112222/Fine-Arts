using System;
using System.Collections.Generic;

namespace Institute_of_Fine_Arts.Models;

public partial class Award
{
    public int AwardId { get; set; }

    public int CompetitionId { get; set; }

    public int StudentId { get; set; }

    public string AwardName { get; set; } = null!;

    public string? AwardDescription { get; set; }

    public DateTime DateAwarded { get; set; }

    public virtual Competition Competition { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
