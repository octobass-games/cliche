using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LevelRenderer: MonoBehaviour
{
    public GameObject MedalSlot;
    public Button Pin;
    public string LevelSceneName;
    public Button PlayButton;
    public string Id;

    public void Initialise(UnityAction<string> LoadLevel, LevelState levelState)
    {
        switch (levelState)
        {
            case LevelState.LOCKED:
                PlayButton.onClick.RemoveAllListeners();
                Pin.enabled = false;
                break;
            case LevelState.UNLOCKED:
                Pin.enabled = true;
                PlayButton.onClick.RemoveAllListeners();
                PlayButton.onClick.AddListener(() => LoadLevel(LevelSceneName));

                break;
            case LevelState.COMPLETED:
                Pin.enabled = true;
                PlayButton.onClick.RemoveAllListeners();
                PlayButton.onClick.AddListener(() => LoadLevel(LevelSceneName));

                break;
        }
    }


}