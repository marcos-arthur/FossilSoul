using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 4;

    public int touchDamage = 1;

	public GameObject deathEffect;

	public void TakeDamage (int damage)
	{
		health -= damage;

		if (health <= 0)
		{
			Die();
		}
	}

    public int GetTouchDamage ()
	{
		return touchDamage;
	}

	void Die ()
	{
		// Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
