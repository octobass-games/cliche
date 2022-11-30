using UnityEngine;

public class Hoverable : MonoBehaviour
{
    public Color OnHoverColor;

    private Color InitialColor;
    private SpriteRenderer SpriteRenderer;

    void Awake()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        InitialColor = SpriteRenderer.color;
    }

    public void OnMouseEnter()
    {
        SpriteRenderer.color = OnHoverColor;
    }

    public void OnMouseExit()
    {
        SpriteRenderer.color = InitialColor;
    }
}
