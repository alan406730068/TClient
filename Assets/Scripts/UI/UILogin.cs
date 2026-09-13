using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text.RegularExpressions;

public class UILogin : MonoBehaviour
{
    [SerializeField] Button BtnLogin;
    [SerializeField] Button BtnQuit;
    [SerializeField] TMP_InputField InputUserName;
    [SerializeField] TMP_InputField InputPassword;
    [SerializeField] TMP_Text TxtError;

    private string userName;
    private string password;
    private const string errorMessage = "Invalid username or password.";
    void Start()
    {
        BtnLogin.onClick.AddListener(OnBtnLogin_Click);
        BtnQuit.onClick.AddListener(OnBtnQuit_Click);
        InputUserName.onValueChanged.AddListener(OnInputUserName_Changed);
        InputPassword.onValueChanged.AddListener(OnInputPassword_Changed);
    }

    private void OnBtnLogin_Click()
    {
        if (false)
        {
            TxtError.text = errorMessage;
        }
        TxtError.text = string.Empty;
        NetworkClient.Instance.SendData("Hello");
    }
    private void OnBtnQuit_Click()
    {
    }
    private void OnInputUserName_Changed(string value)
    {
        userName = value;
        validateUI();
    }
    private void OnInputPassword_Changed(string value)
    {
        password = value;
        validateUI();
    }
    private void validateUI() 
    {
        var userRegex = Regex.Match(userName,"^[a-zA-Z0-9]+$");

        var isValid = userRegex.Success &&
        !string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password);

        BtnLogin.interactable = isValid;
    }
}
