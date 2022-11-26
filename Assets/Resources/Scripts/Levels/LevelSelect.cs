using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public List<LevelRenderer> Levels;
    public LevelManager LevelManager;

    public GameObject Phone;
    public Animator PhoneAnimator;
    public Animator Fade;

    public Image EasySelected;
    public Image NormalSelected;
    public Image HardSelected;

    public Image Title;
    public GameObject LevelSummary;

    public Sprite BronzeMedal;
    public Sprite SilverMedal;
    public Sprite GoldMedal;

    public Sprite SirenTitle;
    public Sprite ForestTitle;
    public Sprite SpookyTitle;
    public Sprite CityTitle;
    public Sprite ChillTitle;
    public Sprite ScifiTitle;
    public Sprite BattleTitle;
    public Sprite PartyTitle;

    public Button PlayButton;

    public void Open()
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
        PhoneAnimator.SetTrigger("closeAndFade");
        Fade.SetTrigger("out");
        yield return new WaitForSeconds(0.75f);
        SceneManager.LoadScene(levelSceneName);
    }

    public void SelectEasy()
    {
        SetSelectedSprite(easy: true);
    }

    public void SelectNormal()
    {
        SetSelectedSprite(normal: true);
    }

    public void SelectHard()
    {
        SetSelectedSprite(hard: true);
    }

    private void SetSelectedSprite(bool easy = false, bool normal = false, bool hard = false)
    {
        EasySelected.enabled = easy;
        NormalSelected.enabled = normal;
        HardSelected.enabled = hard;
    }

    public void OpenLevelSummary(string levelName)
    {
        Title.sprite = TitleSprite(levelName);
        LevelSummary.SetActive(true);
        PlayButton.onClick.RemoveAllListeners();
        PlayButton.onClick.AddListener(() => LoadLevel(levelName));
    }

    public void CloseLevelSummary()
    {
        LevelSummary.SetActive(false);
    }

    private Sprite TitleSprite(string levelName)
    {
        switch (levelName)
        {
            case "Siren":
                return SirenTitle;
            case "Forest":
                return ForestTitle;
            case "Spooky":
                return SpookyTitle;
            case "City":
                return CityTitle;
            case "Chill":
                return ChillTitle;
            case "Scifi":
                return ScifiTitle;
            case "Battle":
                return BattleTitle;
            case "Party":
                return PartyTitle;
        }
        return null;
    }
}