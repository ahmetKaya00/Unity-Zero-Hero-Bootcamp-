using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharakterLoader : MonoBehaviour
{
    [SerializeField] private GameObject Player1, Player2;

    private void Start()
    {
        string selectedCharacter = PlayerPrefs.GetString("SelectedCharacter", "");

        GameObject characterToInstantiate = null;

        switch (selectedCharacter)
        {
            case "Cube":
                characterToInstantiate = Player1;
                break;
            case "Sphere":
                characterToInstantiate = Player2;
                break;
            default:
                Debug.LogError("Character Not Found!");
                break;
        }

        if(characterToInstantiate != null)
        {
            Instantiate(characterToInstantiate, Vector3.zero, Quaternion.identity);
        }
    }
}
