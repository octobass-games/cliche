using UnityEngine;

public class Note : MonoBehaviour
{
    public NoteType NoteType;
    public Animator animator;
    public SpriteRenderer sprite;
    public float InitialX;

    public void SetPerfectCollided()
    {
        sprite.color = new Color(0.24f, 0.76f, 0.25f);
        animator.SetTrigger("connect");
    }

    public void SetGoodCollided()
    {
        sprite.color = new Color(0.8f, 1, 0.2f);
        animator.SetTrigger("connect");

    }

    public void SetOkayCollided()
    {
        sprite.color = new Color(1, 0.8f, 0);
        animator.SetTrigger("connect");
    }
}