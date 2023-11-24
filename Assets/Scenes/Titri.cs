using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Titri : MonoBehaviour
{
    [SerializeField] private float TimeTitri;

    void Update()
    {
        StartCoroutine(Scene());
    }

    IEnumerator Scene()
    {
        yield return new WaitForSeconds (TimeTitri);

        SceneManager.LoadScene(0);
    }
}
