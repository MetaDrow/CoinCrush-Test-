using Photon.Pun;
using System;
using UnityEngine;

public class PlayerHealth : HealthController
{
    [SerializeField] public int _characterHealth = 100;
    [SerializeField] private PhotonView _view;
    public static event Action Damaged;

    private void Start()
    {
        CurrentHealth = _startingHealth;
        _characterHealth = CurrentHealth;
    }

    public void TakeDamage(int amount)
    {
        CurrentHealth -= amount;
        _characterHealth = CurrentHealth;

        if (!PhotonNetwork.IsMasterClient)
        {
            photonView.RPC("MasterClientTakeDamage", RpcTarget.MasterClient, amount);
        }
        Damaged?.Invoke();
    }
    [PunRPC]
    public void MasterClientTakeDamage(int amount)
    {
        CurrentHealth -= amount;
        _characterHealth = CurrentHealth;
        Damaged?.Invoke();
    }
}

