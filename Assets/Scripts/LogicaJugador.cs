using UnityEngine;

public class LogicaJugador : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]private float speed;

    public float hp = 50f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Cursor.visible = false; // Ocultar el cursor del ratón
        Cursor.lockState = CursorLockMode.Confined; // Bloquear el cursor dentro de la ventana del juego


        #if UNITY_EDITOR
        Cursor.visible = true; // Mostrar el cursor en el editor
        #endif
    }

    void Update()
    {
        if (hp <= 0)
        {
            GameManager.Instance.playerScore += 0; 
            GameManager.Instance.gameOver = true;
        }
    }

    void FixedUpdate()
    {
        if (!GameManager.Instance.gameOver)
        {
            Movimiento();
        }
    }

    private void Movimiento()
    {
        float horMovement = Input.GetAxis("Horizontal");
        float verMovement = Input.GetAxis("Vertical");

        if (horMovement != 0 || verMovement != 0)
        {
            Vector2 movement = new Vector2(horMovement, verMovement).normalized * speed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + movement);
        }

        Vector3 mousePos = Input.mousePosition;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

        rb.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(worldPos.y - rb.position.y, worldPos.x - rb.position.x) * Mathf.Rad2Deg - 90f);
    }
}
