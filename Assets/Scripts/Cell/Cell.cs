using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;

public class Cell : MonoBehaviour
{
    [Range(1,100)]
    [SerializeField] private int _maxDeep;

    private int _leftToDig;

    [Range(1,100)]
    [SerializeField] private float _chanceToDrop;

    [SerializeField] private GameObject _ingot;

    public UnityAction OnGoldPickUp;
    public UnityAction<Cell> OnCellClick;
    public UnityAction<int> OnCellDig;

    public bool HasIngot = false;

    private void OnMouseUp()
    {
        if (HasIngot)
        {
            IngotState(false);
            OnGoldPickUp?.Invoke();
        }
        
        else
            OnCellClick?.Invoke(this);    
    }

    private void Start()
    {
        _leftToDig = _maxDeep;
        OnCellDig?.Invoke(_leftToDig);
    }

    public void DigCell()
    {
        if (_leftToDig > 0)
        {
            _leftToDig--;

            if (100f * Random.Range(0f, 1f) <= _chanceToDrop)
                IngotState(true);

            OnCellDig?.Invoke(_leftToDig);        
        }    
    }

    private void IngotState(bool flag)
    {
        HasIngot = flag;
        _ingot.SetActive(flag);
    }

    public bool CanDig()
    {
        return _leftToDig > 0;
    }
}
