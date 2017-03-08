using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
	public Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1")){
			anim.Play("IdleGrab_Neutral",-1,0.0f);
		}
	}
}
