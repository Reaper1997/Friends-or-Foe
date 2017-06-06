using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIWithDisappearing : MonoBehaviour
{
    public Transform player;
    public int moveSpeed = 4;
    public int minDist = 5;
    public int maxDist = 10;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player);
        if (Vector3.Distance(transform.position, player.position) >= minDist)
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
            if (Vector3.Distance(transform.position, player.position) <= maxDist)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
