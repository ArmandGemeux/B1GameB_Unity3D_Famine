using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementController : MonoBehaviour
{
    GameObject getTarget;
    bool isMouseDragging;
    Vector3 offsetValue;
    Vector3 positionOfScreen;
    public int forbidenDistance;

    void Start()
    {


    }
    void Update()
    {
<<<<<<< HEAD
        
        if (UIManager_MenuPause.isPaused == false)
=======

        if (!UIManager_MenuPause.isPaused)
>>>>>>> ca9af90d6e942416519f79b504fa8a9e91cd2a70

        {

            if (Input.GetKeyDown(KeyCode.F))
            {
                AddInList();
            }

            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hitInfo;
                getTarget = ReturnClickedObject(out hitInfo);
                if ((getTarget != null) && (getTarget.tag == "Atomium"))
                {
                    isMouseDragging = true;

                    positionOfScreen = Camera.main.WorldToScreenPoint(getTarget.transform.position);
                    offsetValue = getTarget.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z));
                }
            }

            if (Input.GetMouseButtonUp(0) && (GameManager.Singleton.shorterDistance >= forbidenDistance))
            {
                isMouseDragging = false;
                GameManager.Singleton.GetDraggedTransform(null);
            }

            if (isMouseDragging)
            {
                Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z);

                Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenSpace) + offsetValue;

                getTarget.transform.position = currentPosition;
                GameManager.Singleton.GetDraggedTransform(transform);
            }
        }
    }
<<<<<<< HEAD
}

=======
>>>>>>> ca9af90d6e942416519f79b504fa8a9e91cd2a70

    GameObject ReturnClickedObject(out RaycastHit hit)
    {
        GameObject target = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
        {
            target = hit.collider.gameObject;
        }
        return target;
    }

    public void AddInList()
    {
        GameManager.Singleton.AddAtome(transform);
    }
}