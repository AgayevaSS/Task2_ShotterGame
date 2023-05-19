using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] GameObject Player;

    private float _distance;
    void Update()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        _distance = Vector3.Distance(transform.position, Player.transform.position);
        if (_distance >= 20f)
        {
            transform.position = Vector3.Lerp(transform.position, Player.transform.position + new Vector3(-1f, 2f, -1f), 1f * Time.deltaTime);
        }
        transform.LookAt(Player.transform.position);

    }
}
