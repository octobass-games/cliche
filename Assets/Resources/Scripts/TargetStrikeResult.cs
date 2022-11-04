using UnityEngine;

public struct TargetStrikeResult
{
    public TargetStrikeResult(float distanceFromCentre, GameObject note)
    {
        DistanceFromCentre = distanceFromCentre;
        Note = note;
    }

    public float DistanceFromCentre { get; }
    public GameObject Note { get; }
}
