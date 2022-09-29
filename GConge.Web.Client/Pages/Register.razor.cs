using Blazored.LocalStorage;
using GConge.Models.Forms;
using GConge.Models.Models;
using GConge.Web.Client.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace GConge.Web.Client.Pages;

public class RegisterBase : ComponentBase
{
  protected bool IsLoading;
  protected UserRegisterForm UserRegister = new();

  [Inject]
  public IOpenGraphImageService Og { get; set; }

  [Inject]
  protected NavigationManager Router { get; set; }

  [Inject]
  protected IAuthService AuthService { get; set; } = default!;

  [Inject]
  private IUserLocalStorageService UserLocalStorage { get; set; } = default!;

  [Inject]
  private ILocalStorageService LocalStorage { get; set; } = default!;

  protected string OgImage { get; set; }

  protected async override Task OnInitializedAsync()
  {
    IsLoading = true;
    bool isConnected = await UserLocalStorage.CheckIfUserIsLoggedIn();

    if (isConnected)
    {
      Router.NavigateTo("/LeaveRequests", true);
      return;
    }

    await LocalStorage.ClearAsync();
    IsLoading = false;
    OgImage = Og.GetOpenGraphLink(new OpenGraph
      {
        Description = "Inscrivez-vous sur GCongé pour gérer vos congés en toute simplicité.",
        TemplateTitle = "Inscription | GCongé",
        Theme = "light",
        SiteName = "GCongé",
        Logo = "https://raw.githubusercontent.com/faouziMohamed/social-share/main/public/sc-icons/logo/sc-light.png"
      }
    );
  }
}
