using UnityEngine;

public class Note : MonoBehaviour
{
    public NoteType NoteType;
    public Animator animator;
    public SpriteRenderer sprite;
    public float InitialX;

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