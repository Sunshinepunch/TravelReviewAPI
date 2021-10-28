using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Travel.Models
{
  public class Review
  {

    public int ReviewId {get;set;}
    [Required]
    public int Rating {get;set;}
    [Required]
    public string Comment {get;set;}
    public int DestinationId {get;set;}
    public virtual Destination destination {get;set;}


  }
}