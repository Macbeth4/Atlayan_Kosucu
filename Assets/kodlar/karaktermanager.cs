using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class karaktermanager : MonoBehaviour
{

    public GameObject[] playerPrefabs;
    int characterIndex;

    private void Awake()
    {
        characterIndex = PlayerPrefs.GetInt("SelectedCharakter", 0);
        Instantiate(playerPrefabs[characterIndex]);
    }

}
