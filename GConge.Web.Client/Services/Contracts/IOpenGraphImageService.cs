using GConge.Models.Models;

namespace GConge.Web.Client.Services.Contracts;

public interface IOpenGraphImageService
{
  string GetOpenGraphLink(OpenGraph args);
}
