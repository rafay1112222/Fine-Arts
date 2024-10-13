using System;
using System.Collections.Generic;

namespace Institute_of_Fine_Arts.Models;

public partial class PaintEx
{
    public int PaintingExhibitionId { get; set; }

    public int PaintingId { get; set; }

    public int ExhibitionId { get; set; }

    public decimal Price { get; set; }

    public string Status { get; set; } = null!;

    public decimal? SoldPrice { get; set; }

    public string? CustomerDetails { get; set; }

    public string PaymentStatus { get; set; } = null!;

    public virtual Exhibition Exhibition { get; set; } = null!;
}
