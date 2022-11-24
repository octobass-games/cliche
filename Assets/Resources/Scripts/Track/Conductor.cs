using UnityEngine;
using FMODUnity;
using UnityEngine.Events;
using System.Collections.Generic;

public class Conductor : MonoBehaviour
{
    public string PathToSheetMusic;
    public GameObject Track;
    public Judge Judge;
    public List<TimedEvent> TimedEvents;

    private StudioEventEmitter MusicEventEmitter;
    private SheetMusic SheetMusic;

    private int CurrentPlaybackPosition;
    private int PreviousPlaybackPosition;

    public void Play()
    {
        MusicEventEmitter = GetComponent<StudioEventEmitter>();
        SheetMusic = GetComponent<SheetMusicLoader>().Read(PathToSheetMusic);
        SheetMusic.Notes.ForEach(note => note.transform.SetParent(Track.transform));
        MusicEventEmitter.Play();
    }

    void Update()
    {
        MoveTrack();
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
        Judge.MissedNote();

        if (note.GetComponent<ChordNote>())
        {
            if (SheetMusic.Notes.Count > 0 && SheetMusic.Notes[0] == note)
            {
                RemoveNote();
            }
        }
        else
        {
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

        TimedEvents.ForEach(timedEvent =>
        {
            if (!timedEvent.IsComplete && timedEvent.PlaybackPositionInMilliseconds <= CurrentPlaybackPosition)
            {
                timedEvent.IsComplete = true;
                timedEvent.UnityEvent.Invoke();
            }
        });

        float playbackPositionDeltaInSeconds = (CurrentPlaybackPosition - PreviousPlaybackPosition) / 1000f;
        Vector3 displacement = 100 * Vector3.left * playbackPositionDeltaInSeconds;
        Track.transform.position = Track.transform.position + displacement;

        PreviousPlaybackPosition = CurrentPlaybackPosition;
    }
}
