// ReSharper disable UnusedMember.Global

namespace GConge.web.api.Models.Configs;

public class ServerSettings
{
  public string[] AllowedOrigins { get; set; } = Array.Empty<string>();
  public string CorsPolicyName { get; set; } = "AllowFrontEnd";
}
