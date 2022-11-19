using UnityEngine;
using FMODUnity;
using UnityEngine.Events;
using System.Collections.Generic;

public class Conductor : MonoBehaviour
{
    public string PathToSheetMusic;
    public GameObject Track;
    public CharacterAnimatorController CharacterAnimatorController;
    public Judge Judge;
    public int Combo;
    public List<TimedEvent> TimedEvents;

    private StudioEventEmitter MusicEventEmitter;
    private SheetMusic SheetMusic;

    private int CurrentPlaybackPosition;
    private int PreviousPlaybackPosition;
    public WordPopup WordPopup;

    void Start()
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
        if (targetStrikeResult.Note == null)
        {
            Debug.Log("Uh oh!");
        }
        else
        {
            ChordNote chordNote = targetStrikeResult.Note.GetComponent<ChordNote>();

            if (chordNote != null)
            {
                if (chordNote.IsFinished())
                {
                    HitNote(targetStrikeResult);
                }
            }
            else
            {
                HitNote(targetStrikeResult);
            }
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

    private void HitNote(TargetStrikeResult targetStrikeResult)
    {
        bool hit = Judge.PassJudgement(targetStrikeResult);
        if (hit)
        {
            Combo += 1;
            WordPopup.DisplayCombo(Combo);
            Debug.Log("Current combo: " + Combo);
            CharacterAnimatorController.RandomDance();
            RemoveNote();
        }else
        {
            WordPopup.StopCombo();
            Combo = 0;
        }

    }

    public void MissedNote()
    {
        Combo = 0;
        WordPopup.StopCombo();
        Judge.MissedNote();
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
