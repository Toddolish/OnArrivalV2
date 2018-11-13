using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFacingBillboard : MonoBehaviour {

	public Camera cam;

	// Orient the camera after all movement has passed to avoid jittering
	private void Start()
	{
		cam = Camera.main;
	}
	private void LateUpdate()
	{
		if (cam != null)
		{
			transform.LookAt(transform.position + cam.transform.rotation * Vector3.forward, cam.transform.rotation * Vector3.up);
		}
	}
}
