using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public LayerMask layer;
    public GameObject bombPrefab; 
    public float explosionRadius = 5f; 
    public float explosionForce = 10f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ThrowBomb();
        }
    }

    private void ThrowBomb()
    {
        GameObject bomb = Instantiate(bombPrefab, transform.position, Quaternion.identity);
        Destroy(bomb, 2f); 

        Invoke("Explode", 2f); 
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, layer);

        foreach (Collider collider in colliders)
        {
          
            Destroy(collider.gameObject);
        }
    }
}
