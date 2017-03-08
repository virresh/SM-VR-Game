using UnityEngine;
using System.Collections;

public class FollowCam : MonoBehaviour {
	public GameObject player;

	void LateUpdate () {
		//transform.position = player.transform.position + offset;	//debugging purpose
		//transform.rotation = player.transform.rotation;			//debugging purpose
		transform.localEulerAngles = new Vector3(transform.rotation.eulerAngles.x, player.transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
	}
}
