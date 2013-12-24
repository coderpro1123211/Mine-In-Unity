﻿using UnityEngine;
using System.Collections;

public class PlayerIO : MonoBehaviour {

	public static PlayerIO currentPlayerIO;
	public float maxInteractDistance = 8;
	public byte selectedInventory = 0;
	public bool resetCamera = false;
	public Vector3 campos;


	// Use this for initialization
	void Start () {
		currentPlayerIO = this;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2)){
			Ray ray = camera.ViewportPointToRay(new Vector3(0.5f,0.5f,0.5f));
			RaycastHit hit;
			if (Physics.Raycast (ray,out hit, maxInteractDistance)) {
				Chunk chunk = hit.transform.GetComponent<Chunk>();
				if (chunk == null){
					return;
				}
				
			
				if (Input.GetMouseButtonDown(0)){
				Vector3 p = hit.point;
				p -= hit.normal / 4;

				chunk.SetBrick(0, p);

				} 


		if (Input.GetMouseButtonDown (1)) {
					Vector3 p = hit.point;
				if (selectedInventory != 0){
						p += hit.normal / 4;
						chunk.SetBrick(selectedInventory,p);
				}
				
			} 

			if (Input.GetMouseButtonDown(2)) {
					Vector3 p = hit.point;
					p -= hit.normal / 4;
					selectedInventory = chunk.GetByte(p);

				} 

			}
		}
		if (Input.GetKeyDown (KeyCode.F5)) {
						if (resetCamera == false) {
								transform.localPosition -= Vector3.forward * 2;
								resetCamera = true;
						}
			else{
				transform.position = transform.parent.root.transform.localPosition + new Vector3(0f, 0.7f, 0.06f);
				transform.rotation = transform.parent.root.transform.rotation;
				resetCamera = false;
				}
	}

}
}