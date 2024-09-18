using System;
using VCQRU.Models;

public class UniqueCode
{
    public int SeriesNumber { get; set; }
    public string Code1 { get; set; }
    public string Code2 { get; set; }
    public DateTime GeneratedDate { get; set; }
    public int BatchNumber { get; set; }

    // New property for CompanyId
    public int CompanyId { get; set; }

    // Navigation property to Company
    public Company Company { get; set; }
}
