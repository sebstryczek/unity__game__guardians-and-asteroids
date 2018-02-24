using UnityEngine;
using UnityEngine.Events;

public enum AsteroidType {
    LARGE,
    MEDIUM,
    SMALL
}

public class Asteroid : MonoBehaviour
{
    [SerializeField] private AsteroidType type;
    [SerializeField] private Model model;
    [SerializeField] UnityEvent onDestroy;

    public AsteroidType Type { get { return this.type; } }
    public Model Model { get { return this.model; } }
    public Vector2 ForceDirection { get; private set; }

    private void Awake()
    {
        this.name = this.GetInstanceID().ToString();
        this.model.GenerateLineRenderer();
        this.model.CreateCollider();
    }

    public void SetPosition(Vector3 position)
    {
        this.transform.position = position;
    }
    
    public void AddForces(Vector3 forceDirection)
    {
        this.ForceDirection = forceDirection;
        Rigidbody2D rb2d = this.GetComponent<Rigidbody2D>();
        rb2d.AddForce(forceDirection * 10);
        rb2d.AddTorque(Random.Range(1, 10));
    }

    private void OnDestroy()
    {
        this.onDestroy.Invoke();
    }
}
