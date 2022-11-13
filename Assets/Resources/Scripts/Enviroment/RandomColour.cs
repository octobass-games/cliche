using System.Collections.Generic;
using UnityEngine;

public class RandomColour : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer;
    public List<Color> Colours;


    public void SetRandomColour()
    {
        SpriteRenderer.color = Colours.PickRandom();
    }

}