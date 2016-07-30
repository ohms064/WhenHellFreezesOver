using UnityEngine;
using System.Collections;

public class PlayerLifeController : MonoBehaviour, IDamagable {
    public float maxHealth;
    public ProgressBar healthMeter;

    private float health;

	// Use this for initialization
	void Start () {
        healthMeter.SetPercentage(1.0f); //Begin the game with full health
        health = maxHealth;
	}

    public void ReceiveDamage(float damageDone) {
        health -= damageDone;
        healthMeter.SetPercentage(Mathf.InverseLerp(0.0f, maxHealth, health));
        if(health <= 0.0f) {
            Die();
        }
    }

    public void Die() {
        print("El jugador ha muerto!");
    }
}
