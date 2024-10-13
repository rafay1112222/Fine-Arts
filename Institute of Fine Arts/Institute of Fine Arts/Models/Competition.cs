using System;
using System.Collections.Generic;

namespace Institute_of_Fine_Arts.Models;

public partial class Competition
{
    public int CompetId { get; set; }

    public string Title { get; set; } = null!;

    public string ImageFilePath { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string Conditions { get; set; } = null!;

    public string AwardDetails { get; set; } = null!;

    public int? WinnerId { get; set; }

    public virtual ICollection<Award> Awards { get; set; } = new List<Award>();

    public virtual ICollection<Submission> Submissions { get; set; } = new List<Submission>();

    public virtual Student? Winner { get; set; }
}
