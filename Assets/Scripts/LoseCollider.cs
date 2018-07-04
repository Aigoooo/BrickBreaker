using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	private LevelManager levelManager;

	void OnTriggerEnter2D (Collider2D Trigger) {
		levelManager = Object.FindObjectOfType<LevelManager>();
		print ("Trigger");
		levelManager.LoadLevel ("Lose");
	}
	void OnCollisionEnter2D (Collision2D Coliision) {
		print ("Coliision");
	}
}
