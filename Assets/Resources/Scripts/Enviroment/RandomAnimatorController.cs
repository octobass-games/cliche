using UnityEngine;

public class RandomAnimatorController : MonoBehaviour
{
    public Animator Animator;
    public int NumberOfAnimations;

    public void RandomAnimation()
    {
        Animator.SetTrigger(Random.Range(1, NumberOfAnimations).ToString());
    }

}