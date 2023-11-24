using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    public Transform cameraTransform = default;
    private Vector3 _originalPosOfCam = default;
    public float shakeFrequency = default;
    private bool _isShaking = false;
    private float _shakeDuration = 5.0f;
    public float _shakeTimer = 0.0f;
    public GameObject[] objectsToApplyRigidbody;

    void Start()
    {
        _originalPosOfCam = cameraTransform.position;
    }

    void Update()
    {
        if (_isShaking)
        {
            CameraShake();
            _shakeTimer += Time.deltaTime;
            if (_shakeTimer >= _shakeDuration)
            {
                _isShaking = false;
                _shakeTimer = 0.0f;
                StopShake();
            }
        }
    }

    private void CameraShake()
    {
        cameraTransform.position = _originalPosOfCam + Random.insideUnitSphere * shakeFrequency;
    }

    private void StopShake()
    {
        cameraTransform.position = _originalPosOfCam;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isShaking = true;

            foreach (GameObject obj in objectsToApplyRigidbody)
            {
                Rigidbody rb = obj.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = false;
                }
            }

            destructionOfTheComplex += 20;
        }
    }

    private int destructionOfTheComplex = 0;
}