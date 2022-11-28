using UnityEngine;

public class Note : MonoBehaviour
{
    public bool Played = false;
    public NoteType NoteType;
    public Animator animator;
    public SpriteRenderer sprite;
    public float InitialX;
    public GameObject SuccessPrefab;

    public void Play() => Played = true;

    public void SetPerfectCollided() => SpawnSuccessNote(new Color(0.24f, 0.76f, 0.25f));

    public void SetGoodCollided() => SpawnSuccessNote(new Color(0.8f, 1, 0.2f));

    public void SetOkayCollided() => SpawnSuccessNote(new Color(1, 0.8f, 0));

    public void SpawnSuccessNote(Color color)
    {
        GameObject success = Instantiate(SuccessPrefab);

        success.transform.position = transform.position;
        success.GetComponentInChildren<SpriteRenderer>().color = color;
        success.GetComponentInChildren<Animator>().SetTrigger("connect");
    }
}