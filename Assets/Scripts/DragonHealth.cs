using UnityEngine;

public class DragonHealth : MonoBehaviour
{
    public int healthMax = 3;
    private int healthActual;

    void Awake()
    {
        healthActual = healthMax;
       // GameManager.instance.updateUILife(healthMax);
    }

    public int getActualHealth()
    {
        return healthActual;
    }

    public void getDamage (int dam)
    {
        if (healthActual > 1)
        {
            healthActual -= dam;
            Debug.Log("Salud del Dragon: " + healthActual);
        }
        else
        {
            Morir();
        }
    }
    void Morir()
        {
            Debug.Log("El dragon ha caido");
            GameManager.instance.EndGame();
            Destroy(gameObject);
        }


}