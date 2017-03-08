using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LaserScript : MonoBehaviour {
	private Vector3 offset;
	//public GameObject player;
	private LineRenderer line;
	public Animator anim;
	private int numDestroyed;
	public AudioClip shootSound;
	private AudioSource sourceshoot;
	public AudioClip winSound;
	private AudioSource sourcewin;
	public AudioClip backsound;
	private AudioSource sourceback;

	void Awake()
	{
		sourcewin = GetComponent<AudioSource> ();
		sourceshoot = GetComponent<AudioSource> ();
		sourceback = GetComponent<AudioSource> ();
	}
	// Use this for initialization
	void Start () {
		line = GetComponent<LineRenderer> ();
		line.enabled = false;
		//offset = transform.position - player.transform.position;
		anim = GetComponent<Animator> ();
		numDestroyed = 0;
		sourceback.PlayOneShot (backsound, 1F);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			StopCoroutine ("FireLaser");
			StartCoroutine ("FireLaser");
			sourceshoot.PlayOneShot (shootSound, 1F);


		}

		if (numDestroyed == 5) {
			SceneManager.LoadScene ("GameWon");
		}
	}

	void LateUpdate () {
		//transform.position = player.transform.position + offset;
		//transform.rotation = player.transform.rotation;
	}

	IEnumerator FireLaser()
	{
		line.enabled = true;

		//while (Input.GetButton ("Fire1")) {
			Ray ray = new Ray (transform.position, transform.forward);
			RaycastHit hit;

			line.SetPosition (0, ray.origin);

			if(Physics.Raycast(ray, out hit, 100))
			{
				line.SetPosition(1, hit.point);
				if(hit.rigidbody)	// hit an obstacle
				{
					if(hit.rigidbody.gameObject.CompareTag("Obstacle")){
						//hit.rigidbody.AddForceAtPosition(transform.forward * 10, hit.point); // was used to test the reaction of a hit on rigidbody
						hit.rigidbody.transform.parent.gameObject.SetActive(false);
						numDestroyed += 1;
					}
				}
			}
			else
				line.SetPosition(1, ray.GetPoint(100));
			yield return null;
		//}
		line.enabled = false;
	}
}
