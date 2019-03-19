using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementController : MonoBehaviour
{
    // On déclare toutes les variables!
    bool isMouseDragging;
    
    public int forbidenShortDistance;
    public int forbidenLongDistance;
    private float saveShorterDistance;

    public Vector2 direction = Vector2.zero;
    public int moveSpeed = 0;
    private bool canMove = true;
    private bool moving = false;

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
        if (!UIManager_MenuPause.isPaused && gameObject.tag == "Atomium" && GameManager.s_Singleton.canDragAtome == true)
        {
            isMouseDragging = true;
            GameManager.s_Singleton.GetDraggedTransform(transform);
        }
    }

    private void OnMouseUpAsButton()
    {
        if (!UIManager_MenuPause.isPaused && (GameManager.s_Singleton.shorterDistance >= forbidenShortDistance && GameManager.s_Singleton.shorterDistance <= forbidenLongDistance))
        {
            isMouseDragging = false;
        }
        else if(!UIManager_MenuPause.isPaused)
        {
            isMouseDragging = false;
            moving = true;
        }
    }

    private void MoveToGoodPos()
    {
        if (moving == true && canMove == true)
        {
            GameManager.s_Singleton.canDragAtome = false;

            if (GameManager.s_Singleton.shorterDistance >= forbidenLongDistance)
            {
                saveShorterDistance = GameManager.s_Singleton.shorterDistance;

                direction = GameManager.s_Singleton.closerGameObject.transform.position - transform.position;

                direction.Normalize();

                Vector2 pos = transform.position;

                pos.x += direction.x * moveSpeed * Time.deltaTime;
                pos.y += direction.y * moveSpeed * Time.deltaTime;

                transform.position = pos;

                direction = Vector2.zero;
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