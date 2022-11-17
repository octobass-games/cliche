using System.Collections;
using UnityEngine;
using FMODUnity;

public class WordPopup : MonoBehaviour
{
    public TextRenderer TextRenderer;
    public GameObject LetterPrefab;
    public GameObject Score;
    public Animator ComboAnimator;
    public GameObject ComboDisplay;

    FMOD.Studio.EventInstance comboBroke;
    public string comboBreak;

    private void Start()
    {
        comboBroke = FMODUnity.RuntimeManager.CreateInstance(comboBreak);
    }

    public void Perfect()
    {
        MakeWord("Perfect!");
    }

    public void Good()
    {
        MakeWord("Good!");

    }

    public void Okay()
    {
        MakeWord("Okay!");
    }

    public void DisplayScore(int score)
    {
        foreach (Transform child in Score.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        GameObject scoreGO = TextRenderer.MakeWord("" + score, null);
        scoreGO.transform.parent = Score.transform;
        scoreGO.transform.localPosition = Vector2.zero;
    }


    public void DisplayCombo(int combo)
    {
        Debug.Log("CoMBO!");
        FMODUnity.RuntimeManager.PlayOneShot(comboBreak);
        foreach (Transform child in ComboDisplay.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        ComboAnimator.SetBool("Open", true);

        GameObject scoreGO = TextRenderer.MakeWord("" + combo, null);
        scoreGO.transform.parent = ComboDisplay.transform;
        scoreGO.transform.localPosition = Vector2.zero;
    }


    public void StopCombo()
    {
        Debug.Log("BREAK!");

        foreach (Transform child in ComboDisplay.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        ComboAnimator.SetBool("Open", false);
    }


    private void MakeWord(string text)
    {
        GameObject gm =TextRenderer.MakeWord(text, LetterPrefab);
        var screenSize = ScreenSize();
        gm.transform.position = new Vector2(Random.Range(0, screenSize.x - 20), Random.Range(0, screenSize.y-20));
        StartCoroutine(DestroyWordAfterTime(gm));
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