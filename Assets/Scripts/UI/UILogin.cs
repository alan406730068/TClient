using UnityEngine;
using UnityEngine.UI;

public class UILogin : MonoBehaviour
{
    [SerializeField] Button BtnLogin;
    [SerializeField] Button BtnQuit;
    void Start()
    {
        BtnLogin.onClick.AddListener(OnBtnLogin_Click);
        BtnQuit.onClick.AddListener(OnBtnQuit_Click);
    }

    private void OnBtnLogin_Click()
    {
        NetworkClient.Instance.SendData("Hello");
    }
    private void OnBtnQuit_Click()
    {
    }
}
