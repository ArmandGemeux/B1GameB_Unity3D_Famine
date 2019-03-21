using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int linksQuantity;
    public int scoreByLink;
    public int atomeScoreValue;

    public List<Transform> atomeList;
    public List<Transform> atomeListCanLink;
    private Transform currentDraggedTransform = null;

    public float shorterDistance = 0f;
    public float shorterTrueDistance = 0f;

    public float shorterNextDistance = 0f;
    public float shorterNextTrueDistance = 0f;

    public float perfectDistanceAbs;
    public int maxAtomeRange;

    public GameObject closerGameObject;
    public GameObject closerTrueGameObject;

    public GameObject fullItem;
    private GameObject currentCard;
    private GameObject currentFullItem;

    public bool canDragAtome = true;

    public static GameManager s_Singleton;

    public float maxSpeedCursor = 5f;
    private float currentSpeedCursor;
    Vector3 centerScreenPoint;
    float maxScreenDistance;
    Vector3 cursorPos;

    public GameObject oneLink;
    public GameObject twoLink;
    public GameObject threeLink;
    public GameObject fourLink;

    /*
    

    public int valueFinal;
    */

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
        UIManager.isPaused = false;
        centerScreenPoint = new Vector3 (Screen.width / 2, Screen.height / 2, 0);
        maxScreenDistance = Vector3.Distance(centerScreenPoint, Vector3.zero);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentDraggedTransform != null)
        {
            GetClosestAtomFromDraggedAtom();
        }

        cursorPos = Input.mousePosition;
        float currentCursorDistance = Vector3.Distance(cursorPos, centerScreenPoint);
        currentSpeedCursor = (currentCursorDistance / maxScreenDistance) * maxSpeedCursor;
        var v3 = Camera.main.transform.position;

        if (Input.GetMouseButton(1))
        {
            if (cursorPos.y < Screen.height / 2)
            {
                v3.y -= currentSpeedCursor * Time.deltaTime;
                Camera.main.transform.position = v3;
            }

            if (cursorPos.y > Screen.height / 2)
            {
                v3.y += currentSpeedCursor * Time.deltaTime;
                Camera.main.transform.position = v3;
            }

            if (cursorPos.x < Screen.width / 2)
            {
                v3.x -= currentSpeedCursor * Time.deltaTime;
                Camera.main.transform.position = v3;
            }

            if (cursorPos.x > Screen.width / 2)
            {
                v3.x += currentSpeedCursor * Time.deltaTime;
                Camera.main.transform.position = v3;
            }
        }
    }

    public void AddAtome(Transform newAtome)
    {
        if (!atomeList.Contains(newAtome))
        {
            atomeList.Add(newAtome);
            atomeListCanLink.Add(newAtome);
            Debug.Log(newAtome);
        }
    }

    public void DelAtome(Transform oldAtome)
    {
        if (atomeList.Contains(oldAtome))
        {
            atomeList.Remove(oldAtome);
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

    public void GetClosestAtomFromDraggedAtom () // Atomes les plus proche valide!!!!
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

    public void VerifyDistance(Vector2 nextDistance, Transform atomeToCheck) // Atomes les plus proche valide à la prochaine frame!!!!!
    {
        shorterNextDistance = 999999f;
        for (int i = 0; i < atomeList.Count; i++)
        {
            if (atomeList[i] != atomeToCheck)
            {
                float tmpSnd = Vector3.Distance(atomeList[i].position, nextDistance);
                if (tmpSnd < shorterNextDistance)
                {
                    shorterNextDistance = tmpSnd;
                }
            }
        }
    }

    public void DistanceToGoodAtome ()  // Atomes le plus proche commun!!!!!
    {
        shorterTrueDistance = 999999f;
        for (int i = 0; i < atomeListCanLink.Count; i++)
        {
            if (atomeListCanLink[i] != currentDraggedTransform)
            {
                float tmpSd = Vector3.Distance(atomeListCanLink[i].position, currentDraggedTransform.position);
                if (tmpSd < shorterTrueDistance)
                {
                    shorterTrueDistance = tmpSd;
                    closerTrueGameObject = atomeListCanLink[i].gameObject;
                }
            }
        }
    }

    public void VerifyDistanceToGoodAtome(Vector2 nextDistance, Transform atomeToCheck) //Atomes les plus proche commun à la prochaine frame!!!!!!!
    {
        shorterNextTrueDistance = 999999f;
        for (int i = 0; i < atomeListCanLink.Count; i++)
        {
            if (atomeListCanLink[i] != atomeToCheck)
            {
                float tmpSnd = Vector3.Distance(atomeListCanLink[i].position, nextDistance);
                if (tmpSnd < shorterNextTrueDistance)
                {
                    shorterNextTrueDistance = tmpSnd;
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
}
