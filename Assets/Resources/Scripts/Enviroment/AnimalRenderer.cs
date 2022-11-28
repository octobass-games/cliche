using System.Collections;
using UnityEngine;

public class AnimalRenderer : MonoBehaviour
{
    public string LevelId;
    public GameObject Animal;
    // Use this for initialization
    void Start()
    {
        var level = GameManager.Instance.LevelManager.FindLevel(LevelId);
        if (level.State == LevelState.COMPLETED)
        {
            Animal.SetActive(true);
        }else
        {
            Animal.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}