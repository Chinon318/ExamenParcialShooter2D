using UnityEngine;

public class SpawnEnemigos : MonoBehaviour
{
    public GameObject prefabEnemigo; 
    public float tiempoEntreSpawns = 2f; 
    public Transform[] puntosDeSpawn; 


    // Update is called once per frame
    void Update()
    {
        if (Time.time % tiempoEntreSpawns < Time.deltaTime && !GameManager.Instance.gameOver)
        {
            SpawnEnemigo();
        }
    }

    void SpawnEnemigo()
    {
        // Selecciona un punto de spawn aleatorio
        int indiceAleatorio = Random.Range(0, puntosDeSpawn.Length);
        Transform puntoDeSpawn = puntosDeSpawn[indiceAleatorio];

        Instantiate(prefabEnemigo, puntoDeSpawn.position, puntoDeSpawn.rotation);
    }
}
