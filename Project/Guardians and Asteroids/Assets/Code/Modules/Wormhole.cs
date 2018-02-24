using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wormhole : MonoBehaviour
{
    [SerializeField] private Model model;
    private Transform selfTransform;
    private Transform modelTransform;
    private Transform cloneTop;
    private Transform cloneBottom;
    private Transform cloneLeft;
    private Transform cloneRight;

    private bool xReady = false;
    private bool yReady = false;

    private void Awake()
    {
        this.selfTransform = this.transform;
        this.modelTransform = this.model.transform;
        this.cloneTop = this.GetClone("_Top");
        this.cloneBottom = this.GetClone("_Bottom");
        this.cloneLeft = this.GetClone("_Left");
        this.cloneRight = this.GetClone("_Right");
    }

    private Transform GetClone(string namePostfix)
    {
        GameObject clone = GameObject.Instantiate(this.model.gameObject);
        clone.name = gameObject.name + namePostfix;
        clone.tag = gameObject.tag;
        clone.SetActive(false);
        Model cloneModel = clone.GetComponent<Model>();
        cloneModel.OnHit += (Transform model, Transform other) => { this.model.InvokeHit(other); };
        return clone.transform;
    }

    private void FixedUpdate()
    {
        this.UpdateReadiness();
        this.UpdatePosition();
        this.UpdateClonesVisibility();
        this.UpdateClonesPosition();
        this.UpdateClonesRotation();
    }
    
    public void UpdateReadiness()
    {
        Rect worldRect = State.Instance.Get<StateCamera>().WorldRect;
        Vector3 position = this.modelTransform.position;

        if (!this.yReady)
        {
            bool yMaxReady = position.y < (worldRect.yMax - worldRect.height * 0.25);
            bool yMinReady = position.y > (worldRect.yMin + worldRect.height * 0.25);
            this.yReady = yMaxReady && yMinReady;
        }

        if (!this.xReady)
        {
            bool xMaxReady = position.x < (worldRect.xMax - worldRect.width * 0.25);
            bool xMinReady = position.x > (worldRect.xMin + worldRect.width * 0.25);
            this.xReady = xMaxReady && xMinReady;
        }
    }

    public void UpdatePosition()
    {
        Rect worldRect = State.Instance.Get<StateCamera>().WorldRect;
        Vector3 position = this.modelTransform.position;

        if (this.yReady)
        {
            if (position.y >= worldRect.yMax)
            {
                this.selfTransform.position = this.cloneBottom.transform.position;
            }

            if (position.y <= worldRect.yMin)
            {
                this.selfTransform.position = this.cloneTop.transform.position;
            }
        }

        if (this.xReady)
        {
            if (position.x >= worldRect.xMax)
            {
                this.selfTransform.position = this.cloneLeft.transform.position;
            }

            if (position.x <= worldRect.xMin)
            {
                this.selfTransform.position = this.cloneRight.transform.position;
            }
        }
    }

    private void UpdateClonesVisibility()
    {
        bool yHidden = (!this.cloneTop.gameObject.activeSelf || !this.cloneBottom.gameObject.activeSelf);
        if (this.yReady && yHidden)
        {
            this.cloneTop.gameObject.SetActive(true);
            this.cloneBottom.gameObject.SetActive(true);
        }

        bool xHidden = (!this.cloneLeft.gameObject.activeSelf || !this.cloneRight.gameObject.activeSelf);
        if (this.xReady && xHidden)
        {
            this.cloneLeft.gameObject.SetActive(true);
            this.cloneRight.gameObject.SetActive(true);
        }
    }

    private void UpdateClonesPosition()
    {
        Rect worldRect = State.Instance.Get<StateCamera>().WorldRect;
        Vector3 position = this.modelTransform.position;

        this.cloneBottom.position = position - new Vector3(0, worldRect.height, 0);
        this.cloneLeft.position = position - new Vector3(worldRect.width, 0, 0);
        this.cloneTop.position = position + new Vector3(0, worldRect.height, 0);
        this.cloneRight.position = position + new Vector3(worldRect.width, 0, 0);
    }

    private void UpdateClonesRotation()
    {
        Quaternion rotation = this.selfTransform.rotation;
        this.cloneTop.rotation = rotation;
        this.cloneBottom.rotation = rotation;
        this.cloneLeft.rotation = rotation;
        this.cloneRight.rotation = rotation;
    }

    private void OnDestroy()
    {
        if (this.cloneTop) GameObject.Destroy(this.cloneTop.gameObject);
        if (this.cloneBottom) GameObject.Destroy(this.cloneBottom.gameObject);
        if (this.cloneLeft) GameObject.Destroy(this.cloneLeft.gameObject);
        if (this.cloneRight) GameObject.Destroy(this.cloneRight.gameObject);
    }
}
