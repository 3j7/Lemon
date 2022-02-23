using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEnding : MonoBehaviour
{
    public Ending gameEnding;
    public Transform player;
    bool isPlayerRange;
    void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            isPlayerRange = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            isPlayerRange = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerRange)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;
            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.transform == player)
                {
                    gameEnding.BurnedPlayer();
                }
            }
        }
    }
}

