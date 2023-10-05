using Photon.Pun;
using TMPro;
using UnityEngine;

public class Logging : MonoBehaviourPunCallbacks
{
    [SerializeField] private TextMeshProUGUI _text;

    public static Logging instance;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        Log("My name is : " + PhotonNetwork.NickName);
    }

    public void Log(string message)
    {
        Debug.Log(message);
        _text.text += "\n";
        _text.text += message;
    }
}
