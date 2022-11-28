using System.Collections;
using UnityEngine;

public class FrameRenderer : MonoBehaviour
{
    public string LevelId;
    public MedalRenderer MedalRenderer;
    public SpriteRenderer Pic;

    void Start()
    {
        var level = GameManager.Instance.LevelManager.FindLevel(LevelId);
        MedalRenderer.Render(level);

        if (level.State == LevelState.LOCKED)
        {
            Pic.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}