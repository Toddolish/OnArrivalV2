using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wisp : MonoBehaviour
{
    public float speed;
    public Transform[] waypoints;
    public int waypointIndex;
    public Transform target;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        SelectedTarget(waypointIndex);
        // Test Key
        if (Input.GetKeyDown(KeyCode.Q))
        {
            waypointIndex++;
        }

        transform.position = Vector3.MoveTowards(transform.position, target.position, speed);
    }
    public void SelectedTarget(int targetIndex)
    {
        for (int i = 0; i < waypoints.Length; i++)
        {
            if (i == targetIndex)
            {
                target = waypoints[i];
            }
        }
    }
}
