using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementController : MonoBehaviour
{
    bool isMouseDragging;
    
    public int forbidenShortDistance;
    public int forbidenLongDistance;

    void Start()
    {
        AddInList();
    }

    void Update()
    {
        if (isMouseDragging)
        {
            Vector3 mPos = Input.mousePosition;
            mPos.z = 10f;
            mPos = Camera.main.ScreenToWorldPoint(mPos);
            transform.position = mPos;
        }
    }

    public void AddInList()
    {
        GameManager.s_Singleton.AddAtome(transform);
    }

    private void OnMouseDown()
    {
        if (!UIManager_MenuPause.isPaused)
        {
            isMouseDragging = true;
            GameManager.s_Singleton.GetDraggedTransform(transform);
        }
    }

    private void OnMouseUpAsButton()
    {
        if (!UIManager_MenuPause.isPaused)
        {
            isMouseDragging = false;
            GameManager.s_Singleton.NullifyDraggedTransform();
        }
    }
}