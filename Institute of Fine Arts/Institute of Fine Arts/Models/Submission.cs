using System;
using System.Collections.Generic;

namespace Institute_of_Fine_Arts.Models;

public partial class Submission
{
    public int SubmissionId { get; set; }

    public int StdId { get; set; }

    public int CompetId { get; set; }

    public string ImageFilePath { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Status { get; set; } = null!;

    public string Remarks { get; set; } = null!;

    public DateTime SubmissionDate { get; set; }

    public virtual Competition Compet { get; set; } = null!;

    public virtual Student Std { get; set; } = null!;
}
