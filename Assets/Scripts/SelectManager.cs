using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectManager : MonoBehaviour
{
    public GameObject selectedObject;
    public TextMeshProUGUI objNameText;
    private PlacementManager placementManager;
    public GameObject objui;
   
    void Start()
    {
        placementManager = GameObject.Find("PlacementManager").GetComponent<PlacementManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000))
            {
                if (hit.collider.gameObject.CompareTag("Object"))
                {
                    Select(hit.collider.gameObject);
                }
            }
        }
        if(Input.GetMouseButtonDown(1) && selectedObject != null)
        {
            Deselect();
        }

    }
        private void Select(GameObject obj)
        {
         if (obj == selectedObject) return;
        if (selectedObject != null) Deselect();
            selectedObject = obj;
        objNameText.text = obj.name;
        objui.SetActive(true);
        }

    private void Deselect()
    {
        selectedObject = null;
        objui.SetActive(false);
    }

    public void Move()
    {
        placementManager.PendingObjects = selectedObject;
    }

    public void Delete()
    {
        GameObject objToDestroy = selectedObject;
        Deselect();
        Destroy(objToDestroy);
    }

}
