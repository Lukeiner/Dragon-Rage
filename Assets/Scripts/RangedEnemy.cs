using UnityEngine;

public class RangedEnemy : MonoBehaviour
{

    public float stopDistance = 5f;
    public float fireRate = 2f;
    private float nextFireTime;
    private float velocidad = 3f;
    public float bulletSpeed = 3f;

    public GameObject bulletPreFab;
    public Transform firePoint;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;   
    }
    void Update()
    {
        if (player == null) return;

        Vector2 direccion = player.position - transform.position;
        float angulo = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angulo-90);

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance > stopDistance)
        {
            //MoveTowardPlayer();
            transform.position = Vector2.MoveTowards(transform.position, player.position, velocidad * Time.deltaTime);
        }
        else
        {
            TryShoot();
        }
    }
    void TryShoot()
    {
        if (Time.time >= nextFireTime)
            {
            GameObject bullet = Instantiate(bulletPreFab,firePoint.position,Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            Vector2 direction = (player.position - firePoint.position).normalized;
            rb.linearVelocity = direction * bulletSpeed;

            nextFireTime = Time.time + fireRate;
        }
    }
    void MoveTowardPlayer ()
    {
        Vector2 direccion = (player.position - transform.position).normalized;
        transform.Translate(direccion * velocidad * Time.deltaTime);
    }
}
