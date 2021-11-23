using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BaseBullet : MonoBehaviour
{
    public float speed;
    protected Rigidbody rb;

    
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
