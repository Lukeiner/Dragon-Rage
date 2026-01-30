using UnityEngine;

public class DragonHealth : MonoBehaviour
{
    public static DragonHealth instance;
    public int healthMax = 3;
    private int healthActual;

    void Awake()
    {
        if (instance == null)
        {
            instance = this; 
            healthActual = healthMax;
        }
        else
        {
            Destroy(gameObject); 
        }
        
    }

    public int getMaxHealth()
    {
        return healthMax;
    }

    public int getActualHealth()
    {
        return healthActual;
    }

    public void getDamage (int dam)
    {
       
         healthActual -= dam;

         if (healthActual < 0) healthActual = 0;

         Debug.Log("Salud del Dragon: " + healthActual);

        if (healthActual <= 0)
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