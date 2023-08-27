using Photon.Pun;
using TMPro;
using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine;

public class RoomListMenu : MonoBehaviourPunCallbacks
{
    [SerializeField] private Transform _content;
    [SerializeField] private RoomList _roomList;

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (RoomInfo roomInfo in roomList)
        {
            RoomList list = Instantiate(_roomList,_content);
            if(list != null)
            {
                list.SetRoomInfo(roomInfo);
            }
        }
    }
}
