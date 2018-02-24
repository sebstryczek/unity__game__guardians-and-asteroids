using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Model : MonoBehaviour
{
    public delegate void OnHitHandler(Transform self, Transform other);
    public event OnHitHandler OnHit;
    public float Size { get; private set; }
    private Vector3[] vertices;
    
    public void GenerateLineRenderer()
    {
        this.vertices = this.GetRandomVertices();
        
        LineRenderer lineRenderer = this.GetComponent<LineRenderer>();
        lineRenderer.positionCount = vertices.Length;
        lineRenderer.SetPositions(vertices);

        Bounds bounds = lineRenderer.bounds;
        this.Size = bounds.size.x > bounds.size.y ? bounds.size.x : bounds.size.y;
    }

    public void CreateCollider()
    {
        if (this.vertices == null) this.vertices = this.GetLineRendererVertices();
        PolygonCollider2D polygonCollider2D = this.GetComponent<PolygonCollider2D>();
        polygonCollider2D.points = vertices.Select(p => new Vector2(p.x, p.y)).ToArray();
    }

    private Vector3[] GetLineRendererVertices()
    {
        LineRenderer lineRenderer = this.GetComponent<LineRenderer>();
        int count = lineRenderer.positionCount;
        Vector3[] vertices = new Vector3[count];
        for (int i = 0; i < count; i++)
        {
            vertices[i] = lineRenderer.GetPosition(i);
        }
        return vertices;
    }

    private Vector3[] GetRandomVertices()
    {
        int count = Random.Range(10, 12);
        Vector3[] vertices = new Vector3[count];
        float angle = Mathf.Deg2Rad * (360 / count);
        for (int i = 0; i < count; i++)
        {
            float x = Random.Range(5, 11) * Mathf.Cos(angle * i);
            float y = Random.Range(5, 11) * Mathf.Sin(angle * i);
            vertices[i] = new Vector3(x, y, 0);
        }
        return vertices;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Rect worldRect = State.Instance.Get<StateCamera>().WorldRect;
        Vector3 contactPoint = other.bounds.ClosestPoint(this.transform.position);
        if (worldRect.Contains(contactPoint))
        {
            this.InvokeHit(other.transform);
        }
    }

    public void InvokeHit(Transform other)
    {
        this.OnHit?.Invoke(this.transform, other);
    }

}
