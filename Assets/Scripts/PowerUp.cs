using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
	public PowerUpEffect powerupEffect;

	void OnTriggerEnter(Collider other)
	{
		Destroy(gameObject);
		powerupEffect.Apply(other.gameObject);

	}
}
