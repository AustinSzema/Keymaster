using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using Unity.VisualScripting;
using UnityEngine;

public class KeyPressDetector : MonoBehaviour
{

    // This class will detect special keys like backspace, enter, space, shift, etc.
    // This class also adds the inputted key to the main string
    // When checking for key commands, use the MainString to check if there is a valid command
    // don't try and detect if a command has been typed through the key

    [SerializeField] private StringVariable _mainString;

    private int _cursorPos = 1;

    // testing dictionaries, has not functionality atm
    private Dictionary<KeyCode, string> _keyValuePairs = new Dictionary<KeyCode, string>();
    private void Start()
    {
        _keyValuePairs.Add(KeyCode.Space, "space");
    }

    void Update()
    {

        Debug.Log("input string " + Input.inputString);

        // this is some dumb shit right here
        // we only need alphas and backspace
        // TODO: REFACTOR
        foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(key))
            {

                switch (key)
                {                    
                    case KeyCode.Backspace:
                        if(_mainString.Value.Length > 0)
                        {
                            _mainString.Value = _mainString.Value.Remove(_mainString.Value.Length - 1);
                        }
                        break;
                    default:
                        if(key.ToString().Length == 1 && char.IsLetter(key.ToString().ToCharArray()[0]))
                        {
                            AddKeyToMainString(key);
                        }
                        break;
                }
            }
        }
    }

    private void AddKeyToMainString(KeyCode key)
    {
        _mainString.Value += key;
    }
}
