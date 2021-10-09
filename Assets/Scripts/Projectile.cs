using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody body;
    private void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    public Rigidbody rigidbody { get; set; }
    public void Shoot()
    {
        body.useGravity = true;
        Destroy(gameObject, 1f);
    }
}
