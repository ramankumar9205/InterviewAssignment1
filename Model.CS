public class ApplicationUser : IdentityUser { }

public class Document
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Content { get; set; }
    public string UploadedBy { get; set; }
    public DateTime UploadedAt { get; set; }
}

public class IngestionStatus
{
    public int Id { get; set; }
    public string DocumentId { get; set; }
    public string Status { get; set; }
    public DateTime UpdatedAt { get; set; }
}
