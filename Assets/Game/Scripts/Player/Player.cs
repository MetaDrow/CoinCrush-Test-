using UnityEngine;
using Photon.Pun;
using System;

public class Player : MonoBehaviour
{
    [SerializeField] private InputReaderSO _playerInputReader;
    [SerializeField] internal PhotonView _view;
    [SerializeField] internal CharacterController _controller;
    [SerializeField] private Bullet _bullet;
    [Header("Movement Parameters")]
    [SerializeField, Range(0, 50)] private float _maxSpeed;
    [SerializeField] protected internal Vector2 _input;
    [SerializeField] GameObject _playerHealthBar;
    protected internal Vector2 _velocity;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        _view = GetComponent<PhotonView>();
    }

    private void FixedUpdate()
    {
        if (_view.IsMine)
        {
            Movement(_input);
        }
    }


    private void Movement(Vector2 input)
    {
        var targetAngle = Mathf.Atan2(input.x * -1, input.y) * Mathf.Rad2Deg;
        _controller.transform.rotation = Quaternion.Euler(0, 0, targetAngle);

        _velocity = input * _maxSpeed;
        _controller.Move(_velocity * Time.fixedDeltaTime);

        _bullet._directionX = input.x;
        _bullet._directionY = input.y;
    }
}
