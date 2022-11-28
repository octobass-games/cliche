using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public PauseManager PauseManager;
    public GameObject VisitHome;
    public GameObject SkipLevel;

    void OnEnable()
    {
        if (!PauseManager.ShowVisitHomeAndSkipLevel())
        {
            VisitHome.SetActive(false);
            SkipLevel.SetActive(false);
        }    
    }
}
