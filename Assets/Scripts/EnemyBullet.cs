using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    public float velocidad = 8f;
    public float tiempoDeVida = 3f;
    void Start()
    {
        //Rigidbody2D rb = GetComponent<Rigidbody2D>();
        //rb.linearVelocity = transform.right * velocidad;
        //Destroy(gameObject, tiempoDeVida);
        Destroy(gameObject, tiempoDeVida);

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            Debug.Log("Le he dado!");

            if (GameManager.instance.getLifes() > 1)
            {
                GameManager.instance.LoseLifes();
            }
            else
            {
                GameManager.instance.EndGame();
            }
            
            
        }
    }
}
