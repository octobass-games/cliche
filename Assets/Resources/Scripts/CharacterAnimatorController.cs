using System.Collections;
using UnityEngine;

public class CharacterAnimatorController : MonoBehaviour
{
    private bool CanPlayDance = true;
    public Animator Animator;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Run()
    {
        if (Animator != null)
        {
            Animator.SetBool("Run", true);
        }
    }

    public void Sleep()
    {
        if (Animator != null)
        {
            Animator.SetBool("Sleep", true);
        }
    }


    public void WakeUp()
    {
        if (Animator != null)
        {
            Animator.SetBool("Sleep", false);
        }
    }


    public void ResetAnimator()
    {
        CanPlayDance = true;
    }


    public void RandomDance()
    {
        if (!CanPlayDance || Animator.GetBool("Sleep"))
        {
            return;
        }
        CanPlayDance = false;
        int maxDance = 5;
        int danceN = Random.Range(1, maxDance + 1);
        Animator.SetTrigger(danceN + "");
    }
}