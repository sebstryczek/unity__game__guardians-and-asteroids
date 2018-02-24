using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabMissle;
    private bool IsFireButtonUp { get { return CnControls.CnInputManager.GetButtonUp("Fire"); } }

    private void Update()
    {
        if (this.IsFireButtonUp)
        {
            this.Shoot();
        }
    }

    private void Shoot()
    {
        GameObject missle = GameObject.Instantiate(this.prefabMissle);
        missle.transform.position = this.transform.position;
        missle.transform.rotation = this.transform.rotation;
        Rigidbody2D missleRb = missle.GetComponent<Rigidbody2D>();
        missleRb.AddForce(this.transform.up, ForceMode2D.Impulse);
    }
}
