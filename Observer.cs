using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform player;
    public GameEnding gameEnding;
    bool catchedPlayer;

    void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            catchedPlayer = true; 
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            catchedPlayer = false;
        }
    }

    void Update()
    {
        if (catchedPlayer)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;

            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.transform == player)
                {
                   gameEnding.CaughtPlayer();
                }
            }
        }
    }
}