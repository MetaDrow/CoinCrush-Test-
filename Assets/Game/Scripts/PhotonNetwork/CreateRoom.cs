using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

public class CreateRoom : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_InputField _createInput;
    public void OnClickCreateRoom()
    {
        if (!PhotonNetwork.IsConnected || PhotonNetwork.InRoom)
        {
            return;
        }

        RoomOptions roomOptions = new RoomOptions
        {
            MaxPlayers = 2,
            IsVisible = true,
            IsOpen = true,
        };
        PhotonNetwork.CreateRoom(_createInput.text, roomOptions);
    }
    public override void OnCreatedRoom()
    {
        Debug.Log("Player " + PhotonNetwork.NickName + " create room. Room Name  " + PhotonNetwork.CurrentRoom.Name);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Room created is failed: ", this);

    }
    public override void OnJoinedRoom()
    {
        Debug.Log("Player " + PhotonNetwork.NickName + " in room " + PhotonNetwork.CurrentRoom.Name);
    }
}
