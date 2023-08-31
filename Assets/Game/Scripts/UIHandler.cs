using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    // [SerializeField] private PlayerHealth playerHealth;
    //[SerializeField] private HealthController _healthController;

    [SerializeField] internal Slider _healthSlider;
    [SerializeField] PhotonView _view;
    private void OnEnable()
    {
        PlayerHealth.Damaged += OnDamage;
        //_playerHealth.Damaged += OnTakeDamage;
    }
    private void OnDisable()
    {
        Bullet.Damage += OnDamage;
    }
    void Start()
    {
        // _healthSlider.maxValue = _healthController.MaxHealth;
        // _healthSlider.value = _healthController.StartingHealth;
        //  Debug.Log(_healthController.StartingHealth);
        //_healthSlider.value = HealthController.Instance.CurrentHealth;
    }

    private void Update()
    {
        /*
        if (!PhotonNetwork.IsMasterClient)
        {

            photonView.RPC("OnTakeDamage", RpcTarget.MasterClient, _healthSlider);
            Debug.Log("no master" + _healthController.CurrentHealth);
        }
        // _healthSlider.maxValue = _playerHealth._maxHealth;
        if (PhotonNetwork.IsMasterClient)
        {
            _healthSlider.value = _healthController.CurrentHealth;
            Debug.Log("master" + _healthController.CurrentHealth);

        }
        */

    }
    [PunRPC]
    private void OnDamage()
    {

        // _healthSlider.value = _healthController.CurrentHealth;
        /*
        if (!PhotonNetwork.IsMasterClient)
        {
            photonView.RPC("OnDamage", RpcTarget.MasterClient);

        }
        */



    }


    public void OnTakeDamage(int amount)
    {
        //  StartCoroutine(Damage());

    }

    public void QuitApp() // unity button event 
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
