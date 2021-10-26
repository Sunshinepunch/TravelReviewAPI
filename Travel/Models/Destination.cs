using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Travel.Models
{
  public class Destination
  {

    public int DestinationId {get;set;}
    
    [Required]
    public string Name {get;set;}


    public virtual ICollection<Review> Reviews { get; set; }

  }
}