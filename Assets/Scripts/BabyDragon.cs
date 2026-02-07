using UnityEngine;

public class BabyDragon : MonoBehaviour
{
    [Header("Orbit Config")]

    public Transform mother;
    public Transform sonMouth;
    public float ratio = 2f;
    public float turnVel = 2f;

    [Header("Atack configuration")]
    public GameObject bulletPreFab;
    public float timeBetweenShots = 7f;
    public float detectionRange = 10f;

    private float angle;
    private float chronShot;

    private void FixedUpdate()
    {
        if (mother == null || GameManager.instance.gameFinished) return;

        OrbitMother();
    }

    void Update()
    {
        if (mother == null) return;

        AutoShot();
    }


    void OrbitMother()
    {
        angle += turnVel * Time.deltaTime;
        float x = mother.position.x + Mathf.Cos(angle) * ratio;
        float y = mother.position.y + Mathf.Sin(angle) * ratio;

        transform.position = new Vector2(x, y);

    }

    void AutoShot()
    {
        chronShot += Time.deltaTime;

        if (chronShot >= timeBetweenShots)
        {
            GameObject closeEnemy = SearchCloseEnemy();

            if (closeEnemy != null)
            {
                Shot(closeEnemy.transform.position);
                chronShot = 0;
            }
        }
    }

    GameObject SearchCloseEnemy ()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float minDistance = detectionRange;

        foreach (GameObject enemigo in enemies)
        {
            float distancia = Vector2.Distance(transform.position, enemigo.transform.position);
            if (distancia < minDistance)
            {
                minDistance = distancia;
                closest = enemigo;
            }
        }
        return closest;
    }

    void Shot (Vector3 objectivePos)
    {
        Vector2 direccion = (objectivePos - transform.position).normalized;
        float bulletAngle = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;

        // Instanciamos desde la "Boca" y con la rotación hacia el enemigo
        GameObject bullet = Instantiate(bulletPreFab, sonMouth.position, Quaternion.Euler(0, 0, bulletAngle));

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = direccion * 12f; // Un poquito más veloz que la del padre
        }
    }
}
