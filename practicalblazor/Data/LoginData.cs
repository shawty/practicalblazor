using System.ComponentModel.DataAnnotations;

namespace dsnetops.Datamodels
{
  public class LoginData
  {
    [Required]
    [Display(Name = "Users Login Name")]
    public string UserName { get; set; }

    [Required]
    [Display(Name = "Users password")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

  }
}
