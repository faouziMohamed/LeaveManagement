namespace GConge.Models.Models;

public sealed record OpenGraph
{
  public string? SiteName { get; init; }
  public string? TemplateTitle { get; init; }
  public string? Description { get; init; }
  public string? Theme { get; init; } = "light";
  public string? Logo { get; init; }
}
