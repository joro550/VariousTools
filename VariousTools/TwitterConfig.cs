using System.ComponentModel.DataAnnotations;

namespace VariousTools;

public class TwitterConfig
{
    [Required]
    public string BearerToken { get; set; }
}