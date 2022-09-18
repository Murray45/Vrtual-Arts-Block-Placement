using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlacement : MonoBehaviour
{
    PlacementManager placementManager;

    // Start is called before the first frame update
    void Start()
    {
        placementManager = GameObject.Find("PlacementManager").GetComponent<PlacementManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Object"))
        {
            placementManager.CanPlace = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        {
            if (other.gameObject.CompareTag("Object"))
            {
                placementManager.CanPlace = true;
            }
        }
    }

}
