using System;
using System.Collections.Generic;

namespace Institute_of_Fine_Arts.Models;

public partial class Student
{
    public int StdId { get; set; }

    public string StdName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Award> Awards { get; set; } = new List<Award>();

    public virtual ICollection<Competition> Competitions { get; set; } = new List<Competition>();

    public virtual ICollection<Submission> Submissions { get; set; } = new List<Submission>();
}
