using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector2 _bulletVelocity;
    [SerializeField] internal float _directionX;
    [SerializeField] internal float _directionY;
    [SerializeField] private float _bulletSpeed;

    void Update()
    {
        Move();
    }

    private void Move()
    {
        _bulletVelocity = new Vector3(_directionX, _directionY, 0);
        transform.position += (Vector3)_bulletVelocity * _bulletSpeed * Time.fixedDeltaTime;
    }
}
