using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    [SerializeField, Min(0)] protected int health;
    public void TakeDamage(int value)
    {
        health -= value;
        if(health <= 0)
        {
            Die();
        }
    }
    protected virtual void Die() { }
}
