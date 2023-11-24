using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScene : MonoBehaviour
{
    [SerializeField] private int _Scene;

    private void Update()
    {
        if (Input.GetKey(KeyCode.M))
        {
            SceneManager.LoadScene(_Scene);
        }
    }
}
