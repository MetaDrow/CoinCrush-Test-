using Photon.Pun;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] internal GameObject _player;
    [SerializeField] private float _minX, _minY, _maxX, _maxY;
    [SerializeField] internal List<GameObject> _spawnList;
    void Start()
    {
        Spawn();
    }

    private GameObject Spawn()
    {
        Vector2 spawnPosition = new Vector2(Random.Range(_minX, _minY), Random.Range(_maxX, _maxY));
        GameObject player = PhotonNetwork.Instantiate("Player", spawnPosition, Quaternion.identity);
        _spawnList.Add(player);
        return _player;
    }
}
