using GConge.Models.DTOs.Auth;
using GConge.Models.Models;
using GConge.Web.Client.Services.Contracts;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;

namespace GConge.Web.Client.Pages;

public class LoginBase : ComponentBase
{
  protected readonly UserLoginRequestDto UserInputs = new();
  protected string? ErrorFromServer;
  protected bool IsLoading;

  [Inject]
  public IOpenGraphImageService Og { get; set; }

  public string OgImage { get; set; }

  [Inject]
  protected NavigationManager Router { get; set; } = default!;

  [Inject]
  protected IAuthService AuthService { get; set; } = default!;

  [Inject]
  protected IUserLocalStorageService UserLocalStorageService { get; set; } = default!;

  protected string? Redirect { get; set; }

  protected async override Task OnInitializedAsync()
  {
    Dictionary<string, StringValues> queryDict = ParseQueryString();
    // check there is a connected user
    var user = await UserLocalStorageService.GetUserFromLocalStorage();
    ReadRedirectQuery(queryDict);

    if (user != null)
    {
      Router.NavigateTo(uri: Redirect ?? "/manage-leaves", true);
      return;
    }

    OgImage = Og.GetOpenGraphLink(new OpenGraph
      {
        Description = "Connectez-vous à votre compte GCongé pour gérer vos congés et absences.",
        TemplateTitle = "GCongé - Connexion",
        SiteName = "GCongé",
        Theme = "dark",
        Logo = "https://raw.githubusercontent.com/faouziMohamed/social-share/main/public/sc-icons/logo/sc-light.png"

      }
    );

    ReadEmailQuery(queryDict);
  }
  private void ReadEmailQuery(IReadOnlyDictionary<string, StringValues> queryDict)
  {
    var email = "";
    if (queryDict.ContainsKey("email")) email = queryDict["email"];
    UserInputs.Email = email;
  }
  private void ReadRedirectQuery(IReadOnlyDictionary<string, StringValues> queryDict)
  {
    if (queryDict.ContainsKey("redirectto")) Redirect = queryDict["redirectto"];
  }
  private Dictionary<string, StringValues> ParseQueryString()
  {
    var uri = Router!.ToAbsoluteUri(Router!.Uri);
    string queryString = uri.Query.ToLower();
    Dictionary<string, StringValues> queryDict = QueryHelpers.ParseQuery(queryString);
    return queryDict;
  }
  protected async Task OnSubmit(EditContext editContext)
  {
    IsLoading = true;
    ErrorFromServer = null;

    try
    {
      var user = await AuthService.Login(UserInputs);

      if (user == null)
      {
        ErrorFromServer = "Une erreur est survenue lors de l'authentification";
        return;
      }

      // save the user in local storage
      await UserLocalStorageService.SaveUser(user);

      if (string.IsNullOrEmpty(Redirect))
      {
        Redirect = user.Role == UserRole.Admin ? "/manage-leaves" : "/Leave-requests";
      }

      Router!.NavigateTo(Redirect, true);
    }
    catch (Exception e)
    {
      ErrorFromServer = e.Message;
    }
    finally
    {
      IsLoading = false;
    }
  }
}
