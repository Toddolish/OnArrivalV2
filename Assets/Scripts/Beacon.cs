using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Beacon : MonoBehaviour
{
    [Header("Beacon Variables")]
    public PlayerMovment playerMove;
    public Text placeText;
    public GameObject beacon1, beacon2, beacon4;
    public int beaconCount;
    Renderer rend;
    Material unlitMat;
    public Material litBeam;
	public bool cannotPlace;
	public float placeTimer;
    void Start()
    {
        playerMove = GameObject.Find("Player").GetComponent<PlayerMovment>();
		rend = GetComponent<Renderer>();
		unlitMat = rend.materials[2];
	}
    void Update()
    {
        if (beaconCount == 1)
        {
            beacon1.gameObject.SetActive(true);
        }
        if(beaconCount == 2)
        {
            beacon2.gameObject.SetActive(true);
        }
        if (beaconCount == 3)
        {
            beacon4.gameObject.SetActive(true);
			// change material
			unlitMat.mainTexture = litBeam.mainTexture;
		}
		if (cannotPlace)
		{
			placeTimer += Time.deltaTime;
			if (placeTimer > 0.5f)
			{
				cannotPlace = false;
				placeTimer = 0;
			}
		}
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
			if (!cannotPlace)
			{
				if (playerMove.beaconIndex >= 1)
				{
					// Show place beacon Text
					placeText.enabled = true;
					if (Input.GetKeyDown(KeyCode.E))
					{
						cannotPlace = true;
						FindObjectOfType<AudioManager>().Play("Place");
						// when (E) is pressed place a beacon
						// Player beaconIndex = -1
						playerMove.beaconIndex--;
						beaconCount++;
					}
				}
				else
				{
					placeText.enabled = false;
				}
			}
        }
    }
}
