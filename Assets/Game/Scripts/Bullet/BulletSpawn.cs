using Photon.Pun;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviourPunCallbacks
{
    [SerializeField] private InputReaderSO _playerInputReader;
    [SerializeField] internal GameObject _bullet;
    [SerializeField] private PlayerSpawn _playerSpawn;
    [SerializeField] internal List<GameObject> _spawnList;
    public void OnEnable()
    {
        _playerInputReader.ShootEvent += Spawn;
    }

    private void Spawn()
    {
        for (int i = 0; i < _playerSpawn._spawnList.Count; i++)
        {
            if (_playerSpawn._spawnList[i] != null)
            {
                GameObject bullet = PhotonNetwork.Instantiate("Bullet", _playerSpawn._spawnList[i].transform.position, Quaternion.identity);
                _spawnList.Add(bullet);
            }
        }
    }
}
