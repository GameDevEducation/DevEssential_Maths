using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorDemo : MonoBehaviour
{
    // public Vector3 DebugLineVector = Vector3.up;
    // public float DebugLineMagnitude = 1f;

    public Vector3 MovementDirection = Vector3.up;
    public float MovementDistance = 1f;

    // Start is called before the first frame update
    void Start()
    {
        // store previous location
        Vector3 previousPosition = transform.position;

        // move the object
        transform.position += MovementDirection.normalized * MovementDistance;

        // calculate how far we actually moved
        float distanceMoved = Vector3.Distance(previousPosition, transform.position);

        Debug.Log("Movement Direction Magnitude is " + MovementDirection.magnitude);
        Debug.Log("Expected to move " + MovementDistance + " actually moved " + distanceMoved);
    }

    // Update is called once per frame
    void Update()
    {
        // // draw the debug line vector
        // Debug.DrawLine(transform.position, transform.position + DebugLineVector * DebugLineMagnitude, Color.magenta);
    }
}
