using TMPro;
using UnityEngine;

public class TimerJuego : MonoBehaviour
{
    [SerializeField]private float timer = 60f;
    //public bool gameOver;


    public TMP_Text txt_Timer;

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime; 

        if (timer <= 0)
        {
            timer = 0;
            GameManager.Instance.gameOver = true; // Cambiar a la escena de Game Over o reiniciar el juego
            Debug.Log("¡Tiempo agotado!");
        }
        else
        {
            GameManager.Instance.gameOver = false; // El juego no ha terminado
        }

        txt_Timer.text = timer.ToString("F0"); // Mostrar el tiempo restante en el UI
    }
}
