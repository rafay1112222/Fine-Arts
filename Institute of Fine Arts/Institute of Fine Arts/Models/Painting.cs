using System;
using System.Collections.Generic;

namespace Institute_of_Fine_Arts.Models;

public partial class Painting
{
    public int PaintingId { get; set; }

    public int StdId { get; set; }

    public int CompetId { get; set; }

    public string ImageFilePath { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime SubmissionDate { get; set; }

    public virtual Competition Compet { get; set; } = null!;

    public virtual ICollection<PaintEx> PaintExes { get; set; } = new List<PaintEx>();

    public virtual Student Std { get; set; } = null!;

    public virtual ICollection<Submission> Submissions { get; set; } = new List<Submission>();
}
