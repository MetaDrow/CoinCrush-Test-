using UnityEngine;

[CreateAssetMenu(menuName = "Settings/UIHandler ")]
public class UIHandler : ScriptableObject
{
    [SerializeField] private int _playerHealthCount;
    [SerializeField] private int _uiSliderCount;
    private int _startingUISliderCount = 100;

    public int PlayerHealthCount
    {
        get => _playerHealthCount;
        set => _playerHealthCount = value;
    }
    public int StartingHealth
    {
        get => _startingUISliderCount;
        set => _startingUISliderCount = value;
    }
}
