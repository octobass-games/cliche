using UnityEngine;

public class Note : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer sprite;

    public void SetPerfectCollided()
    {
        sprite.color = Color.green;
    }

    public void SetGoodCollided()
    {
        sprite.color = Color.green;

    }

    public void SetOkayCollided()
    {
        sprite.color = Color.green;
    }
}