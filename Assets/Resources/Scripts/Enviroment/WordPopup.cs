using System.Collections;
using UnityEngine;
using FMODUnity;

public class WordPopup : MonoBehaviour
{
    public TextRenderer TextRenderer;
    public GameObject WordPrefab;
    public GameObject Score;
    public Animator ComboAnimator;
    public GameObject ComboDisplay;
    public Sprite PerfectSprite;
    public Sprite GoodSprite;
    public Sprite OkaySprite;

    FMOD.Studio.EventInstance comboBroke;
    public string comboBreak;

    private void Start()
    {
        comboBroke = FMODUnity.RuntimeManager.CreateInstance(comboBreak);
    }

    public void Perfect()
    {
        MakeWord(PerfectSprite);
    }

    public void Good()
    {
        MakeWord(GoodSprite);

    }

    public void Okay()
    {
        MakeWord(OkaySprite);
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
        foreach (Transform child in ComboDisplay.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        ComboAnimator.SetBool("Open", true);

        GameObject scoreGO = TextRenderer.MakeWord("" + combo, null, -2);
        scoreGO.transform.parent = ComboDisplay.transform;
        scoreGO.transform.localPosition = new Vector2(0, -2);
    }


    public void StopCombo()
    {
        Debug.Log("BREAK!");
        FMODUnity.RuntimeManager.PlayOneShot(comboBreak);

        foreach (Transform child in ComboDisplay.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        ComboAnimator.SetBool("Open", false);
    }


    private void MakeWord(Sprite word)
    {
        GameObject gm = Instantiate(WordPrefab);
        SpriteRenderer renderer = gm.GetComponent<SpriteRenderer>();
        renderer.sprite = word;
        var screenSize = ScreenSize();
        gm.transform.position = new Vector2(Random.Range(word.bounds.size.x, screenSize.x - word.bounds.size.x), Random.Range(30, screenSize.y-20));
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