using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public List<LevelRenderer> Levels;
    public LevelManager LevelManager;

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
        Levels.ForEach(LoadLevelPin);
    }

    private void LoadLevelPin(LevelRenderer renderer)
    {
        var level = LevelManager.Levels.Find(l => l.Id == renderer.Id);
        renderer.Initialise((levelSceneName) => StartCoroutine(LoadLevel(levelSceneName)), level.State, level.Medal);
    }

    IEnumerator LoadLevel(string levelSceneName)
    {
        Close();
        yield return new WaitForSeconds(0.75f);
        SceneManager.LoadScene(levelSceneName);
    }

}