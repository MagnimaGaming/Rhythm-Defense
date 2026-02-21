using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TileDetection : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Left Leg"))
        {
            
               Destroy(gameObject);
        }
        if (other.CompareTag("Right Leg"))
        {
                Destroy(gameObject);
            
        }
    }
}
