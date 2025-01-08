using UnityEngine;
using UnityEngine.UI; // Importar para trabajar con UI

public class VictoryController : MonoBehaviour
{
    public GameObject victoryMessage; // Referencia al objeto del mensaje de victoria

    void Start()
    {
        victoryMessage.SetActive(false); // Asegurarse de que el mensaje esté desactivado al inicio
    }

    // Método para detectar colisiones con un trigger
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Asegurarse de que el objeto tenga la etiqueta "Player"
        {
            victoryMessage.SetActive(true); // Activar el mensaje de victoria
            Debug.Log("¡Ganaste!"); // Mensaje de depuración
        }
    }
}
