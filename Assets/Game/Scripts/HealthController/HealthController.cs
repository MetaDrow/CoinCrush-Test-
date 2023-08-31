using UnityEngine;
using Photon.Pun;

public abstract class HealthController : MonoBehaviourPunCallbacks
{
    [SerializeField] internal int _startingHealth = 100;
    [SerializeField] internal int _maxHealth = 100;
    [SerializeField] internal int _currentHealth;

    public int StartingHealth
    {
        get => _startingHealth;
    }
    public int MaxHealth
    {
        get => _maxHealth;
    }
    public int CurrentHealth
    {
        get => _currentHealth;
        set
        {
            if (value > MaxHealth)
            {
                value = MaxHealth;
            }
            if (value < 0)
            {
                value = 0;
            }
            _currentHealth = value;
        }
    }
}
