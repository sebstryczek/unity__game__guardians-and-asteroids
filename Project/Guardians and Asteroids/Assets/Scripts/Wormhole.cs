using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wormhole : MonoBehaviour
{
    /*
    private bool isInit = false;
    private GameObject cloneTop;
    private GameObject cloneBottom;
    private GameObject cloneLeft;
    private GameObject cloneRight;

    private bool xReady = false;
    private bool yReady = false;
    protected float size = 0.0f;

    public delegate void OnHitHandler(Collider2D other);
    public event OnHitHandler OnHit;
    
    public void Init()
    {
        GameEntity ge = this.GetComponent<GameEntity>();
        this.size = ge.size;

        this.cloneTop = GameObject.Instantiate(ge.Model);
        this.cloneBottom = GameObject.Instantiate(ge.Model);
        this.cloneLeft = GameObject.Instantiate(ge.Model);
        this.cloneRight = GameObject.Instantiate(ge.Model);

        this.cloneTop.tag = this.gameObject.tag;
        this.cloneBottom.tag = this.gameObject.tag;
        this.cloneLeft.tag = this.gameObject.tag;
        this.cloneRight.tag = this.gameObject.tag;

        this.cloneTop.AddComponent<WormholeClone>().SetRoot(this);
        this.cloneBottom.AddComponent<WormholeClone>().SetRoot(this);
        this.cloneLeft.AddComponent<WormholeClone>().SetRoot(this);
        this.cloneRight.AddComponent<WormholeClone>().SetRoot(this);

        this.cloneTop.SetActive(false);
        this.cloneBottom.SetActive(false);
        this.cloneLeft.SetActive(false);
        this.cloneRight.SetActive(false);

        this.isInit = true;
    }

    private void FixedUpdate()
    {
        if (!this.isInit) return;
        this.UpdatePosition();
        this.UpdateRotation();
    }

    private void OnDestroy()
    {
        GameObject.Destroy(this.cloneTop);
        GameObject.Destroy(this.cloneBottom);
        GameObject.Destroy(this.cloneLeft);
        GameObject.Destroy(this.cloneRight);
    }

    private void UpdatePosition()
    {
        Rect worldRect = GameManager.Instance.worldRect;
        Vector3 position = this.transform.position;

        this.cloneBottom.transform.position = position - new Vector3(0, worldRect.height, 0);
        this.cloneLeft.transform.position = position - new Vector3(worldRect.width, 0, 0);
        this.cloneTop.transform.position = position + new Vector3(0, worldRect.height, 0);
        this.cloneRight.transform.position = position + new Vector3(worldRect.width, 0, 0);

        if (!this.yReady)
        {
            float yMaxModel = this.transform.position.y + this.size / 2;
            float yMinModel = this.transform.position.y - this.size / 2;
            bool yMaxReady = yMaxModel < worldRect.yMax;
            bool yMinReady = yMinModel > worldRect.yMin;
            this.yReady = yMaxReady && yMinReady;
        }
        else
        {
            //DO AFTER OBJECTS FULL APPEAR IN SCREEN BOUNDS
            this.cloneTop.SetActive(true);
            this.cloneBottom.SetActive(true);

            if (position.y >= worldRect.yMax)
            {
                this.transform.position = this.cloneBottom.transform.position;
            }

            if (position.y <= worldRect.yMin)
            {
                this.transform.position = this.cloneTop.transform.position;
            }
        }

        if (!this.xReady)
        {
            float xMaxModel = this.transform.position.x + this.size / 2;
            float xMinModel = this.transform.position.x - this.size / 2;
            bool xMaxReady = xMaxModel < worldRect.xMax;
            bool xMinReady = xMinModel > worldRect.xMin;
            this.xReady = xMaxReady && xMinReady;
        }
        else
        {
            //DO AFTER OBJECTS FULL APPEAR IN SCREEN BOUNDS
            this.cloneLeft.SetActive(true);
            this.cloneRight.SetActive(true);

            if (position.x >= worldRect.xMax)
            {
                this.transform.position = this.cloneLeft.transform.position;
            }

            if (position.x <= worldRect.xMin)
            {
                this.transform.position = this.cloneRight.transform.position;
            }
        }
    }

    private void UpdateRotation()
    {
        Quaternion rotation = this.transform.rotation;
        this.cloneTop.transform.rotation = rotation;
        this.cloneBottom.transform.rotation = rotation;
        this.cloneLeft.transform.rotation = rotation;
        this.cloneRight.transform.rotation = rotation;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        this.SolveTriggerEnter2D(other);
    }

    public void SolveTriggerEnter2D(Collider2D other)
    {
        this.OnHit?.Invoke(other);
    }
    */
}
