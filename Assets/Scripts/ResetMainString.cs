using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetMainString : MonoBehaviour
{
    [SerializeField] private StringVariable _mainString;

    // Start is called before the first frame update
    void Start()
    {
        _mainString.Value = "";
            
    }

}
