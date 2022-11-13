using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectCreator : MonoBehaviour
{
    public List<RandomAnimatorController> Effects;

    public void MakeEffect()
    {
        RandomAnimatorController effect = Effects.PickRandom();
        effect.GetComponent<RandomColour>().SetRandomColour();
        effect.RandomAnimation();
    }

    private Vector2 ScreenSize()
    {
        float height = UnityEngine.Camera.main.orthographicSize * 2.0f;
        float width = height * Screen.width / Screen.height;

        return new Vector2(width, height);
    }


    IEnumerator DestroyWordAfterTime(GameObject go)
    {
        yield return new WaitForSeconds(2);
        Destroy(go);
    }


}