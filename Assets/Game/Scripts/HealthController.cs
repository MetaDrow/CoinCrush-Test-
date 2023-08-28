using UnityEngine;
using System;
using System.Collections;

public abstract class HealthController : MonoBehaviour
{
    public event Action<int> Damaged;
    public event Action<int> Healed;
    public event Action Killed;

    [SerializeField] internal int _startingHealth = 100;
    [SerializeField] internal int _maxHealth = 100;
    [SerializeField] internal int _currentHealth;

    private int _healthStep = 100;

    public int CurrentHealth
    {
        get => _currentHealth;
        set
        {
            if (value > _maxHealth)
            {
                value = _maxHealth;
            }
            if (value < 0)
            {
                value = 0;
            }
            _currentHealth = value;
        }
    }

    public virtual void TakeHeal(int amount)
    {
        CurrentHealth += amount;
        Healed?.Invoke(amount);
    }

    public virtual void TakeDamage(int amount)
    {
        /*
        if (CurrentHealth != CurrentHealth - amount)
        {
            CurrentHealth--;
            //StartCoroutine(Damage());
        }

        //CurrentHealth -= amount;
        //StartCoroutine(Damage());


        if (_healthStep != _healthStep - 25)
        {
            //StartCoroutine(Damage());
            _currentHealth--;
            Damaged?.Invoke(amount);
        }
                for (_healthStep = 25; _healthStep != 0; _healthStep--)
        {
            StartCoroutine(Damage(amount));


        }
        */
        CurrentHealth -= amount;

        if (_healthStep > _currentHealth)
        {
            _healthStep--;
            StartCoroutine(Damage(amount));
            Damaged?.Invoke(amount);

        }
        // CurrentHealth -= amount;



        if (_currentHealth <= 0)
        {
            Death();
        }
    }


    IEnumerator Damage(int amount)
    {
        yield return new WaitForSeconds(2.5f);


        /*
        if(_currentHealth > _currentHealth - 25)
        {
            yield return new WaitForSeconds(.1f);
            CurrentHealth--;
            //StartCoroutine(Damage());
        }
        // 
        */
    }
    public void Death()
    {
        Killed?.Invoke();
    }

}
