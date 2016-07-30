using System.Collections;
using UnityEngine;

interface IDamagable {
    void ReceiveDamage(float damageDone, Collider fromWho);
    void Die();
}
