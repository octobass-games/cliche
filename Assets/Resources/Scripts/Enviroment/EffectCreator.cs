using System.Collections.Generic;
using UnityEngine;

public class EffectCreator : MonoBehaviour
{
    public List<RandomAnimatorController> Effects;

    public bool StartEffectsOnAwake = false;
    public int ChanceOfEffect = 0;

    public void MakeEffect()
    {
        RandomAnimatorController effect = Effects.PickRandom();
        RandomColour colour = effect.GetComponent<RandomColour>();
        if (colour != null)
        {
            effect.GetComponent<RandomColour>().SetRandomColour();
        }
        effect.RandomAnimation();
    }

    void Update()
    {
       
        if (StartEffectsOnAwake && Random.Range(0, ChanceOfEffect + 1) == ChanceOfEffect) 
        {
            MakeEffect();
        }
    }
}