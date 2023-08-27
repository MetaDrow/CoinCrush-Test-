using Photon.Pun;
using UnityEngine;
using TMPro;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private TextMeshProUGUI _logText;
    void Start()
    {
        PhotonNetwork.JoinLobby();
        Log("You name is : " + PhotonNetwork.NickName);
        Log("AutomaticallySyncScenes : " + PhotonNetwork.AutomaticallySyncScene);
        Log("PhotonNetwork.GameVersion : " + PhotonNetwork.GameVersion.ToString());
    }

    private void Log(string message)
    {
        Debug.Log(message);
        _logText.text += "\n";
        _logText.text += message;
    }
}
