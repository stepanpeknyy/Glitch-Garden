using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender  defenderPrefab;
    GameObject defenderParent;
    const string DFENDER_PARENT_NAME = "Defenders";

    private void Start()
    {
        CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DFENDER_PARENT_NAME);
        if (!defenderParent)
        {
            defenderParent = new GameObject(DFENDER_PARENT_NAME);
        }
    }


    private void OnMouseDown()
    {
        AttemptToPlaceDefenderAt (GetSquareClicked());
    }
    private Vector2 GetSquareClicked()
    {
        Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos;
    }
    private void SpawnDefender(Vector2 worldPos)
    {
        Defender newDefender = Instantiate(defenderPrefab, worldPos, Quaternion.identity ) as Defender;
        newDefender.transform.parent = defenderParent.transform;
    }
    private Vector2 SnapToGrid (Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }
    public void SetSelectedDefender(Defender defenderToSelect)
    {
        defenderPrefab = defenderToSelect;
    }
    private void AttemptToPlaceDefenderAt(Vector2 gridPos)
    {
        var StarDisplay = FindObjectOfType<StarsDisplay>();
        int defenderCost = defenderPrefab.GetStarCost();
        if (StarDisplay.HaveEnoughStars (defenderCost ))
        {
            SpawnDefender(gridPos);
            StarDisplay.SpendStars(defenderCost );
        }
    }
    
}
