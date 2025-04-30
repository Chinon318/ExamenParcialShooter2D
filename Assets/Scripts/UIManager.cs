using UnityEngine;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public GameObject gameOverPanel; // Panel de Game Over
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOverPanel = GameObject.Find("PanelGameOver"); // Asigna el panel de Game Over
        gameOverPanel.SetActive(false); // Desactiva el panel al inicio
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.gameOver)
        {
            gameOverPanel.SetActive(true); // Activa el panel de Game Over
        }
        else
        {
            gameOverPanel.SetActive(false); // Desactiva el panel de Game Over
        }
    }


    public void CambioEscena(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena); // Cambia a la escena especificada
    }
}
