using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LockKeyCounter : MonoBehaviour
{
    [SerializeField] private TextMeshPro _keyCounter;
    [SerializeField] private IntVariable _keyCount;

    // Update is called once per frame
    void Update()
    {
        _keyCounter.text = _keyCount.Value.ToString();
    }
}
