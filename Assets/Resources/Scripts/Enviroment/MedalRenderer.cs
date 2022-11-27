using System.Collections;
using UnityEngine;

public class MedalRenderer : MonoBehaviour
{
    public Medals Medals;
    public SpriteRenderer Easy;
    public SpriteRenderer Normal;
    public SpriteRenderer Hard;


    public void Render(SerializableLevel level)
    {
        if (level.State == LevelState.COMPLETED)
        {
            SetMedal(Easy, level.EasyMedal, Medals.miniGoldEasyMedal, Medals.miniSilverEasyMedal, Medals.miniBronzeEasyMedal);
            SetMedal(Normal, level.NormalMedal, Medals.miniGoldNormalMedal, Medals.miniSilverNormalMedal, Medals.miniBronzeNormalMedal);
            SetMedal(Hard, level.HardMedal, Medals.miniGoldHardMedal, Medals.miniSilverHardMedal, Medals.miniBronzeHardMedal);
        }
        else
        {
            Easy.gameObject.SetActive(false);
            Normal.gameObject.SetActive(false);
            Hard.gameObject.SetActive(false);
        }
    }

    private void SetMedal(SpriteRenderer renderer, Medal medal, Sprite gold, Sprite silver, Sprite bronze)
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
}