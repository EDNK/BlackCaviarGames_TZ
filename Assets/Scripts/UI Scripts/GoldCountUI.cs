using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class GoldCountUI : MonoBehaviour
{
    [SerializeField] private Player _player;
    private TextMeshProUGUI _goldCount;

    private void Awake()
    {
        _goldCount = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        _player.GoldCountChanged += SetGoldCount;
    }

    private void OnDisable()
    {
        _player.GoldCountChanged -= SetGoldCount;
    }

    private void SetGoldCount(int value)
    {
        _goldCount.SetText(value.ToString());
    }
}
