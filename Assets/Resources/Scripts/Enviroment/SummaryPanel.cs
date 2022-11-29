using UnityEngine;
using UnityEngine.UI;

public class SummaryPanel : MonoBehaviour
{
    public TMPro.TextMeshProUGUI PerfectScore;
    public TMPro.TextMeshProUGUI GoodScore;
    public TMPro.TextMeshProUGUI OkayScore;
    public TMPro.TextMeshProUGUI ComboScore;
    public TMPro.TextMeshProUGUI OverallScore;
    public TextRenderer TextRenderer;
    public Animator Animator;
    public Medals Medals;
    public Image Medal;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RenderSummary(int perfectCount, int goodCount, int okayCount, int missCount, int bestCombo, int overallScore, Medal medal, Difficulty difficulty)
    {
        PerfectScore.text = "x "+ perfectCount;
        GoodScore.text = "x "+ goodCount;
        OkayScore.text = "x "+ okayCount;
        ComboScore.text = ""+ bestCombo;
        OverallScore.text = ""+ overallScore;
        RenderMedal(medal, difficulty);
        Animator.SetTrigger("open");
    }

    private void RenderMedal(Medal medal, Difficulty difficulty)
    {
        Medal.gameObject.SetActive(true);
        switch (medal)
        {
            case global::Medal.NONE:
                Medal.gameObject.SetActive(false);
                break;
            case global::Medal.PLATINUM:
                PlatMedal(difficulty);
                break;
            case global::Medal.GOLD:
                GoldMedal(difficulty);
                break;
            case global::Medal.SILVER:
                SilverMedal(difficulty);
                break;
            case global::Medal.BRONZE:
                BronzeMedal(difficulty);
                break;
        }
    }

    private void GoldMedal(Difficulty difficulty)
    {
        switch (difficulty)
        {
            case Difficulty.EASY:
                Medal.sprite = Medals.GoldEasyMedal;
                break;
            case Difficulty.NORMAL:
                Medal.sprite = Medals.GoldNormalMedal;
                break;
            case Difficulty.HARD:
                Medal.sprite = Medals.GoldHardMedal;
                break;
        }
    }


    private void PlatMedal(Difficulty difficulty)
    {
        switch (difficulty)
        {
            case Difficulty.EASY:
                Medal.sprite = Medals.PlatEasyMedal;
                break;
            case Difficulty.NORMAL:
                Medal.sprite = Medals.PlatNormalMedal;
                break;
            case Difficulty.HARD:
                Medal.sprite = Medals.PlatHardMedal;
                break;
        }
    }

    private void SilverMedal(Difficulty difficulty)
    {
        switch (difficulty)
        {
            case Difficulty.EASY:
                Medal.sprite = Medals.SilverEasyMedal;
                break;
            case Difficulty.NORMAL:
                Medal.sprite = Medals.SilverNormalMedal;
                break;
            case Difficulty.HARD:
                Medal.sprite = Medals.SilverHardMedal;
                break;
        }
    }
    private void BronzeMedal(Difficulty difficulty)
    {
        switch (difficulty)
        {
            case Difficulty.EASY:
                Medal.sprite = Medals.BronzeEasyMedal;
                break;
            case Difficulty.NORMAL:
                Medal.sprite = Medals.BronzeNormalMedal;
                break;
            case Difficulty.HARD:
                Medal.sprite = Medals.BronzeHardMedal;
                break;
        }
    }
}