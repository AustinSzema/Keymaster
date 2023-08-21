using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StringTracker : MonoBehaviour
{
    [SerializeField] private TextMeshPro _stringTracker;
    [SerializeField] private StringVariable _mainString;

    // Update is called once per frame
    void Update()
    {
        if(_mainString.Value.Length > 6)
        {
            _mainString.Value = _mainString.Value.Substring(0, 6);
        }
        _stringTracker.text = _mainString.Value;
    }
}
