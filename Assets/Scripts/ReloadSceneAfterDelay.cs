using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadSceneAfterDelay : MonoBehaviour
{
    [SerializeField] private ParticleSystem _deathParticles;
    [SerializeField] private BoolVariable _playerCanMove;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _playerCanMove.Value = false;
            StartCoroutine(LoadNextScene());
        }
    }

    IEnumerator LoadNextScene()
    {
        if (!_deathParticles.isPlaying)
        {
            _deathParticles.Play();
        }
        yield return new WaitForSeconds(_deathParticles.main.duration);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}