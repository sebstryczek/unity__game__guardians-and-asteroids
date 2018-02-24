using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Model model;
    public Model Model { get { return this.model; } }
    
    private void Awake()
    {
        this.model.CreateCollider();
    }
}
