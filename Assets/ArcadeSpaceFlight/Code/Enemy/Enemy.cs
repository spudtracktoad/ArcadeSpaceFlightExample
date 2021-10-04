using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Transform[] waypoint;

    private int current;

    // Update is called once per frame
    void Update()
    {
        if (transform.position != waypoint[current].position)
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, waypoint[current].position, 5);
            GetComponent<Rigidbody>().MovePosition(pos);
        } else current = (current + 1) % waypoint.Length;
    }
}
