using UnityEngine;
using System.Collections;
using System;

public class EnemyEnviromentController : MonoBehaviour, IDamagable {

    public float maxHealth = 10.0f;
    public float damage = 1.0f;
    private float health;

    public void Die() {
        Destroy(this.gameObject);
    }

    public void ReceiveDamage(float damageDone) {
        health -= damageDone;
    }

    // Use this for initialization
    void Start () {
        health = maxHealth;
	}
	
	void OnCollisionEnter(Collision coll) {
        if (coll.transform.CompareTag("Player")) {
            PlayerManager.life.ReceiveDamage(damage);
        }
    }
}
