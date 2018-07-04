using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer instance = null;

	void Awake () {
		Debug.Log ("MusicPlayer Awake " + GetInstanceID ());
		if (instance != null) {
			Destroy (gameObject);
			print ("MUSICPLAYER DESTROYED!");
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad (gameObject);
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
