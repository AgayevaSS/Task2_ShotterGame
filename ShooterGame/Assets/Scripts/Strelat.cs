using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strelat : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform bulletPref;
    [SerializeField] private Transform firePosition;
    [SerializeField] private float attackDelay;

    private PlayerMove _player;
    private Vector3 _direction;
    private float _lastAttackTime;

    [SerializeField] Vector3 point1;
    [SerializeField] Vector3 point2 = new Vector3(1f, 1f, 1f);
    [SerializeField] GameObject go;

    void Start()
    {
        _player = FindObjectOfType<PlayerMove>();

        GameObject yeniObj = Instantiate(go);

        Destroy(yeniObj, 1f);

        Instantiate(go, new Vector3(1f, 1f, 1f), Quaternion.identity);

    }

    void Update()
    {

        _direction = _player.transform.position - transform.position;
        _direction.Normalize();
        transform.Translate(_direction * speed * Time.deltaTime);

        transform.LookAt(_player.transform);

        if (Vector3.Distance(_player.transform.position, transform.position) < 5)
        {
            if (Time.time >= _lastAttackTime + attackDelay)
            {
                Transform bullet = Instantiate(bulletPref);
                bullet.position = firePosition.position;

                bullet.GetComponent<Rigidbody>().AddForce(firePosition.forward * 50, ForceMode.Impulse);

                _lastAttackTime = Time.time;
            }

        }

    }
}
