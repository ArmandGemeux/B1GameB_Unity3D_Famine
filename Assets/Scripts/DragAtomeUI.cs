using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragAtomeUI : MonoBehaviour, IDragHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        GetComponent<Image>().raycastTarget = false;
        GameManager.s_Singleton.FillInCurrentCard(gameObject);
        var mPos = Input.mousePosition;
        mPos.z = 10f;
        transform.position = mPos;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}