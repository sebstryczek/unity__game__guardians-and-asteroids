using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 Axis
    {
        get
        {
            float AxisHorizontal = CnControls.CnInputManager.GetAxis("Horizontal");
            float AxisVertical = CnControls.CnInputManager.GetAxis("Vertical");
            return new Vector2(AxisHorizontal, AxisVertical);
        }
    }
    private bool IsAxisInUse { get { return this.Axis.x != 0 || this.Axis.y != 0; } }
    private bool IsAccelerating { get { return Vector2.Distance(Vector2.zero, this.Axis) > 0; } }

    bool isPress;

    Rigidbody2D rb2d;
    private void Awake()
    {
        this.rb2d = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (this.IsAxisInUse)
        {
            this.transform.rotation = this.GetRotation();
        }

        if (this.IsAccelerating)
        {
            this.rb2d.AddForce(this.transform.up * 60);
        }
    }

    private Quaternion GetRotation()
    {
        float angle = this.GetAngleBetween(Vector2.up, this.Axis);
        Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
        return Quaternion.Lerp(this.transform.rotation, targetRotation, Time.deltaTime * 5);
    }

    private float GetAngleBetween(Vector2 sourcePoint, Vector2 targetPoint)
    {
        float sourceAngle = Mathf.Atan2(sourcePoint.y, sourcePoint.x) * Mathf.Rad2Deg;
        float targetAngle = Mathf.Atan2(targetPoint.y, targetPoint.x) * Mathf.Rad2Deg;
        float angle = Mathf.DeltaAngle(sourceAngle, targetAngle);
        if (angle < 0) angle = angle + 360;
        return angle;
    }
}
