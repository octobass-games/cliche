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
    public LevelManager LevelManager;

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
        Difficulty = GameManager.Instance.Difficulty;
        MusicEventEmitter = GetComponent<StudioEventEmitter>();
    }

    public void Play()
    {
        SheetMusic = GetComponent<SheetMusicLoader>().Read(PathToSheetMusic, Difficulty);
        SheetMusic.Notes.ForEach(note => note.transform.SetParent(Track.transform));
        LevelManager.MaxScore = (50 * 100 + (SheetMusic.Notes.Count - 50) * 200);
        MusicEventEmitter.Play();
    }

    void FixedUpdate()
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
            RemoveNote(targetStrikeResult.Note);
        }
    }

    public void MissedNote(GameObject note)
    {
        if (note.GetComponent<ChordNote>() != null)
        {
            Judge.MissedNote();
            RemoveNote(note);
        }
        else
        {
            Judge.MissedNote();
            RemoveNote(note);
        }
    }

    void OnDestroy()
    {
        MusicEventEmitter.EventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        MusicEventEmitter.EventInstance.release();
    }

    public void Pause()
    {
        MusicEventEmitter.EventInstance.setPaused(true);
    }

    public void Resume()
    {
        MusicEventEmitter.EventInstance.setPaused(false);
    }

    private void RemoveNote(GameObject noteToRemove)
    {
        var noteIndex = SheetMusic.Notes.FindIndex(n => noteToRemove == n);
        if (noteIndex == -1)
        {
            return;
        }
        SheetMusic.Notes.RemoveAt(noteIndex);
        Destroy(noteToRemove);
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

        for (int i = 0; i < SheetMusic.Notes.Count; i++)
        {
            // SheetMusic.Notes[i].transform.position = SheetMusic.Notes[i].transform.position + displacement;
            Rigidbody2D noteRigidbody = SheetMusic.Notes[i].GetComponentInChildren<Rigidbody2D>();
            noteRigidbody.MovePosition(noteRigidbody.position + new Vector2(displacement.x, displacement.y));
        }

        PreviousPlaybackPosition = CurrentPlaybackPosition;
    }
}
