using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	// Use this for initialization
	public bool autoPlay = false;
    public float speed = 12.0f;
    private float padding = -0.5f;
    private Ball ball;
    private float xmax;
    private float xmin;


    void Start () {
        float distanceToCamera = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftBoundary = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceToCamera));
        Vector3 rightBoundary = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanceToCamera));
        xmax = rightBoundary.x + padding;
        xmin = leftBoundary.x - padding;
        ball = GameObject.FindObjectOfType<Ball>();
	}

	// Update is called once per frame
	void Update () {
		if (!autoPlay) {
            MoveWithMouse ();
          //  MoveWithKeys();
		} else {
			AutoPlay();
		}
	}

	void MoveWithMouse () {
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		float mousePosInBlocks = (Input.mousePosition.x / Screen.width * 16);
		paddlePos.x = (Mathf.Clamp(mousePosInBlocks, 0.5f, 15.5f));
		this.transform.position = paddlePos; //SCRIPT OF THE OBJECT
	}
	void AutoPlay() {
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		Vector3 ballPos = ball.transform.position;
		paddlePos.x = (Mathf.Clamp(ballPos.x, 0.5f, 15.5f));
		this.transform.position = paddlePos; //SCRIPT OF THE OBJECT

	}
    //void MoveWithKeys() {
      //  if (Input.GetKey(KeyCode.LeftArrow))
        //{
            // transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
          //  transform.position += Vector3.left * speed * Time.deltaTime;
       // }
       // else if (Input.GetKey(KeyCode.RightArrow))
       // {
            // transform.position += new Vector3(+speed * Time.deltaTime, 0, 0);
        //    transform.position += Vector3.right * speed * Time.deltaTime;
       // }
        // Restrict player to the game space
        //float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
       // transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    //}
}


