using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name){
		Debug.Log ("Level load requested for: " + name);
		Application.LoadLevel (name);
		Brick.breakableCount = 0;
	}
	public void QuitRequest(string name){
		Debug.Log ("I want to quit!");
		Application.Quit ();
	}
	public void LoadNextLevel() {
		Application.LoadLevel (Application.loadedLevel + 1);
		Brick.breakableCount = 0;
	}
	public void BricksDestroyed (){
		if (Brick.breakableCount <= 0){
			LoadNextLevel();

		}
	}

}
