using System.Collections.Generic;
using UnityEngine;

public class Conductor : MonoBehaviour
{
    public GameObject NotePrefab;
    public int BPM;

    public float[] BeatLocations = { 1, 2, 3 };

    private const int BeatLength = 100;
    private List<GameObject> Beats = new();

    void Start()
    {
        for (int i = 0; i < BeatLocations.Length; i++)
        {
            float beatLocation = BeatLocations[i] * BeatLength;

            GameObject beat = Instantiate(NotePrefab);
            beat.transform.position = new Vector3(beatLocation, 0, 0);

            Beats.Add(beat);
        }
    }

    void Update()
    {
        for (int i = 0; i < BeatLocations.Length; i++)
        {
            GameObject beat = Beats[i];

            Vector3 displacement = BeatLength * Vector3.left * Time.deltaTime;
            beat.transform.position = beat.transform.position + displacement;
        }
    }
}
