using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Block : MonoBehaviour
{

    public float Height => _height;
    
    [SerializeField]
    private float _height;

    public event UnityAction<Block> Broken;

    private void OnTriggerEnter(Collider other)
    {
        bool isOk = other.TryGetComponent<Projectile>(out _);

        if(isOk)
        {
            Broken?.Invoke(this);
            Destroy(gameObject);
        }
        
    }
}
