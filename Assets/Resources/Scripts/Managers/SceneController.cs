using System;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public void ChangeScene(string sceneId) => GameManager.Instance.ChangeScene(sceneId);

    public void CompleteLevel() => GameManager.Instance.CompleteLevel();

    public void ReplayLevel(string stringifiedDifficulty) {
        Difficulty difficulty = (Difficulty) Enum.Parse(typeof(Difficulty), stringifiedDifficulty);
        GameManager.Instance.ReplayLevel(difficulty);
    }
}
