using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BaseBullet : MonoBehaviour
{
    public float speed = 10;

    protected Rigidbody _rigidbody;

    protected virtual void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.velocity = transform.forward * speed;
    }

    protected virtual void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
