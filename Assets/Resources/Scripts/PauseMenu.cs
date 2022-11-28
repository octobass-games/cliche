using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public PauseManager PauseManager;
    public GameObject RestartButton;
    public GameObject VisitHomeButton;
    public GameObject SkipLevelButton;

    void OnEnable()
    {
        if (!PauseManager.ShowOptionalButtons())
        {
            RestartButton.SetActive(false);
            VisitHomeButton.SetActive(false);
            SkipLevelButton.SetActive(false);
        }    
    }
}
