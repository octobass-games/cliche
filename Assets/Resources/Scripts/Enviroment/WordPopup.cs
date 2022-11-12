using System.Collections;
using UnityEngine;

public class WordPopup : MonoBehaviour
{
    public TextRenderer TextRenderer;
    public GameObject LetterPrefab;


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