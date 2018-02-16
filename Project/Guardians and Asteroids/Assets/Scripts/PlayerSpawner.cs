using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabPlayer;

    private void Start()
    {
        GameObject.Instantiate(this.prefabPlayer);
    }

    private void Update()
    {
        
    }
}
