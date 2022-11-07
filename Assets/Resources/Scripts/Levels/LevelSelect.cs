using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public List<LevelRenderer> Levels;

    public GameObject Phone;
    public Animator PhoneAnimator;

  public   void Open()
    {
        Phone.SetActive(true);
    }

    public void Close()
    {
        PhoneAnimator.SetTrigger("close");
    }

    void Awake()
    {
        Levels.ForEach(l => l.Initialise((levelSceneName) => StartCoroutine(LoadLevel(levelSceneName)), LevelState.UNLOCKED));
    }

    IEnumerator LoadLevel(string levelSceneName)
    {
        Close();
        yield return new WaitForSeconds(0.75f);
        SceneManager.LoadScene(levelSceneName);
    }

}