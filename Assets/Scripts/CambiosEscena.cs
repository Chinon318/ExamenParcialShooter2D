using UnityEngine;
using UnityEngine.SceneManagement;
public class CambiosEscena : MonoBehaviour
{
    public void CambiarEscena(string nombreEscena)
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.gameOver = false;
            GameManager.Instance.playerScore = 0; // Reinicia el puntaje del jugador al cambiar de escena
        }
        SceneManager.LoadScene(nombreEscena); // Cambia a la escena especificada
    }
}
