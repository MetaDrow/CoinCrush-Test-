using UnityEngine;
using Photon.Pun;

public class Player : MonoBehaviour
{
    [SerializeField] PhotonView _view;
    [SerializeField] CharacterController _controller;

    [Header("Movement Parameters")]
    protected internal Vector2 _input;
    private Vector3 _velocity;
    [SerializeField, Range(0, 50)] float _maxSpeed;

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
    }
}
