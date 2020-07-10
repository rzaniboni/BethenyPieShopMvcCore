using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BethanyPieShop.TagHelpers {

  [HtmlTargetElement ("banner")]
  public class BannerTagHelper : TagHelper {

    public string Title { get; set; }
    public string SubTitle { get; set; }

    public override void Process (TagHelperContext context, TagHelperOutput output) {
      output.Content.SetHtmlContent (
        $@"<h1>{ Title }</h1><h3> { SubTitle }</h3>"
      );
    }

  }
}