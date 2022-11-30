using UnityEngine;

public class ContinueButton : MonoBehaviour
{
    void Awake()
    {
    }

    void Start()
    {
        if (!GameManager.Instance.HasSaveData())
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

            Color initialColor = spriteRenderer.color;
            spriteRenderer.color = new Color(initialColor.r, initialColor.g, initialColor.b, 0.5f);

            Destroy(gameObject.GetComponent<Clickable>());
            Destroy(gameObject.GetComponent<Hoverable>());
        }
    }
}
