using UnityEngine;

public class SceneController : MonoBehaviour
{
    public void ChangeScene(string sceneId) => GameManager.Instance.ChangeScene(sceneId);

    public void CompleteLevel(string levelId) => GameManager.Instance.CompleteLevel(levelId);
}
