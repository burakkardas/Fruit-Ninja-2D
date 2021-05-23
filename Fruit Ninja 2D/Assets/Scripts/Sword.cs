using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public GameObject cutPrefab;
    public float cutLifeTime;

    private bool dragging;
    private Vector2 swipeStart;
    void Start()
    {
        
    }

    
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) {
            dragging = true;
            swipeStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        else if(Input.GetMouseButtonUp(0) && dragging) {
            dragging = false;
            cutSpawner();
        }
    }

    private void cutSpawner() {
        Vector2 swipeEnd = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GameObject cutInstance = Instantiate(cutPrefab, swipeStart, Quaternion.identity);

        cutInstance.GetComponent<LineRenderer>().SetPosition(0, swipeStart);
        cutInstance.GetComponent<LineRenderer>().SetPosition(1, swipeEnd);

        Vector2[] collidePoints = new Vector2[2];
        collidePoints[0] = Vector2.zero;
        collidePoints[1] = swipeEnd - swipeStart;

        cutInstance.GetComponent<EdgeCollider2D>().points = collidePoints;

        Destroy(cutInstance, cutLifeTime);
    }
}
