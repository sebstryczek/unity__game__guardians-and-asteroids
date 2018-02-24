using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    [SerializeField] private float time = 1.0f;
    private float timer = 0.0f;

    private void Update()
    {
        this.timer += Time.deltaTime;
        if (this.timer >= this.time)
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
