using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(FieldCreator))]
public class FieldInfo : MonoBehaviour
{
    private List<Cell> _cells;

    public UnityAction<Cell> CellClicked;
    public UnityAction GoldCollected;

    private void Start()
    {
        _cells = GetComponent<FieldCreator>().GetAllCells();
        SubscribeOnCells();
    }

    private void SubscribeOnCells()
    {
        foreach (var cell in _cells)
        {
            cell.OnCellClick += CellDigHandler;
            cell.OnGoldPickUp += GoldCollectHandler;
        }
            
    }

    private void OnDisable()
    {
        foreach (var cell in _cells)
        {
            cell.OnCellClick -= CellDigHandler;
            cell.OnGoldPickUp -= GoldCollectHandler;
        }
    }

    public int GoldOnField()
    {
        int ingots = 0;
        
        foreach (var cell in _cells)
            if (cell.HasIngot)
                ingots++;
        
        return ingots;
    }

    private void CellDigHandler(Cell cell)
    {
        CellClicked?.Invoke(cell);
    }

    private void GoldCollectHandler()
    {
        GoldCollected?.Invoke();
    }
}