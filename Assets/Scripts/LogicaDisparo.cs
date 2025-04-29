using System.Collections;
using UnityEngine;

public class LogicaDisparo : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab de la bala
    public GameObject[] bulletList;
    [SerializeField]private int bulletIndex = 0; // Índice de la bala actual
    [SerializeField]private int cargador = 10;
    public Transform firePoint; // Punto de disparo
    public float bulletSpeed = 20f; // Velocidad de la bala

    [SerializeField]private float tiempoEspera = 2f; // Tiempo de espera para desactivar la bala

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bulletList = new GameObject[cargador]; // Inicializar la lista de balas
        for(int i = 0; i < cargador; i++)
        {
            bulletList[i] = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bulletList[i].SetActive(false); // Desactivar la bala al inicio
        }
    }

    // Update is called once per frame
    void Update()
    {
        Disparar();

        if (Input.GetKeyDown(KeyCode.R)) // Si se presiona la tecla R, recargar
        {
            Recargar();
        }
    }

    private void Disparar()
    {
        if (Input.GetButtonDown("Fire1") && bulletList[bulletIndex].activeSelf == false)
        {
            bulletList[bulletIndex].SetActive(true); // Activar la bala
            bulletList[bulletIndex].transform.position = firePoint.position; // Posicionar la bala en el punto de disparo
            bulletList[bulletIndex].transform.rotation = firePoint.rotation; // Rotar la bala al disparar

            Rigidbody2D rb = bulletList[bulletIndex].GetComponent<Rigidbody2D>();
            rb.linearVelocity = firePoint.up * bulletSpeed; // Aplicar velocidad a la bala

            bulletIndex = (bulletIndex + 1) % cargador; // Cambiar al siguiente índice de bala

            StartCoroutine(DesactivarBala(tiempoEspera, bulletList[bulletIndex])); // Desactivar la bala después de 2 segundos
        }
    }

    private void Recargar()
    {
        for (int i = 0; i < cargador; i++)
        {
            bulletList[i].SetActive(false); // Desactivar todas las balas
        }
        bulletIndex = 0; // Reiniciar el índice de la bala
    }


    IEnumerator DesactivarBala(float tiempoEspera, GameObject bala)
    {
        yield return new WaitForSeconds(tiempoEspera); // Esperar el tiempo especificado
        bala.SetActive(false); // Desactivar la bala después de esperar
        bala.transform.position = firePoint.position; // Reiniciar la posición de la bala
        bala.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero; // Reiniciar la velocidad de la bala
    }

}
