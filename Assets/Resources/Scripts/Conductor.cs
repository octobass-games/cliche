using System.Collections.Generic;
using UnityEngine;

public class Conductor : MonoBehaviour
{
    public int BeatsPerMinute;
    public GameObject NotePrefab;
    public float[] NoteTimes = { 1, 2, 3 };

    private float BeatsPerSecond = 100;
    private List<GameObject> Notes = new();

    void Start()
    {
        // BeatsPerSecond = 60 / BeatsPerMinute;
        CreateNotes();
    }

    void Update()
    {
        MoveNotes();
    }

    public float GetDistanceFromNextNote()
    {
        return 0f;
    }

    private void CreateNotes()
    {
        for (int i = 0; i < NoteTimes.Length; i++)
        {
            float noteLocation = NoteTimes[i] * BeatsPerSecond;

            GameObject note = Instantiate(NotePrefab);

            note.transform.SetParent(transform);
            note.transform.position = new Vector3(noteLocation, 0, 0);

            Notes.Add(note);
        }
    }

    private void MoveNotes()
    {
        for (int i = 0; i < NoteTimes.Length; i++)
        {
            GameObject note = Notes[i];

            Vector3 displacement = BeatsPerSecond * Vector3.left * Time.deltaTime;
            note.transform.position = note.transform.position + displacement;
        }
    }
}
