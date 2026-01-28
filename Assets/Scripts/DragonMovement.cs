using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DragonMovement : MonoBehaviour
{
    public float velocidad = 7f;
    private Rigidbody2D rb;
    private Vector2 inputs;
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;
    public GameObject fireballPrefab;
    public Transform puntoDeDisparo;
    DragonHealth salud;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer> ().bounds.size.x/2;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y/2;
        salud = GetComponent<DragonHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        inputs.x = Input.GetAxisRaw("Horizontal");
        inputs.y = Input.GetAxisRaw("Vertical");
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        Vector2 direccion = (mousePos - transform.position).normalized;

        float angulo = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angulo - 90);

        if (Input.GetButtonDown("Fire1"))
        {
            Disparar();
        }

    }

    void Disparar ()
    {
        Instantiate(fireballPrefab, puntoDeDisparo.position, puntoDeDisparo.rotation);
    }

    private void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + objectHeight, screenBounds.y  - objectHeight);
        transform.position = viewPos;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + inputs.normalized * velocidad * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameManager.instance.LoseLifes();
            if (salud.getActualHealth() > 1)
            { 
                salud.getDamage(1);
                Destroy(collision.gameObject);
            }
            else
            {
                salud.getDamage(1);
                Debug.Log("Aquí tienes inmunda bestia");
                Destroy(gameObject);
            }
        }
    }

}
