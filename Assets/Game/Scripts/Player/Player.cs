using UnityEngine;
using Photon.Pun;
using UnityEngine.TextCore.Text;

public class Player : MonoBehaviourPunCallbacks
{
    [SerializeField] private InputReaderSO _playerInputReader;
    [SerializeField] PhotonView _view;
    [SerializeField] internal CharacterController _controller;
    [SerializeField] private Bullet _bullet;
    [Header("Movement Parameters")]
    [SerializeField] protected internal Vector2 _input;
    protected internal Vector2 _velocity;
    [SerializeField, Range(0, 50)] private float _maxSpeed;

    private Vector3 _direction;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _view = GetComponent<PhotonView>();
    }

    void FixedUpdate()
    {
        if (!_view.IsMine)
        {
            return;

        }
        else
        {
            photonView.RPC("Movement", RpcTarget.All, _input);
        }
    }

    [PunRPC]
    void Movement(Vector2 input)
    {


        _direction = new Vector3(input.x, 0, input.y);






        // var targetAngle = Mathf.Atan2(input.x * -1, input.y) * Mathf.Rad2Deg;
        var targetAngle = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg;
        _controller.transform.rotation = Quaternion.Euler(0, 0, targetAngle);
        _velocity = input * _maxSpeed;
        _controller.Move(_velocity * Time.fixedDeltaTime);

        _bullet._directionX = input.x;
        _bullet._directionY = input.y;
        /*
        /////////////////////////////////////////////// work, dont touch 
        _velocity = input * _maxSpeed;
        _controller.Move(_velocity * Time.fixedDeltaTime);
                _bullet._directionX = input.x;
        _bullet._directionY = input.y;
        //_controller.transform.rotation = Quaternion.LookRotation(_direction); // 
        */
    }

}
