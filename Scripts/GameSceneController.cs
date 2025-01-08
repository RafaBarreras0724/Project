using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneController : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    public Vector3[] spawnPositions;

    void Start()
    {
        int selectedCharacterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0); // Obtener índice del personaje seleccionado
        InstantiateCharacter(selectedCharacterIndex);
    }

    void InstantiateCharacter(int characterIndex)
    {
        Vector3 spawnPosition = spawnPositions[characterIndex];
        Instantiate(characterPrefabs[characterIndex], spawnPosition, Quaternion.identity);
    }
}
