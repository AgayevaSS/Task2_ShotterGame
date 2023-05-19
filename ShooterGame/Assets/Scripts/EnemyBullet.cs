using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float force;
    private Rigidbody _rigidbody;
    [SerializeField] float bulletLifetime = 3f;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

        Destroy(gameObject, bulletLifetime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        
        Destroy(gameObject);
    }
}
