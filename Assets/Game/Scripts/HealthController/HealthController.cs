using UnityEngine;
using Photon.Pun;

public abstract class HealthController : MonoBehaviourPunCallbacks
{
    private int _startingHealth = 100;
    private int _maxHealth = 100;
    [SerializeField] private int _currentHealth;

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
