using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{

    //[SerializeField] GameObject Coin;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy")) 
        {
            //Instantiate(Coin, other.transform.position, other.transform.rotation); 
            Destroy(other.gameObject);
        Destroy(gameObject);
        }
        
    }
}
