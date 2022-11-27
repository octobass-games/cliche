using UnityEngine;

public class PlaySound : MonoBehaviour
{
    FMOD.Studio.EventInstance EventInstance;

    public string path;

    bool isPlaying = false;


    private void Start()
    {
        if (path != "")
        {
            EventInstance = FMODUnity.RuntimeManager.CreateInstance(path);
        }
    }

    public void PlayOneShot()
    {
        if (path != "")
        {
            FMODUnity.RuntimeManager.PlayOneShot(path);
        }
    }

    public void PlayLoop()
    {
        if (isPlaying == false)
        {
            EventInstance.start();
            isPlaying = true;
        }

        else if (isPlaying == true)
        {
            EventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            isPlaying = false;
        }
    }
}
