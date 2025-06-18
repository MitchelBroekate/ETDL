using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    [SerializeField]
    Timer timer;
    [SerializeField]
    GameObject canvas;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (timer.gameWon)
            {
                canvas.SetActive(true);

                Time.timeScale = 0;
            }
        }
    }
}
