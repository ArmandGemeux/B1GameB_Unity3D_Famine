using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementController : MonoBehaviour
{
    GameObject getTarget;

    bool isMouseDragging;

    Vector3 offsetValue;
    Vector3 positionOfScreen;

<<<<<<< HEAD

    
    public int forbidenShortDistance;
    public int forbidenLongDistance;

=======
    public int forbidenShortDistance;
    public int forbidenLongDistance;
>>>>>>> 0f5d44c4c72e41769ec7deb1457929495a543f6a

    void Start()
    {


    }

    void Update()
    {

        
        if (UIManager_MenuPause.isPaused == false)
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

            if (Input.GetMouseButtonUp(0) && (GameManager.s_Singleton.shorterDistance >= forbidenShortDistance) && (GameManager.s_Singleton.shorterDistance <= forbidenLongDistance))
            {
                isMouseDragging = false;
                GameManager.s_Singleton.GetDraggedTransform(null);

                Debug.Log("Gné je ne suis pas un demeuré!");
            }
            else if(Input.GetMouseButtonUp(0))
            {
                isMouseDragging = false;
                GameManager.s_Singleton.GetDraggedTransform(null);

                Debug.Log("J'aimerai mourir!");
            }

            if (isMouseDragging)
            {
                Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z);

                Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenSpace) + offsetValue;

                getTarget.transform.position = currentPosition;
                GameManager.s_Singleton.GetDraggedTransform(transform);
            }
        }
    }

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
        GameManager.s_Singleton.AddAtome(transform);
    }
}