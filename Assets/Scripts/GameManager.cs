using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public List<Transform> atomeList;
    private Transform currentDraggedTransform = null;

    public float shorterDistance = 0f;

    private GameObject closerGameObject;
    private Transform benoitDuTrou;
    public int myScore = 0;

    public GameObject fullItem;
    private GameObject currentCard;
    private GameObject currentFullItem;


    public static GameManager s_Singleton;

    private void Awake()
    {
        if (s_Singleton != null)
        {
            Destroy(gameObject);
        }
        else
        {
            s_Singleton = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        UIManager_MenuPause.isPaused = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (currentDraggedTransform != null)
        {
            GetCloserObject();
            Debug.Log(closerGameObject.name + " : " + shorterDistance);
        }
    }

    public void AddAtome(Transform newAtome)
    {
        if (!atomeList.Contains(newAtome))
        {
            atomeList.Add(newAtome);
            Debug.Log(newAtome);
        }
    }

    public void GetDraggedTransform(Transform draggedTrs)
    {
        currentDraggedTransform = draggedTrs;
    }

    private void GetCloserObject()
    {
        shorterDistance = Vector3.Distance(atomeList[0].position, currentDraggedTransform.position);
        closerGameObject = atomeList[0].gameObject;
        for (int i = 0; i < atomeList.Count; i++)
        {
            var a = 0;

            benoitDuTrou = atomeList[i];
            if(benoitDuTrou == currentDraggedTransform)
            {
                a = 1;
            }

            if ((Vector3.Distance(atomeList[i].position, currentDraggedTransform.position) < shorterDistance) && a == 0)
            {
                shorterDistance = Vector3.Distance(atomeList[i].position, currentDraggedTransform.position);
                closerGameObject = atomeList[i].gameObject;
            }
        }
    }

    public void DisplayItem()
    {
        currentFullItem = Instantiate(fullItem);
        currentCard.SetActive(false);
    }

    public void HideItem()
    {
        Destroy(currentFullItem);
        currentCard.SetActive(true);

    }

    public void FillInCurrentCard(GameObject cCard)
    {
        currentCard = cCard;
    }
}
