using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Travel.Models;
using System.ComponentModel.DataAnnotations;

namespace Travel.Controllers
{
  [Route("api/Main")]
  [ApiController]
  public class MainController : Controller
  {
    private readonly TravelContext _context;

    public MainController(TravelContext context)
      {
          _context = context;
      }
    [HttpGet("gettoken")]
      public Object GetToken()
      {
          string key = "TornadoOfZombieWerewolves"; //Secret key which will be used later during validation
          var issuer = "https://mysite.com";  //normally this will be your site URL

          var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
          var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

          //Create a List of Claims, Keep claims name short
          var permClaims = new List<Claim>();
          permClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
          permClaims.Add(new Claim("valid", "1"));
          permClaims.Add(new Claim("userid", "1"));
          permClaims.Add(new Claim("name", "bilal"));

          //Create Security Token object by giving required parameters
          var token = new JwtSecurityToken(issuer, //Issure
                          issuer,  //Audience
                          permClaims,
                          expires: DateTime.Now.AddDays(1),
                          signingCredentials: credentials);
          var jwt_token = new JwtSecurityTokenHandler().WriteToken(token);
          return new { data = jwt_token };
      }

    [HttpPost("getname1")]
      public String GetName1() {
      if (User.Identity.IsAuthenticated) {
        var identity = User.Identity as ClaimsIdentity;
        if (identity != null) {
        IEnumerable < Claim > claims = identity.Claims;
        }
        return "Valid";
      } else {
        return "Invalid";
      }
      }

      [Authorize]
      [HttpPost("getname2")]
      public Object GetName2() {
      var identity = User.Identity as ClaimsIdentity;
      if (identity != null) {
        IEnumerable < Claim > claims = identity.Claims;
        var name = claims.Where(p => p.Type == "name").FirstOrDefault() ? .Value;
        return new {
        data = name
        };

      }
      return null;
      }
  }
}

// eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJqdGkiOiJlZTA5Y2QzMS02YzE4LTRkM2UtOTE1Zi02OWQwYjA1MDZhYTAiLCJ2YWxpZCI6IjEiLCJ1c2VyaWQiOiIxIiwibmFtZSI6ImJpbGFsIiwiZXhwIjoxNjM1MzcwMDcyLCJpc3MiOiJodHRwczovL215c2l0ZS5jb20iLCJhdWQiOiJodHRwczovL215c2l0ZS5jb20ifQ.eP276W9XKV497ijbSzGOpUPE0EIiHUQ47eQqJvN_8cs
// {
//   "jti": "a15fc80b-95c7-4e3e-8e1f-9a838ff1d139",
//   "valid": "1",
//   "userid": "1",
//   "name": "bilal",
//   "exp": 1635370100,
//   "iss": "https://mysite.com",
//   "aud": "https://mysite.com"
// }

  // {
  //   "jti": "ee09cd31-6c18-4d3e-915f-69d0b0506aa0",
  //   "valid": "1",
  //   "userid": "1",
  //   "name": "bilal",
  //   "exp": 1635370072,
  //   "iss": "https://mysite.com",
  //   "aud": "https://mysite.com"
  // }
