using UnityEngine;
using System.Collections;
using System;

public class EnemyEnviromentController : MonoBehaviour, IDamagable {

    public float maxHealth = 10.0f;
    public float damage = 1.0f;
    public float pushPower = 2.0f;

    private float health;
    private Collider _collider;
    private EnemyController _controller;

    // Use this for initialization
    void Start () {
        health = maxHealth;
        _collider = GetComponent<Collider>();
        _controller = GetComponent<EnemyController>();
	}
	
	void OnCollisionEnter(Collision coll) {
        if (coll.transform.CompareTag("Player") && !_controller.rigidbody.isKinematic) {
            PlayerManager.life.ReceiveDamage(damage, _collider);
            PushPlayerBack();
        }
    }

    public void Die() {
        Destroy(this.gameObject);
    }

    public void ReceiveDamage(float damageDone, Collider fromWho) {
        health -= damageDone;
    }

    private void PushPlayerBack() {
        PlayerManager.movement.PushedTo(_controller.rigidbody.velocity.normalized * -pushPower);
        _controller.Rotate();
    }
}
