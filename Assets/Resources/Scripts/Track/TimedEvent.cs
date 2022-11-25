using UnityEngine.Events;

[System.Serializable]
public struct TimedEvent
{
    public int PlaybackPositionInMilliseconds;
    public UnityEvent UnityEvent;
}
