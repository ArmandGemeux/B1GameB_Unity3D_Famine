using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementController : MonoBehaviour
{
    // On déclare toutes les variables!
    bool isMouseDragging;
    
    private float perfectDistance;
    private int atomeRange;

    private Vector2 direction = Vector2.zero;
    public float moveSpeed = 0f;
    public bool canMove = true;
    public bool moving = false;
    public bool neverAct = true;

    public float verfiedDistance;

    private Vector2 nextPosition;

    public int linksQuantity;
    public int scoreByLink;

    void Start()
    {
        AddInList(); // Ajoute l'atome possédant le script à une liste dans le GameManager.
        perfectDistance = GameManager.s_Singleton.perfectDistanceAbs;
        atomeRange = GameManager.s_Singleton.maxAtomeRange;
    }

    void Update()
    {
        if (isMouseDragging)  // Déplace l'atome du script à la position de la souris.
        {
            Vector3 mPos = Input.mousePosition;
            mPos.z = 10f;
            mPos = Camera.main.ScreenToWorldPoint(mPos);
            transform.position = mPos;
            Debug.Log(transform.position);
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
            GameManager.s_Singleton.DistanceToGoodAtome();

            if (GameManager.s_Singleton.shorterDistance > perfectDistance && GameManager.s_Singleton.shorterDistance < atomeRange)
            {
                direction = GameManager.s_Singleton.closerGameObject.transform.position - transform.position;

                direction.Normalize();

                nextPosition = transform.position;
                nextPosition.x += direction.x * moveSpeed * Time.deltaTime;
                nextPosition.y += direction.y * moveSpeed * Time.deltaTime;

                GameManager.s_Singleton.VerifyDistance(nextPosition, transform);
                GameManager.s_Singleton.VerifyDistanceToGoodAtome(nextPosition, transform);

                if (GameManager.s_Singleton.shorterNextDistance > perfectDistance)
                {
                    transform.position = nextPosition;

                    GameManager.s_Singleton.DistanceToGoodAtome();

                    if(GameManager.s_Singleton.shorterTrueDistance < perfectDistance)
                    {
                        direction = GameManager.s_Singleton.closerTrueGameObject.transform.position - transform.position;
                        direction = -direction;
                        direction.Normalize();

                        nextPosition = transform.position;
                        nextPosition.x += direction.x * moveSpeed * Time.deltaTime;
                        nextPosition.y += direction.y * moveSpeed * Time.deltaTime;

                        transform.position = nextPosition;
                    }
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
                        GameManager.s_Singleton.DistanceToGoodAtome();
                    }

                    neverAct = false;
                    GameManager.s_Singleton.NullifyDraggedTransform();
                    gameObject.tag = "Untagged";
                    canMove = false;
                    GameManager.s_Singleton.canDragAtome = true;
                    GameManager.s_Singleton.DelAtome(transform);
                }
                else
                {
                    GameManager.s_Singleton.NullifyDraggedTransform();
                    gameObject.tag = "Untagged";
                    canMove = false;
                    GameManager.s_Singleton.canDragAtome = true;
                    GameManager.s_Singleton.DelAtome(transform);
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
                GameManager.s_Singleton.VerifyDistanceToGoodAtome(nextPosition, transform);

                if (GameManager.s_Singleton.shorterNextDistance < perfectDistance)
                {
                    transform.position = nextPosition;
                }
                else if (GameManager.s_Singleton.shorterNextDistance >= perfectDistance && GameManager.s_Singleton.shorterDistance < perfectDistance)
                {
                    while (GameManager.s_Singleton.shorterDistance < perfectDistance)
                    {
                        nextPosition = transform.position;
                        nextPosition.x += direction.x * Time.deltaTime;
                        nextPosition.y += direction.y * Time.deltaTime;
                        transform.position = nextPosition;

                        GameManager.s_Singleton.GetClosestAtomFromDraggedAtom();
                        GameManager.s_Singleton.DistanceToGoodAtome();
                    }

                    neverAct = false;
                    GameManager.s_Singleton.NullifyDraggedTransform();
                    gameObject.tag = "Untagged";
                    canMove = false;
                    GameManager.s_Singleton.canDragAtome = true;
                    GameManager.s_Singleton.DelAtome(transform);
                }
                else
                {
                    GameManager.s_Singleton.NullifyDraggedTransform();
                    gameObject.tag = "Untagged";
                    canMove = false;
                    GameManager.s_Singleton.canDragAtome = true;
                    GameManager.s_Singleton.DelAtome(transform);
                }
            }
            else
            {
                Debug.Log("Je retourne dans ma boite!");

                
            }
        }
    }
}