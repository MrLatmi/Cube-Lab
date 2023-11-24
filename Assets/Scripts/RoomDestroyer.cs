using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoomDestroyer : MonoBehaviour
{

    public AudioSource musicAudio;
    private AudioClip clip;

    [SerializeField] private List<GameObject> cubes;
    public List<Rigidbody> _rbCubes;
    private int _countOfMasElements;
    private int _counter;


    private void Start()
    {
        clip = musicAudio.clip;


        foreach (var gameObj in cubes)
        {
            if (gameObj.GetComponent<Rigidbody>())
            {
                _rbCubes.Add(gameObj.GetComponent<Rigidbody>());
            }
        }

        _countOfMasElements = _rbCubes.Count;
    }

    private void OnTriggerEnter(Collider other)
    {
        

        if (_counter < _countOfMasElements)
        {   
            musicAudio.PlayOneShot(clip);
            _rbCubes[_counter].isKinematic = false;
            _counter += 1;

        }

    }
}
