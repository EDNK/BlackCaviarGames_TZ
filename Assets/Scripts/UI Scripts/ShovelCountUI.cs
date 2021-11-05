using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ShovelCountUI : MonoBehaviour
{
    [SerializeField] private Player _player;
    private TextMeshProUGUI _shovelCount;

    private void Start()
    {
        _shovelCount = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        _player.ShovelCountChanged += SetShovelCount;
    }

    private void OnDisable()
    {
        _player.ShovelCountChanged -= SetShovelCount;
    }

    private void SetShovelCount(int value)
    {
        _shovelCount.SetText(value.ToString());
    }
}
