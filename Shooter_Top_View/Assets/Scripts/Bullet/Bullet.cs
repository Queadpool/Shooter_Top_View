using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody _rB = null;
    [SerializeField] private float _firePower = 30.0f;

    void Start()
    {
        _rB = GetComponent<Rigidbody>();
        _rB.velocity = transform.forward * _firePower;
        Destroy(gameObject, 2.0f);
    }
}
