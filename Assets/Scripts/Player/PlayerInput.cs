using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private InputReaderSO _playerInputReader;
    private Player _player;

    void Start()
    {
        if (_player == null)
        {
            _player = GetComponent<Player>();
        }
    }

    public void OnEnable()
    {
        _playerInputReader.MovementEvent += HandleMove;
    }

    private void HandleMove(Vector2 input)
    {
        _player._input = input;
    }
}
