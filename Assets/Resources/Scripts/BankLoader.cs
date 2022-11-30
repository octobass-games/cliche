using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BankLoader : MonoBehaviour
{
    [FMODUnity.BankRef]
    public List<string> banks;

    public void Start()
    {
        foreach (string b in banks)
        {
            FMODUnity.RuntimeManager.LoadBank(b, true);
        }

        /*
            For Chrome / Safari browsers / WebGL.  Reset audio on response to user interaction (LoadBanks is called from a button press), to allow audio to be heard.
        */
        FMODUnity.RuntimeManager.CoreSystem.mixerSuspend();
        FMODUnity.RuntimeManager.CoreSystem.mixerResume();

        StartCoroutine(CheckBanksLoadedAndLoadMainMenu());
    }

    IEnumerator CheckBanksLoadedAndLoadMainMenu()
    {
        while (!FMODUnity.RuntimeManager.HaveAllBanksLoaded)
        {
            yield return null;
        }

        LoadNextScene();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
