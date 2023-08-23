using UnityEngine;

[CreateAssetMenu(menuName = "Settings/GameSettings ")]
public class GameSettings : ScriptableObject
{
    [SerializeField] private string _gameVersion = "0.0.0";
    [SerializeField] private string _nickname = "Player";

    private static GameSettings _instance;
    public static GameSettings Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameSettings();
            }
            return _instance;
        }
    }
    public static string GameVersion
    {
        get
        {
            return Instance._gameVersion;
        }
    }

    public static string NickName
    {
        get
        {
            int namePostfix = Random.Range(0, 99);
            return Instance._nickname + namePostfix;
        }
    }
}
