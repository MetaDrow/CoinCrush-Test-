using Photon.Pun;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private TextMeshProUGUI _text;


    void Start()
    {
        Log("My name is : " + PhotonNetwork.NickName);
    }


    void Update()
    {
    }


    public override void OnLeftRoom()
    {

    }

    private void Log(string message)
    {
        Debug.Log(message);
        _text.text += "\n";
        _text.text += message;
    }
}
