using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementController : MonoBehaviour
{
    // On déclare toutes les variables!
    bool isMouseDragging;
    
    public float perfectDistance;

    public Vector2 direction = Vector2.zero;
    public float moveSpeed = 0f;
    private bool canMove = true;
    private bool moving = false;
    private bool neverAct = true;

    public float verfiedDistance;

    private Vector2 nextPosition;

    void Start()
    {
        AddInList(); // Ajoute l'atome possédant le script à une liste dans le GameManager.
    }

    void Update()
    {
        if (isMouseDragging)  // Déplace l'atome du script à la position de la souris.
        {
            Vector3 mPos = Input.mousePosition;
            mPos.z = 10f;
            mPos = Camera.main.ScreenToWorldPoint(mPos);
            transform.position = mPos;
        }

        MoveToGoodPos(); // Déplacement de l'atome vers sa position idéale.
    }

    public void AddInList()
    {
        GameManager.s_Singleton.AddAtome(transform); // Ajoute l'atome possédant le script à une liste dans le GameManager.
    }

    private void OnMouseDown() // Quand le bouton de la souris est enfoncé.
    {
        if (!UIManager.isPaused && gameObject.tag == "Atomium" && GameManager.s_Singleton.canDragAtome == true)
        {
            isMouseDragging = true;
            GameManager.s_Singleton.GetDraggedTransform(transform);
        }
    }

    private void OnMouseUpAsButton()
    {
        isMouseDragging = false;
        moving = true;
    }
    
    private void MoveToGoodPos()
    {
        if (moving == true && canMove == true && neverAct == true)
        {
            GameManager.s_Singleton.canDragAtome = false;

            GameManager.s_Singleton.GetClosestAtomFromDraggedAtom();

            if (GameManager.s_Singleton.shorterDistance > perfectDistance)
            {
                direction = GameManager.s_Singleton.closerGameObject.transform.position - transform.position;

                direction.Normalize();

                nextPosition = transform.position;
                nextPosition.x += direction.x * moveSpeed * Time.deltaTime;
                nextPosition.y += direction.y * moveSpeed * Time.deltaTime;

                GameManager.s_Singleton.VerifyDistance(nextPosition, transform);

                if (GameManager.s_Singleton.shorterNextDistance > perfectDistance)
                {
                    transform.position = nextPosition;
                }
                else if (GameManager.s_Singleton.shorterNextDistance <= perfectDistance && GameManager.s_Singleton.shorterDistance > perfectDistance)
                {
                    while (GameManager.s_Singleton.shorterDistance > perfectDistance)
                    {
                        nextPosition = transform.position;
                        nextPosition.x += direction.x * Time.deltaTime;
                        nextPosition.y += direction.y * Time.deltaTime;
                        transform.position = nextPosition;

                        GameManager.s_Singleton.GetClosestAtomFromDraggedAtom();
                    }

                    neverAct = false;
                    GameManager.s_Singleton.NullifyDraggedTransform();
                    gameObject.tag = "Untagged";
                    canMove = false;
                    GameManager.s_Singleton.canDragAtome = true;
                }
                else
                {
                    GameManager.s_Singleton.NullifyDraggedTransform();
                    gameObject.tag = "Untagged";
                    canMove = false;
                    GameManager.s_Singleton.canDragAtome = true;
                }
            }
            else if (GameManager.s_Singleton.shorterDistance < perfectDistance)
            {
                direction = GameManager.s_Singleton.closerGameObject.transform.position - transform.position;
                direction = -direction;
                direction.Normalize();

                nextPosition = transform.position;
                nextPosition.x += direction.x * moveSpeed * Time.deltaTime;
                nextPosition.y += direction.y * moveSpeed * Time.deltaTime;

                GameManager.s_Singleton.VerifyDistance(nextPosition, transform);
                Debug.Log("la distance la plus courte actuelle!" + GameManager.s_Singleton.shorterDistance);
                Debug.Log("la distance la plus courte à la prochaine frame!" + GameManager.s_Singleton.shorterNextDistance);

                if (GameManager.s_Singleton.shorterNextDistance < perfectDistance)
                {
                    Debug.Log("Move Fast");

                    transform.position = nextPosition;
                }
                else if (GameManager.s_Singleton.shorterNextDistance >= perfectDistance && GameManager.s_Singleton.shorterDistance < perfectDistance)
                {
                    while (GameManager.s_Singleton.shorterDistance < perfectDistance)
                    {
                        Debug.Log("Move Slow");

                        nextPosition = transform.position;
                        nextPosition.x += direction.x * Time.deltaTime;
                        nextPosition.y += direction.y * Time.deltaTime;
                        transform.position = nextPosition;

                        GameManager.s_Singleton.GetClosestAtomFromDraggedAtom();
                    }

                    neverAct = false;
                    GameManager.s_Singleton.NullifyDraggedTransform();
                    gameObject.tag = "Untagged";
                    canMove = false;
                    GameManager.s_Singleton.canDragAtome = true;
                }
                else
                {
                    GameManager.s_Singleton.NullifyDraggedTransform();
                    gameObject.tag = "Untagged";
                    canMove = false;
                    GameManager.s_Singleton.canDragAtome = true;
                }
            }
            else
            {
                GameManager.s_Singleton.NullifyDraggedTransform();
                gameObject.tag = "Untagged";
                canMove = false;
                GameManager.s_Singleton.canDragAtome = true;
            }
        }
    }
}