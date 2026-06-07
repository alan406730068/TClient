using UnityEngine;
using UnityEngine.UI;

public class UILogin : MonoBehaviour
{
    [SerializeField] Button BtnConnect;
    [SerializeField] Button BtnLogin;
    void Start()
    {
        BtnConnect.onClick.AddListener(OnBtnConnect_Click);
        BtnLogin.onClick.AddListener(OnBtnLogin_Click);
    }

    private void OnBtnConnect_Click() 
    {
        NetworkClient.Instance.Connect();
    }
    private void OnBtnLogin_Click()
    {
        NetworkClient.Instance.SendData("Hello");
    }
}
