﻿using UnityEngine;
using System.Collections;

public class PlayerLifeController : MonoBehaviour, IDamagable {
    public float maxHealth;
    public ProgressBar healthMeter;
    public float invulnarabilityTime = 2.0f;

    private bool isInvulnerable;
    private float health;

	// Use this for initialization
	void Start () {
        healthMeter.SetPercentage(1.0f); //Begin the game with full health
        health = maxHealth;
	}

    //From IDamagable
    public void ReceiveDamage(float damageDone, Collider fromWho) {
        if (isInvulnerable) return;
        StartCoroutine("ReceivingDamage", damageDone);
        healthMeter.SetPercentage(Mathf.InverseLerp(0.0f, maxHealth, health - damageDone), invulnarabilityTime * 0.5f);
        if(health <= 0.0f) {
            Die();
        }
        else {
            StartCoroutine("BecomeInvulnerable", fromWho);
        }
    }

    //From IDamagable
    public void Die() {
        print("El jugador ha muerto!");
    }

    IEnumerator BecomeInvulnerable(Collider fromWho) {
        isInvulnerable = true;
        Physics.IgnoreCollision(fromWho, PlayerManager.collider);
        yield return new WaitForSeconds(invulnarabilityTime);
        Physics.IgnoreCollision(fromWho, PlayerManager.collider, false);
        isInvulnerable = false;
    }

    IEnumerator ReceivingDamage(float damageDone) {
        float targetHealth = health - damageDone;
        float initTime = Time.time;
        while(health > targetHealth) {
            health = Mathf.Lerp(health, targetHealth, (Time.time - initTime) / invulnarabilityTime * 0.5f);
            yield return new WaitForEndOfFrame();
        }
        
    }
}
