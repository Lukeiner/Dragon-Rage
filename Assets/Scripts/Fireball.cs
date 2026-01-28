using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float velocidad = 10f;
    public float tiempoDeVida = 3f;
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.right * velocidad;
        Destroy(gameObject, tiempoDeVida);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            GameManager.instance.enemyKilled();
            Debug.Log("Enemigo abatido!");
        }
    }
}
