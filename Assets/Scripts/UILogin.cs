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
        Debug.Log("connect!");
    }
    private void OnBtnLogin_Click()
    {
        Debug.Log("login!");
    }
}
