using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    public Transform Target;
    public float Speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // To get a vector that points from A to B we take the position of B and subtract the position of A
        Vector3 directionToTarget = Target.position - transform.position;

        // move towards the target
        transform.position += directionToTarget.normalized * Speed * Time.deltaTime;
    }
}
