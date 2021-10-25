using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Travel.Models
{
  public class Review
  {

    public int ReviewId {get;set;}
    [Required]
    public string Rating {get;set;}
    [Required]
    public string Comment {get;set;}
    [Required]
    public virtual Location location {get;set;}

  }
}