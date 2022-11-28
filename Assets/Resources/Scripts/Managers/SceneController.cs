using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public void CompleteLevel(string levelId) => GameManager.Instance.CompleteLevel(levelId);
}
