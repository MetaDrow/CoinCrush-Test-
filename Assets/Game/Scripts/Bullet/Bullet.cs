using Photon.Pun;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector2 _bulletVelocity;
    [SerializeField] internal float _directionX;
    [SerializeField] internal float _directionY;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] PhotonView _view;
    void FixedUpdate()
    {
        if(_view.IsMine)
        {
            Move();

        }

    }

    private void Move()
    {
        _bulletVelocity = new Vector3(_directionX, _directionY, 0);
        transform.position += (Vector3)_bulletVelocity * _bulletSpeed * Time.fixedDeltaTime;
    }
}
