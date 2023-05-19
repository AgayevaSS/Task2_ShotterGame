using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float attackRate;
    public GameObject bulletPrefab;
    [SerializeField] Transform fireTransform;
    [SerializeField] private float force;

    private Vector3 _direction;
    private PlayerMove _player;

    private float _lastAttackTime;

    void Start()
    {
        _player = FindObjectOfType<PlayerMove>();
        
    }
    public void DestroyEnemy()
    {

        Destroy(gameObject);
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, _player.transform.position);
        if (distance > 2)
        {
            _direction = transform.position - _player.transform.position;
            _direction.Normalize();
            transform.Translate(_direction * speed * Time.deltaTime);

        }
        else
        {
            if (Time.time >= _lastAttackTime + attackRate)
            {
                Instantiate(bulletPrefab, fireTransform.position, Quaternion.identity)
                    .GetComponent<Rigidbody>().AddForce(fireTransform.forward * force, ForceMode.Impulse);

                _lastAttackTime = Time.time;
            }
        }

        transform.LookAt(_player.transform);
    }
   
}
