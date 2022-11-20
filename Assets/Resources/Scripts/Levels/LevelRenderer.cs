using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LevelRenderer: MonoBehaviour
{
    public GameObject MedalSlot;
    public Button Pin;
    public string LevelSceneName;
    public Button PlayButton;
    public Sprite UnlockedSprite;
    public Sprite CompletedSprite;
    public Image Face;
    public string Id;

    public void Initialise(UnityAction<string> LoadLevel, LevelState levelState)
    {
        Debug.Log("levelState:" + levelState + Id);
        switch (levelState)
        {
            case LevelState.LOCKED:
                PlayButton.onClick.RemoveAllListeners();
                Pin.gameObject.SetActive(false);
                break;
            case LevelState.UNLOCKED:
                Face.sprite = UnlockedSprite;
                MedalSlot.SetActive(false);
                Pin.gameObject.SetActive(true);
                PlayButton.onClick.RemoveAllListeners();
                PlayButton.onClick.AddListener(() => LoadLevel(LevelSceneName));
                break;
            case LevelState.COMPLETED:
                MedalSlot.SetActive(true);
                Face.sprite = CompletedSprite;
                Pin.gameObject.SetActive(true);
                PlayButton.onClick.RemoveAllListeners();
                PlayButton.onClick.AddListener(() => LoadLevel(LevelSceneName));

                break;
        }
    }


}