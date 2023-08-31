using Photon.Pun;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private InputReaderSO _playerInputReader;
    [SerializeField] internal GameObject _bullet;
    [SerializeField] private PhotonView _view;
    private Player _player;

    private void Start()
    {
        if (_player == null)
        {
            _player = GetComponent<Player>();
        }
    }
    public void OnEnable()
    {
        _playerInputReader.ShootEvent += Spawn;
    }

    public void OnDisable()
    {
        _playerInputReader.ShootEvent -= Spawn;
    }
    private void Spawn()
    {
        var pos = _player._input * 2f;
        if (_view.IsMine)
        {
            GameObject bullet = PhotonNetwork.Instantiate("Bullet", _player.transform.position + (Vector3)pos, Quaternion.identity);
        }
    }
}
