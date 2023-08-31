using Photon.Pun;
using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] internal float _directionX;
    [SerializeField] internal float _directionY;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private PhotonView _view;
    [SerializeField] private Rigidbody _bulletRigidbody;
    [SerializeField] private int _currentDamageValue;
    private Vector2 _bulletVelocity;
    public static event Action Damage;
    void FixedUpdate()
    {
        if (_view.IsMine)
        {
            Move();

        }
    }
    public void Move()
    {
        _bulletVelocity = new Vector3(_directionX, _directionY, 0);
        _bulletRigidbody.AddForce(_bulletVelocity * _bulletSpeed * Time.fixedDeltaTime, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth health = other.GetComponent<PlayerHealth>();

        if (other.CompareTag("Player") && _view.IsMine)
        {
            health?.TakeDamage(_currentDamageValue);
            Damage?.Invoke();
            PhotonNetwork.Destroy(this._view);
        }
    }
}
