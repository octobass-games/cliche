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

    public void Render(SerializableLevel level)
    {
        if (level.State == LevelState.COMPLETED)
        {
            SetMedal(Easy, EasyImage, level.EasyMedal, Medals.miniGoldEasyMedal, Medals.miniSilverEasyMedal, Medals.miniBronzeEasyMedal);
            SetMedal(Normal, NormalImage, level.NormalMedal, Medals.miniGoldNormalMedal, Medals.miniSilverNormalMedal, Medals.miniBronzeNormalMedal);
            SetMedal(Hard, HardImage, level.HardMedal, Medals.miniGoldHardMedal, Medals.miniSilverHardMedal, Medals.miniBronzeHardMedal);
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
                    renderer.gameObject.SetActive(false);
                    break;
                case Medal.GOLD:
                    renderer.sprite = gold;
                    break;
                case Medal.SILVER:
                    renderer.sprite = silver;
                    break;
                case Medal.BRONZE:
                    renderer.sprite = bronze;
                    break;
            }
        }

        if (image != null)
        {
            switch (medal)
            {
                case Medal.NONE:
                    image.gameObject.SetActive(false);
                    break;
                case Medal.GOLD:
                    image.sprite = gold;
                    break;
                case Medal.SILVER:
                    image.sprite = silver;
                    break;
                case Medal.BRONZE:
                    image.sprite = bronze;
                    break;
            }
        }
    }
}