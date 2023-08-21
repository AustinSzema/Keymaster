using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneAfterDelay : MonoBehaviour
{

    [SerializeField] private ParticleSystem _confettiParticles;
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
        if (!_confettiParticles.isPlaying)
        {
            _confettiParticles.Play();
        }
        yield return new WaitForSeconds(_confettiParticles.main.duration);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}