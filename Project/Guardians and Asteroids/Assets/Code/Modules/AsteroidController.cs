using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AsteroidController : MonoBehaviour
{
    [SerializeField] private List<GameObject> prefabsAsteroids;
    [SerializeField] private GameObject prefabExplosion;
    [SerializeField] private float interval = 1.0f;

    private float timer = 0.0f;

    private void Update()
    {
        this.timer += Time.deltaTime;

        if (this.timer >= this.interval)
        {
            this.timer = 0;
            this.CreateAsteroid();
        }
    }

    private void CreateAsteroid()
    {
        Rect worldRect = State.Instance.Get<StateCamera>().WorldRect;

        GameObject prefab = this.GetRandomPrefab();
        GameObject go = GameObject.Instantiate(prefab);

        Asteroid asteroid = go.GetComponent<Asteroid>();
        float size = asteroid.Model.Size;

        SpawnEdge spawnEdge = AsteroidControllerUtils.GetRandomSpawnEdge();

        Rect spawnRect = RectUtils.Resize(worldRect, size * 0.5f);
        Vector3 position = AsteroidControllerUtils.GetRandomPosition(spawnEdge, spawnRect);
        asteroid.SetPosition(position);

        Rect rangeRect = RectUtils.CreateSquare(position, size);
        Rect clampRect = RectUtils.Resize(worldRect, size * -0.5f);
        Vector3 forceDirection = AsteroidControllerUtils.GetRandomForceDirection(spawnEdge, rangeRect, clampRect);
        asteroid.AddForces(forceDirection - position);

        asteroid.Model.OnHit += this.OnHit;
    }

    private GameObject GetRandomPrefab()
    {
        int rand = Random.Range(0, this.prefabsAsteroids.Count);
        return this.prefabsAsteroids[rand];
    }
    
    public void OnHit(Transform model, Transform other)
    {
        if (other.gameObject.CompareTag("Missle"))
        {
            Asteroid asteroid = model.GetComponentInParent<Asteroid>();
            GameObject.Instantiate(this.prefabExplosion, other.position, other.rotation);
            GameObject.Destroy(asteroid.gameObject);
            GameObject.Destroy(other.gameObject);

            if (asteroid.Type != AsteroidType.SMALL)
            {
                GameObject prefab = this.prefabsAsteroids[(int)asteroid.Type + 1];
                Vector3 position = other.position;
                Vector3 f1 = new Vector2(asteroid.ForceDirection.x, -asteroid.ForceDirection.y) * 2;
                Vector3 f2 = new Vector2(-asteroid.ForceDirection.x, asteroid.ForceDirection.y) * 2;

                Asteroid childAsteroid1 = GameObject.Instantiate(prefab).GetComponent<Asteroid>();
                childAsteroid1.SetPosition(position);
                childAsteroid1.AddForces(f1);
                childAsteroid1.Model.OnHit += this.OnHit;

                Asteroid childAsteroid2 = GameObject.Instantiate(prefab).GetComponent<Asteroid>();
                childAsteroid2.SetPosition(position);
                childAsteroid2.AddForces(f2);
                childAsteroid2.Model.OnHit += this.OnHit;
            }
        }
    }
}
