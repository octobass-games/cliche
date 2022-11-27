using UnityEngine;
using UnityEngine.UI;

public class LevelRenderer: MonoBehaviour
{
    public MedalRenderer MedalSlot;
    public Button Pin;
    public Sprite UnlockedSprite;
    public Sprite CompletedSprite;
    public Image Face;
    public string Id;
    public GameObject Extra;

    public void Initialise(Level level)
    {
        MedalSlot.Render(level);
        switch (level.State)
        {
            case LevelState.LOCKED:
                Pin.gameObject.SetActive(false);
                if (Extra != null)
                {
                    Extra.gameObject.SetActive(false);
                }
                break;
            case LevelState.UNLOCKED:
                Face.sprite = UnlockedSprite;
                Pin.gameObject.SetActive(true);
                if (Extra != null)
                {
                    Extra.gameObject.SetActive(true);
                }
                break;
            case LevelState.COMPLETED:
                Face.sprite = CompletedSprite;
                Pin.gameObject.SetActive(true);
                if (Extra != null)
                {
                    Extra.gameObject.SetActive(true);
                }

                break;
        }
    }

}