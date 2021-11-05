using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshPro))]
public class CellDeepUI : MonoBehaviour
{
    private Cell _cell;
    private TextMeshPro _deepText;

    private void Awake()
    {
        _cell = GetComponentInParent<Cell>();
        _deepText = GetComponent<TextMeshPro>();
    }

    private void OnEnable()
    {
        _cell.OnCellDig += OnDig;
    }

    private void OnDisable()
    {
        _cell.OnCellDig -= OnDig;
    }

    private void OnDig(int value)
    {
        _deepText.SetText(value.ToString());
    }

}
