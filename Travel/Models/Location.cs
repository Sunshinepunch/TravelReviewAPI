using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Travel.Models
{
  public class Location
  {
    public int LocationId {get;set;}
    [Required]
    public string Name {get;set;}
    [Required]
    public string Country {get;set;}
    [Required]
    public string City {get;set;}

    public virtual ICollection<Review> Reviews {get;set;}
  }
}