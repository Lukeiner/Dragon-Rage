using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public float velocidad = 3f;
    private Transform jugador;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject jugadorObj = GameObject.FindGameObjectWithTag("Player");
        if (jugadorObj != null) jugador = jugadorObj.transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((jugador != null))
        {
            Vector2 direccion = (jugador.position - transform.position).normalized;

            transform.Translate(direccion * velocidad * Time.deltaTime);
        }
    }
}
