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
    public MedalRenderer MedalRenderer;

    public Sprite SirenTitle;
    public Sprite ForestTitle;
    public Sprite SpookyTitle;
    public Sprite CityTitle;
    public Sprite ChillTitle;
    public Sprite ScifiTitle;
    public Sprite BattleTitle;
    public Sprite PartyTitle;

    public Button PlayButton;
    public TMPro.TextMeshProUGUI Score;

    private Level SelectedLevel;
    private Difficulty Difficulty;

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
        var level = LevelManager.FindLevel(renderer.Id);
        renderer.Initialise(level);
    }

    IEnumerator LoadLevel(string levelSceneName)
    {
        CloseLevelSummary();
        PhoneAnimator.SetTrigger("closeAndFade");
        Fade.SetTrigger("out");
        yield return new WaitForSeconds(0.75f);
        FindObjectOfType<GameManager>().LoadLevel(levelSceneName, Difficulty);
    }

    public void SelectEasy()
    {
        SetSelectedSprite(easy: true);
        Score.text = SelectedLevel.EasyHighScore + "";
        Difficulty = Difficulty.EASY;
    }

    public void SelectNormal()
    {
        SetSelectedSprite(normal: true);
        Score.text = SelectedLevel.NormalHighScore + "";
        Difficulty = Difficulty.NORMAL;
    }

    public void SelectHard()
    {
        SetSelectedSprite(hard: true);
        Score.text = SelectedLevel.HardHighScore + "";
        Difficulty = Difficulty.HARD;
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
        PlayButton.onClick.RemoveAllListeners();
        PlayButton.onClick.AddListener(() => StartCoroutine(LoadLevel(levelName)));
        SelectedLevel = LevelManager.Levels.Find(l => l.Id == levelName);
        Score.text = "0";
        MedalRenderer.Render(SelectedLevel);

        LevelSummary.SetActive(true);
    }

    public void CloseLevelSummary()
    {
        Debug.Log("CloseLevelSummary");

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