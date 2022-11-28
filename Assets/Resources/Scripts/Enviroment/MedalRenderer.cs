using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MedalRenderer : MonoBehaviour
{
    public Medals Medals;
    public SpriteRenderer Easy;
    public SpriteRenderer Normal;
    public SpriteRenderer Hard;
    public Image EasyImage;
    public Image NormalImage;
    public Image HardImage;

    public Color UnachievedMedalColour;

    public bool Large = false;
    public bool RenderDefaults = false;

    public void Render(Level level)
    {
        var small = !Large;
        if (level.State == LevelState.COMPLETED)
        {
            SetMedal(Easy, EasyImage, level.EasyMedal, Medals.EasyGold(small), Medals.EasySilver(small), Medals.EasyBronze(small));
            SetMedal(Normal, NormalImage, level.NormalMedal, Medals.NormalGold(small), Medals.NormalSilver(small), Medals.NormalBronze(small));
            SetMedal(Hard, HardImage, level.HardMedal, Medals.HardGold(small), Medals.HardSilver(small), Medals.HardBronze(small));
        }
        else
        {
            if (Easy != null) Easy.gameObject.SetActive(false);
            if (Normal != null) Normal.gameObject.SetActive(false);
            if (Hard != null) Hard.gameObject.SetActive(false);
            if (EasyImage != null) EasyImage.gameObject.SetActive(false);
            if (NormalImage != null) NormalImage.gameObject.SetActive(false);
            if (HardImage != null) HardImage.gameObject.SetActive(false);
        }
    }


    private void SetMedal(SpriteRenderer renderer, Image image, Medal medal, Sprite gold, Sprite silver, Sprite bronze)
    {
        if (renderer != null)
        {
            switch (medal)
            {
                case Medal.NONE:
                    if (RenderDefaults)
                    {
                        renderer.sprite = bronze;
                        renderer.gameObject.SetActive(true);
                        renderer.color = UnachievedMedalColour;
                    }
                    else
                    {
                        renderer.gameObject.SetActive(false);
                    }
                    break;
                case Medal.GOLD:
                    renderer.sprite = gold;
                    renderer.gameObject.SetActive(true);
                    renderer.color = Color.white;
                    break;
                case Medal.SILVER:
                    renderer.sprite = silver;
                    renderer.gameObject.SetActive(true);
                    renderer.color = Color.white;
                    break;
                case Medal.BRONZE:
                    renderer.sprite = bronze;
                    renderer.gameObject.SetActive(true);
                    renderer.color = Color.white;
                    break;
            }
        }

        if (image != null)
        {
            switch (medal)
            {
                case Medal.NONE:
                    if (RenderDefaults)
                    {
                        image.color = UnachievedMedalColour;
                        image.sprite = bronze;
                        image.gameObject.SetActive(true);
                    }
                    else
                    {
                        image.gameObject.SetActive(false);
                    }
                    break;
                case Medal.GOLD:
                    image.sprite = gold;
                    image.gameObject.SetActive(true);
                    image.color = Color.white;
                    break;
                case Medal.SILVER:
                    image.sprite = silver;
                    image.gameObject.SetActive(true);
                    image.color = Color.white;
                    break;
                case Medal.BRONZE:
                    image.sprite = bronze;
                    image.gameObject.SetActive(true);
                    image.color = Color.white;
                    break;
            }
        }
    }
}