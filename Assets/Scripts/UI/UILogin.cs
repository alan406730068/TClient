using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text.RegularExpressions;
using System.Collections;

public class UILogin : MonoBehaviour
{
    [SerializeField] Button BtnLogin;
    [SerializeField] Button BtnQuit;
    [SerializeField] TMP_InputField InputUserName;
    [SerializeField] TMP_InputField InputPassword;
    [SerializeField] TMP_Text TxtError;
    [SerializeField] GameObject Go_loadingBar;

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

    #region Button Event    
    private void OnBtnLogin_Click()
    {
        StopCoroutine(loginProcess());
        StartCoroutine(loginProcess());
    }
    private IEnumerator loginProcess()
    {
        showLoginUI(true);

        NetworkClient.Instance.Connect();
        while (!NetworkClient.Instance.IsConnected)
        {
            Debug.Log("Waiting for connection...");
            yield return null;
        }
        Debug.Log("Connect Success");
        showLoginUI(false);
    }

    private void showLoginUI(bool islogining, string errorText = "")
    {
        BtnLogin.interactable = !islogining;
        Go_loadingBar.SetActive(islogining);
        TxtError.text = errorText;
    }
    private void OnBtnQuit_Click()
    {
    }

    #endregion

    #region InputField Event
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
    #endregion

}
