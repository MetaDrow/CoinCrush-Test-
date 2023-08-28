using Photon.Pun;
using UnityEngine;

public class Bullet : MonoBehaviourPunCallbacks
{
    private Vector2 _bulletVelocity;
    [SerializeField] internal float _directionX;
    [SerializeField] internal float _directionY;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] PhotonView _view;
    [SerializeField] CharacterController _bulletController;
    [SerializeField] Rigidbody _bulletRigidbody;

    [SerializeField] int _currentDamageValue;
    private void Start()
    {
        //_bulletController = GetComponent<CharacterController>();
        //_bulletRigidbody = GetComponent<Rigidbody>();
        // _view = GetComponent<PhotonView>();
    }
    void FixedUpdate()
    {
        if (!_view.IsMine)
        {
            return;

        }
        else
        {
            photonView.RPC("Move", RpcTarget.All);
        }

    }

    [PunRPC]
    public void Move()
    {
        _bulletVelocity = new Vector3(_directionX, _directionY, 0);
        // transform.position += (Vector3)_bulletVelocity * _bulletSpeed * Time.fixedDeltaTime;

        //_bulletController.Move(_bulletVelocity * _bulletSpeed * Time.fixedDeltaTime);
        // _bulletRigidbody.velocity = _bulletVelocity * _bulletSpeed * Time.fixedDeltaTime;
        _bulletRigidbody.AddForce(_bulletVelocity * _bulletSpeed * Time.fixedDeltaTime, ForceMode.Impulse);
    }


    private void OnTriggerEnter(Collider other)
    {
        HealthController health = other.gameObject.GetComponent<HealthController>();
        health?.TakeDamage(_currentDamageValue);
    }
}
