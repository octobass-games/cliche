using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextRenderer : MonoBehaviour
{
    public List<Color> colours;
    public AlphaNumericContainer alphabet;
    public string Layer = "Text";

    public GameObject MakeWord(string word, GameObject prefab)
    {
        var sprites = GetSpritesForWord(word);

        GameObject parent = new GameObject();
        Color color = colours.PickRandom(); 
        for (int i = 0; i < sprites.Count; i++)
        {
            Sprite sprite = sprites[i];
            Sprite prevSprite = i == 0 ? null : sprites[i - 1];
            SpriteRenderer renderer;

            GameObject child;
            if (prefab == null)
            {
                child = new GameObject();
                renderer = child.AddComponent<SpriteRenderer>();
            }
            else
            {
                child = Instantiate(prefab);
                renderer = child.GetComponent<SpriteRenderer>();
            }

            renderer.sprite = sprite;
            renderer.color = color;
            renderer.sortingLayerName = Layer;
            child.transform.SetParent(parent.transform);

            child.transform.localPosition = new Vector2(0, 0);
            if (i != 0) {
                var prevChild = parent.transform.GetChild(i - 1);

                if (prevSprite != null)
                {
                    child.transform.localPosition = new Vector2(prevChild.localPosition.x + prevSprite.bounds.size.x + 2, 0);
                }
            }
         
        }

        return parent;
    }

    public GameObject MakeUIWord(string word, GameObject parent, GameObject prefab)
    {
        var sprites = GetSpritesForWord(word);

        if (parent == null)
        {
            parent = new GameObject();
            parent.AddComponent<HorizontalLayoutGroup>();

        }
        Color color = colours.PickRandom();
        for (int i = 0; i < sprites.Count; i++)
        {
            Sprite sprite = sprites[i];
            Sprite prevSprite = i == 0 ? null : sprites[i - 1];
            Image renderer;

            GameObject child;
            if (prefab == null)
            {
                child = new GameObject();
                renderer = child.AddComponent<Image>();
            }
            else
            {
                child = Instantiate(prefab);
                renderer = child.GetComponent<Image>();
            }

            renderer.sprite = sprite;
            renderer.preserveAspect = true;
            renderer.color = color;

            child.transform.parent = parent.transform;
        }

        return parent;
    }

    private List<Sprite> GetSpritesForWord(string word)
    {
        List<Sprite> sprites = new List<Sprite>();
        foreach (char c in word.ToLower())
        {
            var sprite = GetSpriteForCharacter(c);

            if (sprite != null)
            {
                sprites.Add(sprite);
            }
        }


        return sprites;
    }

    private Sprite GetSpriteForCharacter(char character)
    {
        switch (character)
        {
            case 'a': return alphabet.A;
            case 'b': return alphabet.B;
            case 'c': return alphabet.C;
            case 'd': return alphabet.D;
            case 'e': return alphabet.E;
            case 'f': return alphabet.F;
            case 'g': return alphabet.G;
            case 'h': return alphabet.H;
            case 'i': return alphabet.I;
            case 'j': return alphabet.J;
            case 'k': return alphabet.K;
            case 'l': return alphabet.L;
            case 'm': return alphabet.M;
            case 'n': return alphabet.N;
            case 'o': return alphabet.O;
            case 'p': return alphabet.P;
            case 'q': return alphabet.Q;
            case 'r': return alphabet.R;
            case 's': return alphabet.S;
            case 't': return alphabet.T;
            case 'u': return alphabet.U;
            case 'v': return alphabet.V;
            case 'w': return alphabet.W;
            case 'x': return alphabet.X;
            case 'y': return alphabet.Y;
            case 'z': return alphabet.Z;
            case '1': return alphabet.One;
            case '2': return alphabet.Two;
            case '3': return alphabet.Three;
            case '4': return alphabet.Four;
            case '5': return alphabet.Five;
            case '6': return alphabet.Six;
            case '7': return alphabet.Seven;
            case '8': return alphabet.Eight;
            case '9': return alphabet.Nine;
            case '0': return alphabet.Zero;
            case '!': return alphabet.ExclamationMark;
            case ' ': return alphabet.Space;
            case ':': return alphabet.Colon;
            case '%': return alphabet.Percentage;
        }
        return null;
    }
}