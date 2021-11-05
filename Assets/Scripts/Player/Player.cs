using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Player : MonoBehaviour
{
    [Range(1, 100)]
    [SerializeField] private int _maxShovelCount;

    [Range(1,100)]
    [SerializeField] private int _goldToReach;

    [SerializeField] private FieldInfo _fieldInfo;

    private int _currentShovelCount;
    private int _currentGoldCount = 0;

    public UnityAction<int> ShovelCountChanged;
    public UnityAction<int> GoldCountChanged;

    public UnityAction<bool> EndOfGame;

    private void OnEnable()
    {
        _fieldInfo.CellClicked += Dig;
        _fieldInfo.GoldCollected += CollectGold;
    }

    private void OnDisable()
    {
        _fieldInfo.CellClicked -= Dig;
        _fieldInfo.GoldCollected -= CollectGold;
    }

    private void Start()
    {
        _currentShovelCount = _maxShovelCount;
        ShovelCountChanged?.Invoke(_currentShovelCount);
        GoldCountChanged?.Invoke(_currentGoldCount);
    }

    private void Dig(Cell cell)
    {
        if (_currentShovelCount > 0)
            if (cell.CanDig())
            {
                cell.DigCell();
                ShovelCountChanged?.Invoke(--_currentShovelCount);
            }

        if (_currentShovelCount == 0 && _currentGoldCount + _fieldInfo.GoldOnField() < _goldToReach)
                EndOfGame?.Invoke(false);
    }

    private void CollectGold()
    {
        GoldCountChanged?.Invoke(++_currentGoldCount);
        
        if (_currentGoldCount == _goldToReach)
            EndOfGame?.Invoke(true);
    }

}
