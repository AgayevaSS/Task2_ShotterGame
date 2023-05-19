using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform bulletPref;
    [SerializeField] private Transform firePosition;
    void Start()
    {
        
    }

  
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Transform bullet = Instantiate(bulletPref);
            bullet.localPosition = firePosition.position;

            bullet.GetComponent<Rigidbody>().AddForce(firePosition.forward * 2000);
        }
    }
}
