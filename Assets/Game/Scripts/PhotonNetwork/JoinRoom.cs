using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JoinRoom : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_InputField _joinInput;
    public void OnClickJoinRoom()
    {
        if (PhotonNetwork.IsMasterClient == true)
        {
            SceneManager.LoadScene("Game");
        }
        else
        {
            PhotonNetwork.JoinRoom(_joinInput.text);
        }
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
    }

    public void ChangeScene(string sceneName)
    {
        PhotonNetwork.LoadLevel(sceneName);
    }
}
