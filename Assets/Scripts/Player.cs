﻿using UnityEngine;
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

    public static bool alive;
    public static bool godMode;

    // Use this for initialization
    void Start()
    {
        alive = true;
        maxHp = 100f;
        health = maxHp;
        armour = 0;
        damage = 10;
    }

    // Update is called once per frame
    void Update()
    {
    }


    void killPlayer()
    {
        DestroyEnemies();
        DestroyPickups();
        armour = 0;
        health = 0;
        alive = false;
        DisableDraw();
        this.gameObject.GetComponent<DestroyByCollisionBigExplosion>().Invoke("PlayBigExplosion", 0);
        Time.timeScale = 0.1F;
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
            killPlayer();
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
}
