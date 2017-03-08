using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour {

	// Use this for initialization
	public void exit(){
		Application.Quit ();
	}

	public void loadScene(string s){
		SceneManager.LoadScene (s);
	}
}
