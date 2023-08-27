using UnityEngine;
using TMPro;
using Photon.Realtime;
using System.Collections.Generic;
using Photon.Pun;

public class RoomList : MonoBehaviourPunCallbacks
{
    [SerializeField] private TextMeshProUGUI _text;

    public void SetRoomInfo(RoomInfo info)
    {
        _text.text = info.Name;
    }
}
