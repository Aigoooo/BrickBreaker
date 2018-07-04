using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	private Paddle paddle;
	private bool hasStarted = false;
	private Vector3 paddleToBallVector;
    private Vector2 addedForce;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
        addedForce = new Vector2 (0.02f, 0.0f);

	}
	
	// Update is called once per frame
	void Update () {
		if (!hasStarted) {
			this.transform.position = paddle.transform.position + paddleToBallVector;

			if (Input.GetMouseButtonDown (0)) {
				print ("Mouse clicked, launch ball");
				hasStarted = true;
				this.GetComponent<Rigidbody2D>().velocity = new Vector2 (2.4f, 12f);
                this.GetComponent<Rigidbody2D>().AddForce(addedForce, ForceMode2D.Force);
                this.GetComponent<Rigidbody2D>().AddTorque(0.6f, ForceMode2D.Impulse);
			}
		}
	}

	void OnCollisionEnter2D (Collision2D collision){
		Vector2 tweak = new Vector2 (Random.Range (0f, 0.2f), Random.Range (0f, 0.2f));


		if (hasStarted) {
			GetComponent<AudioSource>().Play ();
			GetComponent<Rigidbody2D>().velocity += tweak;
		}
	}
}
