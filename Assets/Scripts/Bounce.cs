using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public float BounceHeight = 0.5f;
    public float BouncePeriod = 1f;

    public float PulseFrequency = 1f;
    public float PulseMagnitude_Min = 1.25f;
    public float PulseMagnitude_Max = 1.5f;

    Vector3 InitialPosition;
    Vector3 InitialScale;

    float BounceProgress = 0f;
    float PulseProgress = 0f;

    // Start is called before the first frame update
    void Start()
    {
        InitialPosition = transform.position;
        InitialScale = transform.localScale;
    }
    
    // 360 degrees in a circle
    // 2 pi radians in a circle

    // Update is called once per frame
    void Update()
    {
        // bounce progress is always 0 to 1 (aka 0 to 100%)
        // % is the modulus operator it returns the remainder
        BounceProgress = (BounceProgress + Time.deltaTime / BouncePeriod) % 1f;

        // calculate the height offset
        float heightOffset = Mathf.Sin(BounceProgress * 2f * Mathf.PI) * BounceHeight;

        // update the height
        transform.position = InitialPosition + new Vector3(0, heightOffset, 0);

        // version 1 of pulse - snaps back to 0
        // pulse progress is always 0 to 1 (aka 0 to 100%)
        // if pulse frequency is 1 then progress is 50% at 0.5s and 100% at 1s
        // if pulse frequency is 2 then progresss is 50% at 0.25s and 100% at 0.5s
        //PulseProgress = (PulseProgress + Time.deltaTime * PulseFrequency) % 1f;

        // version2 of pulse - smoothly moves back to 0
        // PingPong will bounce from 0 up to the input value (period) and back down to 0 once period has elapsed
        // ie. at 0 it will be 0; at 0.5 * period it will be 0.5 * period; at period it will be 0
        PulseProgress = Mathf.PingPong(Time.time, 1f / PulseFrequency) * PulseFrequency;

        // update the scale
        transform.localScale = InitialScale * Mathf.Lerp(PulseMagnitude_Min, PulseMagnitude_Max, PulseProgress);
    }
}
