using Photon.Pun;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class BulletSpawn : MonoBehaviour
{
    [SerializeField] private InputReaderSO _playerInputReader;
    [SerializeField] internal GameObject _bullet;
    [SerializeField] private PlayerSpawn _playerSpawn;
    [SerializeField] internal List<GameObject> _spawnList;
    [SerializeField] internal Bullet _bulletPrefab;

    //[SerializeField] private Player _player;

    private void Start()
    {

    }
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
