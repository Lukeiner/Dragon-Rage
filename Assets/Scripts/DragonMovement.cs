using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DragonMovement : MonoBehaviour
{
    public float velocidad = 7f;
    private float objectWidth;
    private float objectHeight;
    private bool eggAppear = false;
    private Vector2 finalPoint = new Vector2(0, -6f);
    private Vector2 inputs;
    private Vector2 screenBounds;
    private Rigidbody2D rb;
    public GameObject fireballPrefab;
    public Transform puntoDeDisparo;
    private HUD hud;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer> ().bounds.size.x/2;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y/2;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gameFinished)  return;

        if (GameManager.instance.firstLevelWon())
        {
            transform.position = Vector2.MoveTowards(transform.position, finalPoint, 3f * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), 5f * Time.deltaTime);

            if (Vector2.Distance(transform.position, finalPoint) < 0.1f && !eggAppear)
            {
                eggAppear = true;
                GameManager.instance.appearEgg();
            }
            return;
        }
    
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
        if (!GameManager.instance.firstLevelWon())
        {
            Vector3 viewPos = transform.position;
            viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
            viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);
            transform.position = viewPos;
        }
    }

    void FixedUpdate()
    {
        if (GameManager.instance.firstLevelWon()) return;

        rb.MovePosition(rb.position + inputs.normalized * velocidad * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameManager.instance.LoseLifes();
            Destroy(collision.gameObject);
        }
    }

    public void startReturn()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }

        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}