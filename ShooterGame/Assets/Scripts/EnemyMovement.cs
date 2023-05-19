using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //    [SerializeField] private GameObject[] obj;
    //    private Vector3 _direction;
    //    private PlayerMove _player;
    //    [SerializeField] private float speed;

    //    public GameObject enemyPrefab;
    //    public GameObject enemyObject;
    //    [SerializeField] GameObject Bullet;

    //    private void Start()
    //    {
    //        //GameObject newObject = Instantiate(obj, new Vector3(-1, 0.4f, 0.2f), Quaternion.Euler(2,0, 1)) as GameObject;
    //        //newObject.GetComponent<Transform>().position = new Vector3(5, 0, 5);
    //        _player = FindObjectOfType<PlayerMove>();
    //        StartCoroutine(BulletSpawn());
    //    }
    //    private int RandomNumber()
    //    {
    //        return Random.Range(0, 10);
    //    }
    //    // Update is called once per frame
    //    void Update()
    //    {
    //        _direction = _player.transform.position - transform.position;
    //        _direction.Normalize();
    //        transform.Translate(_direction * speed * Time.deltaTime);

    //        transform.LookAt(_player.transform);
    //    }



    //    IEnumerator BulletSpawn()
    //    {
    //        while (true)
    //        {
    //            Instantiate(Bullet, transform.position + transform.forward * 1f, transform.rotation);
    //            yield return new WaitForSeconds(3f);
    //        }
    //    }
    public GameObject player;
    public GameObject bulletPrefab;
    public float shootInterval = 2f;
    public float stoppingDistance = 5f;
    [SerializeField] private Transform firePosition;

    private bool isAttacking = false;

    void Start()
    {
        InvokeRepeating("Shoot", shootInterval, shootInterval);
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance > stoppingDistance)
        {
            transform.LookAt(player.transform);
            transform.Translate(Vector3.forward * Time.deltaTime);
        }
        else
        {
            if (!isAttacking)
            {
                isAttacking = true;
                
            }
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePosition.position, transform.rotation);
    }

}