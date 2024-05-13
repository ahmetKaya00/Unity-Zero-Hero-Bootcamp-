using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreGAme : MonoBehaviour
{
    private int Score;
    private TextMeshProUGUI text;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        GameManager.OnCubeSpawned += GameManager_OnCubeSpawned;
    }

    private void OnDestroy()
    {
        GameManager.OnCubeSpawned -= GameManager_OnCubeSpawned;
    }
    private void GameManager_OnCubeSpawned()
    {
        Score++;
        text.text = "Score: " + Score;
    }
}
