using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    public void SelectCharacter(int characterIndex)
    {
        PlayerPrefs.SetInt("SelectedCharacter", characterIndex); // Guardar índice del personaje seleccionado
        SceneManager.LoadScene("GameScene"); // Cambia "GameScene" por el nombre de tu escena del juego
    }
}
