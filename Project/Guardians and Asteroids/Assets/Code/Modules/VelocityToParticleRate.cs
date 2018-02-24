using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityToParticleRate : MonoBehaviour
{
    #pragma warning disable 0109
    [SerializeField] private new ParticleSystem particleSystem;
    [SerializeField] private new Rigidbody2D rigidbody2D;
    [SerializeField] private float minRate = 0f;
    [SerializeField] private float maxRate = 25f;
    [SerializeField] private float modifier = 0.01f;

    private void Update()
    {
        float rate = this.rigidbody2D.velocity.sqrMagnitude * this.modifier;
        float clampedRate =  Mathf.Clamp(rate, this.minRate, this.maxRate);
        this.SetParticleEmmision(clampedRate);
    }

    private void SetParticleEmmision(float value)
    {
        ParticleSystem.EmissionModule em = this.particleSystem.emission;
        ParticleSystem.MinMaxCurve rate = em.rateOverTime;
        rate.constant = value;
        em.rateOverTime = rate;
    }
}
