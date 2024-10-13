using System;
using System.Collections.Generic;

namespace Institute_of_Fine_Arts.Models;

public partial class Staff
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;
}
