using UnityEngine;
using FMODUnity;
using System.Collections.Generic;

public class Conductor : MonoBehaviour
{
    public string PathToSheetMusic;
    public GameObject Track;
    public Judge Judge;
    public List<TimedEvent> TimedEvents;
    private List<bool> TimedEventsComplete;
    public Difficulty Difficulty;

    private StudioEventEmitter MusicEventEmitter;
    private SheetMusic SheetMusic;

    private int CurrentPlaybackPosition;
    private int PreviousPlaybackPosition;

    void Awake()
    {
        TimedEventsComplete = new List<bool>();
        for (var i = 0; i < TimedEvents.Count; i++)
        {
            TimedEventsComplete.Add(false);
        }
    }

    public void Play()
    {
        MusicEventEmitter = GetComponent<StudioEventEmitter>();
        SheetMusic = GetComponent<SheetMusicLoader>().Read(PathToSheetMusic, Difficulty);
        SheetMusic.Notes.ForEach(note => note.transform.SetParent(Track.transform));
        MusicEventEmitter.Play();
    }

    void Update()
    {
        if (MusicEventEmitter != null && MusicEventEmitter.IsPlaying())
        {
            MoveTrack();
        }
    }

    public void PlayedNote(TargetStrikeResult targetStrikeResult)
    {
        var hit = Judge.PassJudgement(targetStrikeResult);

        if (hit)
        {
            RemoveNote();
        }
    }

    public void MissedNote(GameObject note)
    {

        if (note.GetComponent<ChordNote>())
        {
            if (SheetMusic.Notes.Count > 0 && SheetMusic.Notes[0] == note)
            {
                Judge.MissedNote();
                RemoveNote();
            }
        }
        else
        {
            Judge.MissedNote();
            RemoveNote();
        }
    }

    public void Pause()
    {
        MusicEventEmitter.EventInstance.setPaused(true);
    }

    public void Resume()
    {
        MusicEventEmitter.EventInstance.setPaused(false);
    }

    private void RemoveNote()
    {
        GameObject note = SheetMusic.Notes[0].gameObject;
        SheetMusic.Notes.RemoveAt(0);
        Destroy(note);
    }

    private void MoveTrack()
    {
        MusicEventEmitter.EventInstance.getTimelinePosition(out CurrentPlaybackPosition);

        for (var i = 0; i < TimedEvents.Count; i++)
        {
            var timedEvent = TimedEvents[i];
            var timedEventComplete = TimedEventsComplete[i];

            if (!timedEventComplete && timedEvent.PlaybackPositionInMilliseconds <= CurrentPlaybackPosition)
            {
                TimedEventsComplete[i] = true;
                timedEvent.UnityEvent.Invoke();
            }
        }

        float playbackPositionDeltaInSeconds = (CurrentPlaybackPosition - PreviousPlaybackPosition) / 1000f;
        Vector3 displacement = 100 * Vector3.left * playbackPositionDeltaInSeconds;

        Debug.Log("Current playback position in seconds: " + CurrentPlaybackPosition / 1000f);
        Debug.Log("Current note position before moving: " + SheetMusic.Notes[0].transform.position.x);

        for (int i = 0; i < SheetMusic.Notes.Count; i++)
        {
            SheetMusic.Notes[i].transform.position = SheetMusic.Notes[i].transform.position + displacement;
            /*Rigidbody2D noteRigidbody = SheetMusic.Notes[i].GetComponentInChildren<Rigidbody2D>();
            noteRigidbody.position = noteRigidbody.position + new Vector2(displacement.x, displacement.y);*/
        }

        //Track.transform.position = Track.transform.position + displacement;

        Debug.Log("Current note position after moving: " + SheetMusic.Notes[0].transform.position.x);

        PreviousPlaybackPosition = CurrentPlaybackPosition;
    }
}
