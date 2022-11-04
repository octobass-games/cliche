using System.Collections;
using UnityEngine;

public class Note : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer sprite;
    public bool success = false;

    public void Initialise()
    {

    }


    public void SetPerfectCollided()
    {
        success = true;
        sprite.color = Color.green;
    }
    public void SetGoodCollided()
    {
        success = true;
        sprite.color = Color.green;

    }

    public void SetOkayCollided()
    {
        success = true;
        sprite.color = Color.green;

    }
}