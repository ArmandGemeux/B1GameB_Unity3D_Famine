using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public List<Transform> atomeList;
    private Transform currentDraggedTransform = null;

    public float shorterDistance = 0f;

    public GameObject closerGameObject;

    public GameObject fullItem;
    private GameObject currentCard;
    private GameObject currentFullItem;

    public bool canDragAtome = true;

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
        AtomNumber();

    }

    // Update is called once per frame
    void Update()
    {
        if (currentDraggedTransform != null)
        {
            GetClosestAtomFromDraggedAtom();
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

    public void NullifyDraggedTransform()
    {
        currentDraggedTransform = null;
    }

    public void GetClosestAtomFromDraggedAtom ()
    {
        shorterDistance = 999999f;
        for (int i = 0; i < atomeList.Count; i++)
        {
            if (atomeList[i] != currentDraggedTransform)
            {
                float tmpSd = Vector3.Distance(atomeList[i].position, currentDraggedTransform.position);
                if (tmpSd < shorterDistance)
                {
                    shorterDistance = tmpSd;
                    closerGameObject = atomeList[i].gameObject;
                }
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

    public void AtomNumber()
    {
        int randNumber = Random.Range(0, 4);
        
        Debug.Log(randNumber);
    }
}
