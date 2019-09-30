using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlayerKiller : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PacMan_Controller>().ourData.DoGameOver();
        }
            
    }
}
