using System.Collections;
using UnityEngine;

public class AnimatorDecorator : MonoBehaviour
{
    private Animator Animator;
    // Use this for initialization
    void Start()
    {
        Animator = GetComponent<Animator>();
    }


    public void SetBoolToTrue(string boolName)
    {
        Animator.SetBool(boolName, true);
    }

    public void SetBoolToFalse(string boolName)
    {
        Animator.SetBool(boolName, false);

    }
}