using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class StringReader : MonoBehaviour
{
    [SerializeField] private StringVariable _mainString;

    [SerializeField] private ParticleSystem _explosionParticles;
    [SerializeField] private ParticleSystem _energyParticles;
    [SerializeField] private ParticleSystem _rainbowParticles;

    [SerializeField] private LayerMask _layerMask;

    [SerializeField] private IntVariable _keyCount;

    [SerializeField] private BoolVariable _playerCanMove;

    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Transform _spriteTransform;

    [SerializeField] private GameObject _projectileAttackPrefab;
    
    private string _up = "UP";
    private string _down = "DOWN";
    private string _left = "LEFT";
    private string _right = "RIGHT";
    private string _explode = "KABOOM";
    private string _energy = "BANKAI";
    private string _rainbow = "SLAY";
    private string _start = "START";
    private string _attack = "ATTACK";



    /* TODO:
     * Make it so that the inputs are only registered when the player presses the enter key
     * this should make the code better because you just have to check the most recent word after the last space
     * Basically, index from the last space in the string to the end of the string
     * if that contains a valid keyword, do the input corresponding to that keyword
     * this can use a dictionary or switchs statement or something hopefully, maybe both
     * 
     * Actually we're gonna scratch all of that because it's more fun to just type without pressing enter
     * 
     * 
     * to consider: make it so that it will take the last word in the string, and preserve the rest of the words,
     * so that the user can input a series of commands, then spam enter to have them all act in order
     * it's either gonna be that, or you can only input one word at a time, in which case, pressing enter clears the string
     * I think the first idea is cooler, but the second idea might make more sense to the player and be easier to code
     * 
     * 
     */

    /* TODO:
     * 
     * ~~CHECKAROONIE~~ ADD MOVING ENEMIES
     * ~~CHECKAROONIE~~ ADD DEATH PITS
     * ~~CHECKAROONIE~~ ADD TELEPORTERS
     * ADD PROJECTILE/MELEE ATTACK 
     * TWO DIFFERENT ATTACKS
     * A FAST PROJECTILE AND A MELEE THAT JUST SITS IN FRONT OF THE PLAYER FOR A FEW SECONDS
     * 
    */

    // Define the delegate for the functions you want to store in the dictionary
    public delegate void MyFunctionDelegate();

    // Create the dictionary
    private Dictionary<string, MyFunctionDelegate> _commandDictionary = new Dictionary<string, MyFunctionDelegate>();

    private void Start()
    {
        // Adding functions to the dictionary
        _commandDictionary.Add(_up, MoveUp);
        _commandDictionary.Add(_down, MoveDown);
        _commandDictionary.Add(_left, MoveLeft);
        _commandDictionary.Add(_right, MoveRight);
        _commandDictionary.Add(_rainbow, PlayRainbow);
        _commandDictionary.Add(_energy, PlayEnergy);
        _commandDictionary.Add(_explode, PlayExplosion);
        _commandDictionary.Add(_start, NextScene);
        _commandDictionary.Add(_attack, Attack);
    }

    // one line functions
    private void MoveLeft() => PlayerMove(Vector3.left);
    private void MoveRight() => PlayerMove(Vector3.right);
    private void MoveUp() => PlayerMove(Vector3.up);
    private void MoveDown() => PlayerMove(Vector3.down);
    private void PlayRainbow() => _rainbowParticles.Play();
    private void PlayEnergy() => _energyParticles.Play();
    private void PlayExplosion() => _explosionParticles.Play();

    private void NextScene()
    {
        Debug.Log("next scene");
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Debug.Log("transiitnonig to next scene");
            _commandDictionary.Remove(_start);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    private void Attack()
    {
        if (!_projectileAttackPrefab.activeInHierarchy)
        {
            _projectileAttackPrefab.transform.forward = _spriteTransform.forward;
            _projectileAttackPrefab.transform.position = _spriteTransform.position + Vector3.up;

            _projectileAttackPrefab.SetActive(true);
        }
    }




    // Call the functions from the dictionary using the string key
    private void CallFunction(string functionName)
    {
        // Check if the function exists in the dictionary
        if (_commandDictionary.ContainsKey(functionName))
        {
            // Call the function using the delegate
            _commandDictionary[functionName]();
            ClearString();
        }
    }


    // Update is called once per frame
    void Update()
    {
        CallFunction(_mainString.Value);
    }

    private void PlayerMove(Vector3 direction)
    {
        if (_playerCanMove.Value == true)
        {
            RaycastHit2D hit = Physics2D.Raycast(_playerTransform.position, direction, 1f, _layerMask);

            void Move()
            {
                Vector3 newPosition = _playerTransform.position + direction;
                _playerTransform.position = newPosition;

                if (direction != Vector3.down)
                {
                    _spriteTransform.rotation = Quaternion.Euler(0f, 0f, direction.x * -90f);
                }
                else
                {
                    _spriteTransform.rotation = Quaternion.Euler(0f, 0f, -180f);
                }

            }

            if (hit.collider == null)
            {
                Debug.Log("NULLLLL");
                Move();
            }
            else
            {
                switch (hit.collider.gameObject.tag)
                {
                    case "Wall":
                        break;
                    case "Lock":
                        if (_keyCount.Value > 0)
                        {
                            _keyCount.Value--;
                            hit.transform.gameObject.SetActive(false);
                        }
                        break;
                    default:
                        Move();
                        break;
                }
            }
        }

    }


    // if you just want to remove the command string instead of clearing the entire string
    private void RemoveString(string input)
    {
        _mainString.Value = _mainString.Value.Replace(input, "");
    }

    // clears the main string
    private void ClearString()
    {
        _mainString.Value = "";

    }


}
