using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public float dmg;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemigo"))
        {
            collision.GetComponent<LogicaEnemigos>().hp -= dmg;
            Debug.Log("Se aplico el daño");
        }
    }
}
