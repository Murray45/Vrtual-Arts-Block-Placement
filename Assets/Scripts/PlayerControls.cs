using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] GameObject gameObjectUi;
    [SerializeField] GameObject placementMang;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObjectUi = null)
        {
            Debug.Log("Cant find UI");
        }
        if (placementMang = null)
        {
            Debug.Log("Cant find PlacementManager");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (gameObjectUi.activeSelf == true)
            {
                gameObjectUi.SetActive(false);
                
            }
            else
            {
                gameObjectUi.SetActive(true);
            }
        }

    }
 
}
