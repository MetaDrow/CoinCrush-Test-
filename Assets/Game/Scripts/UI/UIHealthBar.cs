using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    [SerializeField] private UIHandler _handler;
    [SerializeField] private Slider _healthSlider;

    private void Start()
    {
        _healthSlider.maxValue = _handler.StartingHealth;
    }

    private void LateUpdate()
    {
        HealthSliderValueCheck(_handler.PlayerHealthCount);
    }

    private void HealthSliderValueCheck(int amount)
    {
        _healthSlider.value = amount;
    }
}
