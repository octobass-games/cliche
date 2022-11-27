using System.Collections;
using UnityEngine;

public class FrameRenderer : MonoBehaviour
{
    public string LevelId;
    public LevelManager LevelManager;
    public MedalRenderer MedalRenderer;
    public SpriteRenderer Pic;

    void Start()
    {
        var level = LevelManager.FindLevel(LevelId);
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