using System.ComponentModel.DataAnnotations;

namespace Codebridge.BLL.Entities;

public abstract record Entity
{
    [Required]
    [Range(1, int.MaxValue)]
    public int Id { get; set; }
}