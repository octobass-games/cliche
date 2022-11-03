using System.Collections.Generic;
using UnityEngine;

public class Conductor : MonoBehaviour
{
    public GameObject NotePrefab;
    public float[] NoteTimes = { 1, 2, 3 };

    private const int BeatLength = 100;
    private List<GameObject> Notes = new();

    void Start()
    {
        for (int i = 0; i < NoteTimes.Length; i++)
        {
            float noteLocation = NoteTimes[i] * BeatLength;

            GameObject note = Instantiate(NotePrefab);

            note.transform.SetParent(transform);
            note.transform.position = new Vector3(noteLocation, 0, 0);

            Notes.Add(note);
        }
    }

    void Update()
    {
        for (int i = 0; i < NoteTimes.Length; i++)
        {
            GameObject note = Notes[i];

            Vector3 displacement = BeatLength * Vector3.left * Time.deltaTime;
            note.transform.position = note.transform.position + displacement;
        }
    }
}
