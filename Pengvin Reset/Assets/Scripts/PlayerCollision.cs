﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    // Sets the players startposition, so we can use it to reset his position when taking damage
    Vector2 startPos;
    private float stunTime;
    int fishHeal = 0;
    private float speedBoostTime;
    float timeLeft = 30.0f;

    public GameObject explosionParticle;

    // Start is called before the first frame update
    void Start()
    {
        startPos = gameObject.transform.position;
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Obstacle")
        {
            PlayerMovement.stunned = true;
        }
        else if (collision.tag == "Fish")
        {
            Score.score++;
            fishHeal += 1;
            Destroy(collision.gameObject);
        }
        else if (collision.tag == "DeathWall")
        {
            Health.health--;
            gameObject.transform.position = startPos;
            PlayerMovement.stunned = true;
        }
        else if (collision.tag == "HealthPickup")
        {
            Health.health += 1;
            Destroy(collision.gameObject);
        }
        else if (collision.tag == "SpeedPickup")
        {
            PlayerMovement.speed = 40;
            Destroy(collision.gameObject);
            StartCoroutine(SpeedBoost());
        }
        else if (collision.tag == "SixPackTrash")
        {
            PlayerMovement.slowed = true;
        }

        else if (fishHeal == 5 && Health.health < 5)
        {
            Health.health += 1;
            fishHeal = 0;
        }
        else if (collision.tag == "NavalMine")
        {
            Health.health--;
            PlayerMovement.stunned = true;
            PlayerMovement.explosionKnockback = true;
            StartCoroutine(SpawnExplosion());
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "SixPackTrash")
        {
            PlayerMovement.slowed = false;
        }
    }

    IEnumerator SpeedBoost()
    {
        yield return new WaitForSeconds(5);
        PlayerMovement.speed = 20;
    }

    IEnumerator SpawnExplosion()
    {
        GameObject explosion = Instantiate(explosionParticle, transform.position, transform.rotation) as GameObject;
        explosion.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        Destroy(explosion.gameObject);
    }
}
