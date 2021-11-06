using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldCreator : MonoBehaviour
{
    [SerializeField] private Cell _cellPrefab;
    
    [Range(1,10)]
    [SerializeField] private int _fieldSize;
    
    [Range(1,1.5f)]
    [SerializeField] private float _distanceBetweenCells;

    private Transform _fieldPoint;

    private List<Cell> _cells;

    private void Awake()
    {
        _fieldPoint = GetComponent<Transform>();
        _cells = new List<Cell>(_fieldSize * _fieldSize);

        for (int i = 0; i < _fieldSize; i++)
            for (int j = 0; j < _fieldSize; j++)
            {
                float x = _distanceBetweenCells * ((float)(-_fieldSize + 1) / 2 + i);
                float y = _distanceBetweenCells * ((float)(_fieldSize - 1) / 2 - j);

                _cells.Add(Instantiate(_cellPrefab, new Vector3(x, y), Quaternion.identity, _fieldPoint));
            }
    }

    public List<Cell> GetAllCells()
    {
        return _cells;
    }
}
