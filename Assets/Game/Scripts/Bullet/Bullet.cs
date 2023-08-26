using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector2 _bulletVelocity;
    [SerializeField] internal float _direction;
    [SerializeField] private float _bulletSpeed;

    void Update()
    {
        Move();
    }

    private void Move()
    {
        _bulletVelocity = new Vector3(_direction, 0, 0);
        transform.position += (Vector3)_bulletVelocity * _bulletSpeed * Time.fixedDeltaTime;
    }
}
