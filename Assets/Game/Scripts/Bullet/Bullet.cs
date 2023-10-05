using Photon.Pun;
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

    private void FixedUpdate()
    {
        if (_view.IsMine)
        {
            Move(_directionX, _directionY);
        }
    }

    private void Move(float directionX, float directionY)
    {
        _bulletVelocity = new Vector3(directionX, directionY, 0);
        _bulletRigidbody.AddForce(_bulletVelocity * _bulletSpeed * Time.fixedDeltaTime, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth health = other?.GetComponent<PlayerHealth>();

        if (_view.IsMine && health != null)
        {
            Logging.instance.Log("Bullt Hit UserID " + health.uiID);
            health?.TakeDamage(_currentDamageValue, health.uiID);


            PhotonNetwork.Destroy(_view);
        }
        else if (other.CompareTag("Wall"))
        {
            PhotonNetwork.Destroy(_view);
        }
        else
        {
            Logging.instance.Log("Bullet no hit");
            return;
        }
    }
}
