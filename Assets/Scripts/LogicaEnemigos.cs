using UnityEngine;

public class LogicaEnemigos : MonoBehaviour
{
    public Transform target;

    public float speed = 5f;
    public float hp = 10f;

    private Rigidbody2D rb;

    [SerializeField] private int puntajeDestruccion = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform; // Asigna el objetivo al jugador
    }


    private void FixedUpdate() 
    {
        SeguirJugador();
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            GameManager.Instance.playerScore += puntajeDestruccion;
            Destroy(gameObject);
        }
    }

    private void SeguirJugador()
    {
        Vector2 direction = target.position - transform.position;
        rb.MovePosition (rb.position + direction.normalized * speed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<LogicaJugador>().hp -= 10f;
        }
    }
}
