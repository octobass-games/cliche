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

    public void RenderSummary(int perfectCount, int goodCount, int okayCount, int missCount, int bestCombo, int overallScore)
    {
        PerfectScore.text = "x "+ perfectCount;
        GoodScore.text = "x "+ goodCount;
        OkayScore.text = "x "+ okayCount;
        ComboScore.text = ""+ bestCombo;
        OverallScore.text = ""+ overallScore;
        Animator.SetTrigger("open");
    }
}