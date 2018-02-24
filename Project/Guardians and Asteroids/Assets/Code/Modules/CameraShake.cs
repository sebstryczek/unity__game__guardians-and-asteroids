using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Vector3 originalPosition;
    private float shakeDuration = 0f;
    private float shakeAmount = 2.0f;
    private float shakeDecreaseFactor = 1.0f;

    private void Awake() 
    {
        this.originalPosition = this.transform.position;
    }

    private void Update()
    {
        if (this.shakeDuration > 0)
        {
            this.transform.position = this.originalPosition + Random.insideUnitSphere * this.shakeAmount;
            this.shakeDuration -= Time.deltaTime * this.shakeDecreaseFactor;
        }
        else
        {
            this.transform.position = this.originalPosition;
            this.shakeDuration = 0f;
        }
    }
    
    public void Shake()
    {
        this.shakeDuration = Mathf.Clamp01( this.shakeDuration + 0.25f );
    }

    public void Stop()
    {
        this.shakeDuration = 0;
    }
}
