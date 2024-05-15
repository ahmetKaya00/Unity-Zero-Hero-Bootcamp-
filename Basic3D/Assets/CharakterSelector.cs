using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharakterSelector : MonoBehaviour
{
    public void SelectCharacter(string characterName)
    {
        PlayerPrefs.SetString("SelectedCharacter", characterName);
        PlayerPrefs.Save();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
