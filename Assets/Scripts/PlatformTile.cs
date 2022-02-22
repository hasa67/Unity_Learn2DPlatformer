using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTile : MonoBehaviour {

	public Sprite[] platformTiles;
	public LayerMask layerMask;
	public SpriteRenderer shadowSR;

	[Header("Ray Points")]
	public Transform rayTL;
	public Transform rayT;
	public Transform rayTR;
	public Transform rayL;
	public Transform rayR;
	public Transform rayBL;
	public Transform rayB;
	public Transform rayBR;

	[Header("Shadows")]
	public Sprite shadowTL;
	public Sprite shadowT;
	public Sprite shadowTR;
	public Sprite shadowL;
	public Sprite shadowR;
	public Sprite shadowBL;
	public Sprite shadowB;
	public Sprite shadowBR;
	public Sprite shadowCBR;
	public Sprite shadowCBL;
	public Sprite shadowCTR;
	public Sprite shadowCTL;
	public Sprite shadowM;

	private bool rayDebugger = false;
	private float rayDistance = 0.1f;
	private float rayTimer = 3f;
	private Color rayColor = Color.white;

	void Start () {
		GetComponent<SpriteRenderer> ().sprite = platformTiles [Random.Range (0, platformTiles.Length)];

		RaycastHit2D hitTL = Physics2D.Raycast (rayTL.position, new Vector2 (-1, 1), rayDistance, layerMask);
		RaycastHit2D hitT = Physics2D.Raycast (rayT.position, new Vector2 (0, 1), rayDistance, layerMask);
		RaycastHit2D hitTR = Physics2D.Raycast (rayTR.position, new Vector2 (1, 1), rayDistance, layerMask);
		RaycastHit2D hitL = Physics2D.Raycast (rayL.position, new Vector2 (-1, 0), rayDistance, layerMask);
		RaycastHit2D hitR = Physics2D.Raycast (rayR.position, new Vector2 (1, 0), rayDistance, layerMask);
		RaycastHit2D hitBL = Physics2D.Raycast (rayBL.position, new Vector2 (-1, -1), rayDistance, layerMask);
		RaycastHit2D hitB = Physics2D.Raycast (rayB.position, new Vector2 (0, -1), rayDistance, layerMask);
		RaycastHit2D hitBR = Physics2D.Raycast (rayBR.position, new Vector2 (1, -1), rayDistance, layerMask);

		if (!hitT && hitR && hitB && hitL) {
			shadowSR.sprite = shadowT;
		} else if (hitT && hitR && !hitB && hitL) {
			shadowSR.sprite = shadowB;
		} else if (hitT && !hitR && hitB && hitL) {
			shadowSR.sprite = shadowR;
		} else if (hitT && hitR && hitB && !hitL) {
			shadowSR.sprite = shadowL;
		} else if (!hitT && !hitR && hitB && hitL) {
			shadowSR.sprite = shadowTR;
		} else if (!hitT && hitR && hitB && !hitL) {
			shadowSR.sprite = shadowTL;
		} else if (hitT && !hitR && !hitB && hitL) {
			shadowSR.sprite = shadowBR;
		} else if (hitT && hitR && !hitB && !hitL) {
			shadowSR.sprite = shadowBL;
		} else if (!hitTR) {
			shadowSR.sprite = shadowCTR;
		} else if (!hitTL) {
			shadowSR.sprite = shadowCTL;
		} else if (!hitBR) {
			shadowSR.sprite = shadowCBR;
		} else if (!hitBL) {
			shadowSR.sprite = shadowCBL;
		} else {
			shadowSR.sprite = shadowM;
		}


		if (rayDebugger) {
			DrawRays ();
		}

	}

	private void DrawRays(){
		Debug.DrawRay (rayTL.position, new Vector2 (-1, 1) * rayDistance, rayColor, rayTimer);
		Debug.DrawRay (rayT.position, new Vector2 (0, 1) * rayDistance, rayColor, rayTimer);
		Debug.DrawRay (rayTR.position, new Vector2 (1, 1) * rayDistance, rayColor, rayTimer);
		Debug.DrawRay (rayL.position, new Vector2 (-1, 0) * rayDistance, rayColor, rayTimer);
		Debug.DrawRay (rayR.position, new Vector2 (1, 0) * rayDistance, rayColor, rayTimer);
		Debug.DrawRay (rayBL.position, new Vector2 (-1, -1) * rayDistance, rayColor, rayTimer);
		Debug.DrawRay (rayB.position, new Vector2 (0, -1) * rayDistance, rayColor, rayTimer);
		Debug.DrawRay (rayBR.position, new Vector2 (1, -1) * rayDistance, rayColor, rayTimer);
	}
}
