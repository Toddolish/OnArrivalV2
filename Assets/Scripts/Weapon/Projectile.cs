﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
	public float speed;
	Rigidbody rb;
	CapsuleCollider CapCollider;
	bool flying = true;
	float depth = 0.30f;
	Camera cam;
	private Transform anchor;

    //Destroy 
    float destroyTimer;
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		CapCollider = GetComponent<CapsuleCollider>();
		cam = GameObject.Find("Main Camera").GetComponent<Camera>();
	}

	void FixedUpdate()
	{
		if (flying)
		{
			rb.AddRelativeForce(Vector3.forward * speed * Time.deltaTime, ForceMode.Impulse);
		}
		else
		{
			rb.velocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;
		}
		if (this.anchor != null)
		{
			this.transform.position = anchor.transform.position;
			this.transform.rotation = anchor.transform.rotation;
		}
        #region Destroy
        destroyTimer += Time.deltaTime;

        if (destroyTimer > 10)
        {
            Destroy(gameObject);
        }
        #endregion
    }
    private void OnCollisionEnter(Collision collision)
	{
		transform.position = collision.contacts[0].point;
		Enemy enemyScript = collision.gameObject.GetComponent<Enemy>();
		Rigidbody enemyRigid = collision.gameObject.GetComponent<Rigidbody>();
		Transform enemyTransform = collision.gameObject.GetComponent<Transform>();
		CapsuleCollider enemyCollider = collision.gameObject.GetComponent<CapsuleCollider>();

		if (collision.gameObject.tag == "noHit")
		{
			//Physics.IgnoreCollision(this.collider, collision);
		}

		// Stick into objects
		if (collision.gameObject.tag == "Trees" || collision.gameObject.tag == "spikePlant")
		{
			// Create a anchor point for arrow to follow
			GameObject anchor = new GameObject("Javalin_Anchor");
			anchor.transform.position = this.transform.position;
			anchor.transform.rotation = this.transform.rotation;
			// Parent the anchor point to the crab holder (0) which has the animation
			anchor.transform.parent = collision.transform;
			speed = 0;
			this.anchor = anchor.transform;
			rb.isKinematic = true;
			this.transform.GetComponent<CapsuleCollider>().isTrigger = true;
			rb.constraints = RigidbodyConstraints.FreezeAll;
			flying = false;
		}
		//enemyRigid.AddForce(transform.forward * enemyScript.burstForce, ForceMode.Impulse);
		if (collision.gameObject.tag == "Crab" || collision.gameObject.tag == "SpikeJaw" || collision.gameObject.tag == "Shelka")
		{
			// Create a anchor point for arrow to follow
			GameObject anchor = new GameObject("Javalin_Anchor");
			anchor.transform.position = this.transform.position;
			anchor.transform.rotation = this.transform.rotation;
			// Parent the anchor point to the crap hold (0) which has the animation
			anchor.transform.parent = collision.transform;
			this.anchor = anchor.transform;
			rb.isKinematic = true;
			this.transform.GetComponent<CapsuleCollider>().isTrigger = true;
			rb.constraints = RigidbodyConstraints.FreezeAll;
			flying = false;
			speed = 0;
		}
	}
}
