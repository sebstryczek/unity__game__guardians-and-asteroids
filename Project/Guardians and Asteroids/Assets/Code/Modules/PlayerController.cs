using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject prefabPlayer;
    [SerializeField] private UnityEvent onDead;

    private void Start()
    {
        GameObject go = GameObject.Instantiate(this.prefabPlayer);
        Player player = go.GetComponent<Player>();
        player.Model.OnHit += this.OnHit;
    }

    public void OnHit(Transform model, Transform other)
    {
        if (other.gameObject.CompareTag("Asteroid"))
        {
            this.onDead.Invoke();
        }
    }
}
