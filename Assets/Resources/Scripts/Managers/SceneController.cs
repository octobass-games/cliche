using System;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public void ChangeScene(string sceneId) => GameManager.Instance.ChangeScene(sceneId);

    public void CompleteLevel(string levelId) => GameManager.Instance.CompleteLevel(levelId);

    public void ReplayLevel(string stringifiedDifficulty) {
        Difficulty difficulty = (Difficulty) Enum.Parse(typeof(Difficulty), stringifiedDifficulty);
        GameManager.Instance.ReplayLevel(difficulty);
    }
}
