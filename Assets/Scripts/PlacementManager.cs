using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlacementManager : MonoBehaviour
{
    
    public GameObject[] Objects;
    private GameObject PendingObjects;
    [SerializeField] private Material[] materials;
    // position to place object
    private Vector3 pos;

    private RaycastHit hit;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private int Raydist;
    [SerializeField] GameObject SelectorUi;
    

    [SerializeField] GameObject Hotkey1;
    [SerializeField] GameObject Hotkey2;
    [SerializeField] GameObject Hotkey3;
    private GameObject CachedObj;
    
    public float rotateAmount;

    public float GridSize;
    bool GridOn = true;

    public bool CanPlace = true;
   
    [SerializeField] private Toggle GridToggle;

   

    // Update is called once per frame
    void Update()
    {
        if (PendingObjects != null)
        {
            if (GridOn)
            {
                PendingObjects.transform.position = new Vector3(
                    RoundToNearestGrid(pos.x),
                    RoundToNearestGrid(pos.y),
                    RoundToNearestGrid(pos.z)
                                                               );

            }
            else
            {
                PendingObjects.transform.position = pos;
            }

            if (Input.GetMouseButtonDown(0) && !SelectorUi.activeSelf && CanPlace)
            {
                PlaceObject();
            }
            if(Input.GetKeyDown(KeyCode.R))
            {
                RotateObject();
            }
            if (Input.GetMouseButtonDown(1) && !SelectorUi.activeSelf)
            {
                
            }
            UpdateMaterials();
        }
    }

    public void PlaceObject()
    {
        PendingObjects.GetComponent<MeshRenderer>().material = materials[2];
        //clears pending object after being used
        PendingObjects = null;
    }

    public void RotateObject()
    {
        PendingObjects.transform.Rotate(Vector3.up, rotateAmount);
    }
    // Handles physics
    private void FixedUpdate()
    {
        // Raycast orgins from the and mouse position
        Ray raycast = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(raycast, out hit, Raydist, layerMask))
        {
            // The point that receives the raycast
            pos = hit.point;
        }

    
    }

  

    public void ChangeHotKey(int slot)
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            
           
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            slot = 2;
        } 

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            slot = 3;
        }
    }

    void UpdateMaterials()
    {
        if(CanPlace)
        {
            PendingObjects.GetComponent<MeshRenderer>().material = materials[0];
        }

        else
        {
            PendingObjects.GetComponent<MeshRenderer>().material = materials[1];
        }
    }

    public void SelectObject(int index)
    {
        PendingObjects = Instantiate(Objects[index], pos, transform.rotation);
    }

    public void ToggleGrid()
    {
        if (GridToggle.isOn)
        {
            GridOn = true;
        }
        else
        {
            GridOn = false;
        }
    }
    float RoundToNearestGrid(float pos)
    {
        // Gets the remainder of the position and gridsize
        float xDiff = pos % GridSize;
        pos -= xDiff;

        // checks the closest number to round up or down to.
        if (xDiff > (GridSize/ 2))
        {
            pos += GridSize;
        }
        return pos;
    }
}
