using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

	public int Speed;

	void Update () {
		transform.Rotate (new Vector3 (0, Speed, 0) * Time.deltaTime,Space.World);
	}
}
