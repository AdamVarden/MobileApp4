using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject explosion;
    [SerializeField] float loadDelay = 2.0f;

    private void OnTriggerEnter(Collider other) {
        SendMessage("HasDied");
        RunDeathSequence();

        Invoke("ReloadScene", loadDelay);
    }

    private void RunDeathSequence()
    {
        GameObject fx = Instantiate(explosion,transform.position,Quaternion.identity);
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}