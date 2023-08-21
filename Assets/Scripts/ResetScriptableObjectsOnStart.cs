using UnityEngine;

public class ResetScriptableObjectsOnStart : MonoBehaviour
{
    [SerializeField] private IntVariable _keyCount;
    [SerializeField] private BoolVariable _playerCanMove;
    void Start()
    {
        _keyCount.Value = 0;
        _playerCanMove.Value = true;
    }
}
