using UnityEngine;

public class SummaryPanel : MonoBehaviour
{
    public TMPro.TextMeshProUGUI PerfectScore;
    public TMPro.TextMeshProUGUI GoodScore;
    public TMPro.TextMeshProUGUI OkayScore;
    public TMPro.TextMeshProUGUI ComboScore;
    public TMPro.TextMeshProUGUI OverallScore;
    public TextRenderer TextRenderer;
    public Animator Animator;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RenderSummary(int perfectTimes, int goodTimes, int okayTimes, int bestCombo, int overallScore)
    {
        PerfectScore.text = "x "+ perfectTimes;
        GoodScore.text = "x "+ goodTimes;
        OkayScore.text = "x "+ okayTimes;
        ComboScore.text = ""+ bestCombo;
        OverallScore.text = ""+ overallScore;
        Animator.SetTrigger("open");
    }
}