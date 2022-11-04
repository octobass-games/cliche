using System.Collections;
using UnityEngine;

public class CharacterAnimatorController : MonoBehaviour
{
    public Animator Animator;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ResetAnimator()
    {
        Animator.SetInteger("Dance", 0);
    }


    public void RandomDance()
    {
        int danceN = Random.Range(1, 6);
        Animator.SetInteger("Dance", danceN);
    }
}