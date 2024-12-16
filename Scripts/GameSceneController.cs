using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneController : MonoBehaviour
{
    public GameObject[] characterPrefabs; // Array de prefabs de personajes
    public Vector3[] spawnPositions;      // Array de posiciones de aparición

    void Start()
    {
        InstantiateCharacter("Player1", 0);
        InstantiateCharacter("Player2", 1);
        InstantiateCharacter("Player3", 2);
        InstantiateCharacter("Player4", 3);
    }

    void InstantiateCharacter(string playerPrefKey, int spawnIndex)
    {
        int selectedCharacterIndex = PlayerPrefs.GetInt(playerPrefKey);
        Vector3 spawnPosition = spawnPositions[spawnIndex]; // Posición específica para cada jugador
        Instantiate(characterPrefabs[selectedCharacterIndex], spawnPosition, Quaternion.identity);
    }
}
