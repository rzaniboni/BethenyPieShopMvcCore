using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;

namespace BethanyPieShop.Filters {
  public class OutgageAuthorizationFilter : Attribute, IAuthorizationFilter {
    private readonly IConfiguration _config;

    public OutgageAuthorizationFilter (IConfiguration configuration) {
      this._config = configuration;
    }

    public void OnAuthorization (AuthorizationFilterContext context) {
      var applicationSwitch = _config.GetSection ("FeatureSwitches")
        .GetChildren ().FirstOrDefault (x => x.Key == "Outage");

      if (!bool.Parse (applicationSwitch.Value)) {
        context.Result = new ViewResult () { ViewName = "Outage" };
      }
    }
  }
}