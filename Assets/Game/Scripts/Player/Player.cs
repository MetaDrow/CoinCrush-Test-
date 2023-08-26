using UnityEngine;
using Photon.Pun;
using UnityEngine.TextCore.Text;

public class Player : MonoBehaviour // использую 3d капсулу
{
    [SerializeField] PhotonView _view;
    [SerializeField] internal CharacterController _controller;
    [SerializeField] private Bullet _bullet;
    [Header("Movement Parameters")]
    [SerializeField] protected internal Vector2 _input;
    protected internal Vector3 _velocity;
    [SerializeField, Range(0, 50)] private float _maxSpeed;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _view = GetComponent<PhotonView>();
    }

    void FixedUpdate()
    {
        if (_view.IsMine)
        {
            Move(_input);
        }
    }

    void Move(Vector2 input)
    {
        _velocity = input * _maxSpeed;
        _controller.Move(_velocity * Time.fixedDeltaTime);
        _bullet._directionX = input.x;
        _bullet._directionY = input.y;
        _controller.transform.rotation = Quaternion.LookRotation(_velocity);

    }
}
