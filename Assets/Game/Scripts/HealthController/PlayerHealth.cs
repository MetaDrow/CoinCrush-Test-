using Photon.Pun;
using UnityEngine;

public class PlayerHealth : HealthController
{
    [SerializeField] private int _characterHealth = 100;
    [SerializeField] public UIHandler _handler;
    [SerializeField] public PhotonView _view;
    [SerializeField] private int _uiID;
    public int uiID
    {
        get => _uiID;
        set => _uiID = value;
    }

    private void Awake()
    {
        uiID = _view.ViewID;

        if (_view.IsMine)
        {
            Logging.instance.Log("This Player ID " + uiID);
        }
    }
    private void Start()
    {
        CurrentHealth = StartingHealth;
        _characterHealth = CurrentHealth;
        _handler.PlayerHealthCount = CurrentHealth;
    }

    public void TakeDamage(int amount, int playerHitID)
    {

        Logging.instance.Log("Player ID" + uiID);

        if (!PhotonNetwork.IsMasterClient) 
        {
            if (PhotonNetwork.IsMasterClient)
            {
                Logging.instance.Log($"Player ID {playerHitID}");
                photonView.RPC("MasterTakeDamage", RpcTarget.MasterClient, amount, playerHitID);
                return;
            }
            else
            {
                Logging.instance.Log($"Player ID {playerHitID}");
                photonView.RPC("ClientTakeDamage", RpcTarget.Others, amount, playerHitID); 
            }

            return;
        }
        else if (PhotonNetwork.IsMasterClient)  
        {
            if (_view.IsMine)
            {
                CurrentHealth -= amount;
                _characterHealth = CurrentHealth;
                this._handler.PlayerHealthCount = _characterHealth;
            }
            else
            {
                photonView.RPC("ClientTakeDamage", RpcTarget.Others, amount, playerHitID); 
            }
        }
    }

    [PunRPC]
    public void ClientTakeDamage(int amount, int playerHitID)
    {
        if (playerHitID == uiID && _view.IsMine)
        {
            Logging.instance.Log("Client Player ID" + uiID);
            Logging.instance.Log("Client Player ID" + playerHitID);
            CurrentHealth -= amount;
            _characterHealth = CurrentHealth;
            _handler.PlayerHealthCount = _characterHealth;
        }
    }

    [PunRPC]
    public void MasterTakeDamage(int amount, int playerHitID)
    {
        if (playerHitID == uiID) // проверяет на стороне мастера при отправке RPC от клиента
        {
            Logging.instance.Log("Master Player ID" + uiID);
            Logging.instance.Log("Master Player ID" + playerHitID);
            CurrentHealth -= amount;
            _characterHealth = CurrentHealth;
            _handler.PlayerHealthCount = _characterHealth;
        }
    }
}

