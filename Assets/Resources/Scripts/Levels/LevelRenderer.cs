using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LevelRenderer: MonoBehaviour
{
    public GameObject MedalSlot;
    public Sprite GoldMedalSprite;
    public Sprite SilverMedalSprite;
    public Sprite BronzeMedalSprite;
    public Button Pin;
    public string LevelSceneName;
    public Sprite UnlockedSprite;
    public Sprite CompletedSprite;
    public Image Face;
    public string Id;

    public void Initialise(UnityAction<string> LoadLevel, LevelState levelState, Medal levelMedal)
    {
        Debug.Log("levelState:" + levelState + Id);
        switch (levelState)
        {
            case LevelState.LOCKED:
                Pin.gameObject.SetActive(false);
                break;
            case LevelState.UNLOCKED:
                Face.sprite = UnlockedSprite;
                MedalSlot.SetActive(false);
                Pin.gameObject.SetActive(true);
                break;
            case LevelState.COMPLETED:
                MedalSlot.SetActive(true);
                Face.sprite = CompletedSprite;
                Pin.gameObject.SetActive(true);
                MedalSlot.GetComponent<Image>().sprite = GetMedalSprite(levelMedal);

                break;
        }
    }

    private Sprite GetMedalSprite(Medal levelMedal)
    {
        if (levelMedal == Medal.GOLD)
        {
            return GoldMedalSprite;
        }
        else if (levelMedal == Medal.SILVER)
        {
            return SilverMedalSprite;
        }
        else
        {
            return BronzeMedalSprite;
        }
    }
}