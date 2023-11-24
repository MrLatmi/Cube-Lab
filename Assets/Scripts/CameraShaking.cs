using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CameraShaking : MonoBehaviour
{
    [SerializeField] private float duration;
    [SerializeField] private GameObject cameraObject;
    private Vector3 _cameraOriginPosition;
    private void Update()
    {
        _cameraOriginPosition = cameraObject.transform.position;
    }

    IEnumerator _Shake()
    {

        float xCameraCoordinate;
        float yCameraCoordinate;
        float timeLeft = Time.time;

        while ((timeLeft + duration) > Time.time)
        {
            xCameraCoordinate = Random.Range(-0.1f, 0.1f);
            yCameraCoordinate = Random.Range(-0.1f, 0.1f);

            cameraObject.transform.position = new Vector3(cameraObject.transform.position.x + xCameraCoordinate, cameraObject.transform.position.y + yCameraCoordinate, cameraObject.transform.position.z); yield return new WaitForSeconds(0.025f);
        }

        cameraObject.transform.position = _cameraOriginPosition;

    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(_Shake());
    }
}