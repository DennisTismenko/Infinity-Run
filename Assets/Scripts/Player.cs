using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public static float maxHp;
    public static float health;
    public static float armour;
    public static float damage;

    public delegate void tookDamage();
    public static event tookDamage playerHit;
    public static event tookDamage playerDead;


    public static bool alive;
    public static bool godMode;

    // Use this for initialization
    void Start()
    {
    }

    void OnEnable()
    {
        EventHandler.startGame += InitPlayer;
        EventHandler.startGame += InitSettings;
        EventHandler.endGame += KillSettings;
        EventHandler.endGame += KillPlayer;
        EventHandler.endGame += ClearMap;
    }

    void OnDisable()
    {
        EventHandler.startGame -= InitPlayer;
        EventHandler.startGame -= InitSettings;
        EventHandler.endGame -= KillPlayer;
        EventHandler.endGame -= KillSettings;
        EventHandler.endGame -= ClearMap;
    }

    // Update is called once per frame
    void Update()
    {
    }


    void KillPlayer()
    {
        armour = 0;
        health = 0;
        alive = false;
        this.gameObject.GetComponent<DestroyByCollisionBigExplosion>().Invoke("PlayBigExplosion", 0);
    }



    public void TakeDamage(float amount)
    {
        if (!godMode)
        {
            if (armour > 0)
            {
                armour -= amount;
                if (armour < 0)
                {
                    health += armour;
                    armour = 0;
                }
            }
            else
            {
                health -= amount;
            }
        }
        if (health <= 0 && alive)
        {
            playerDead();
        }
    }



    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.layer == 8)
        {
            TakeDamage(30);
            playerHit();
        }
    }

    void OnTriggerEnter(Collider col)
    {
        Destroy(col.gameObject);
    }


    void DisableDraw()
    {
        GameObject[] draw = GameObject.FindGameObjectsWithTag("Render");
        for (int i = 0; i < draw.Length; i++)
        {
            draw[i].gameObject.SetActive(false);
        }
    }

    public void DestroyEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].SetActive(false);
        }
    }

    void DestroyPickups()
    {
        GameObject[] pickups = GameObject.FindGameObjectsWithTag("PickUp");
        for (int i = 0; i < pickups.Length; i++)
        {
            pickups[i].SetActive(false);
        }
    }

    void InitPlayer()
    {
        alive = true;
        maxHp = 100f;
        health = maxHp;
        armour = 0;
        damage = 10;
    }

    void InitSettings()
    {
        Time.timeScale = 1.0f;
    }

    void KillSettings()
    {
        Time.timeScale = 0.1F;
    }

    void ClearMap()
    {
        DisableDraw();
        DestroyEnemies();
        DestroyPickups();
    }


}
