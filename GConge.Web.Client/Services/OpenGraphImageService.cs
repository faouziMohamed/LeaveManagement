using System.Net;
using GConge.Models.Models;
using GConge.Web.Client.Services.Contracts;

namespace GConge.Web.Client.Services;

public sealed class OpenGraphImageService : IOpenGraphImageService
{
  private const string OgUrl = "https://fz-og.vercel.app/api/general";
  public string GetOpenGraphLink(OpenGraph args)
  {
    string? ogLogo = WebUtility.UrlEncode(args.Logo);
    string? ogSiteName = WebUtility.UrlEncode(args.SiteName);
    string? ogTemplateTitle = WebUtility.UrlEncode(args.TemplateTitle.Trim());
    string ogDesc = WebUtility.UrlEncode(args.Description.Trim());
    string queries = $"siteName={ogSiteName}&logo={ogLogo}&title={ogTemplateTitle}&description={ogDesc}&theme={args.Theme}";

    return $"{OgUrl}?{queries}";

  }
}
