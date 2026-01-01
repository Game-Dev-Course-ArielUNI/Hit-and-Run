using System.Threading.Tasks;
using Unity.Services.Authentication;
using Unity.Services.Core;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class AuthenticationManagerWithPassword : MonoBehaviour
{
    [Header("UI")]
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;
    public TMP_Text statusText;

    [Header("Scene")]
    public string menuSceneName = "Menu";

    private Task _initTask;

    void Awake()
    {
        _initTask = InitAsync();
    }

    private async Task InitAsync()
    {
        await UnityServices.InitializeAsync();
        Debug.Log("UGS Initialized");
    }

    public async void OnLoginClicked()
    {
        await _initTask;

        string u = usernameInput.text.Trim();
        string p = passwordInput.text;

        string msg = await LoginWithUsernameAndPassword(u, p);
        Show(msg);

        if (IsSuccess(msg))
            SceneManager.LoadScene(menuSceneName);
    }

    public async void OnRegisterClicked()
    {
        await _initTask;

        string u = usernameInput.text.Trim();
        string p = passwordInput.text;

        string msg = await RegisterWithUsernameAndPassword(u, p);
        Show(msg);

        if (IsSuccess(msg))
            SceneManager.LoadScene(menuSceneName);
    }

    private void Show(string msg)
    {
        Debug.Log(msg);
        if (statusText) statusText.text = msg;
    }

    private bool IsSuccess(string msg)
    {
        return msg.StartsWith("Login successful") || msg.StartsWith("Register successful");
    }

    public async Task<string> RegisterWithUsernameAndPassword(string username, string password)
    {
        try
        {
            await AuthenticationService.Instance.SignUpWithUsernamePasswordAsync(username, password);
            return $"Register successful! Player ID: {AuthenticationService.Instance.PlayerId}";
        }
        catch (AuthenticationException ex) { return $"Register failed: {ex.Message}"; }
        catch (RequestFailedException ex) { return $"Register request failed: {ex.Message}"; }
    }

    public async Task<string> LoginWithUsernameAndPassword(string username, string password)
    {
        try
        {
            await AuthenticationService.Instance.SignInWithUsernamePasswordAsync(username, password);
            return $"Login successful! Player ID: {AuthenticationService.Instance.PlayerId}";
        }
        catch (AuthenticationException ex) { return $"Login failed: {ex.Message}"; }
        catch (RequestFailedException ex) { return $"Login request failed: {ex.Message}"; }
    }
}
