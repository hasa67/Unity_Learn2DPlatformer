using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour {

	private Transform player;
	private Vector3 newPosition;
	private Vector3 newRotation;
	private bool isShaking = false;
	private float Shaketime = 0.2f;
	private float dS = 0.5f;
	private float dA = 1f;


	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
		newPosition = new Vector3 ();
	}

	void Update () {
		newPosition.x = player.position.x;
		newPosition.y = player.position.y;
		newPosition.z = this.transform.position.z;
		this.transform.position = newPosition;
		newRotation = new Vector3 (0, 0, 0);
		this.transform.rotation = Quaternion.Euler (newRotation);

		if (isShaking) {
			float dX = Random.Range (-dS, dS);
			float dY = Random.Range (-dS, dS);
			Vector3 newCamPosition = this.transform.position + new Vector3 (dX, dY, 0);

			float dZA = Random.Range (-dA, dA);
			Vector3 newCamRotation = this.transform.rotation.eulerAngles + new Vector3 (0, 0, dZA);

			this.transform.position = newCamPosition;
			this.transform.rotation = Quaternion.Euler (newCamRotation);
		}
	}

	public void Shake(){
		StartCoroutine (ShakeCo ());
	}

	IEnumerator ShakeCo(){
		isShaking = true;
		yield return new WaitForSeconds (Shaketime);
		isShaking = false;
	}
}
