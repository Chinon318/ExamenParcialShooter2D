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
}
