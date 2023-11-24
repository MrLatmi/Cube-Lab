using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : MonoBehaviour
{
    private Vector3 destinationPoint;
    public float smoothing;
    public GameObject door;
    private float yPos;
    private bool oupenDoor = false;
    public float oupenPOS;

    public AudioSource musicAudio;
    private AudioClip clip;

    private float xPos;
    private float zPos;


    // Start is called before the first frame update
    void Start()
    {
        yPos = door.transform.position.y;
        xPos = door.transform.position.x;
        zPos = door.transform.position.z;

        destinationPoint = new Vector3(xPos, yPos, zPos);

        clip = musicAudio.clip;
    }

    // Update is called once per frame
    void Update()
    {

        door.transform.position = Vector3.Lerp(door.transform.position, destinationPoint, smoothing * Time.deltaTime);


        if (oupenDoor == true)
        {
            destinationPoint = new Vector3(xPos - oupenPOS, yPos, zPos);

        }

        if (oupenDoor == false)
        {
            destinationPoint = new Vector3(xPos, yPos, zPos);

        }

    }

    private void OnTriggerEnter(Collider other)
    {

        musicAudio.PlayOneShot(clip);
        oupenDoor = true;

    }


    private void OnTriggerExit(Collider other)
    {
        musicAudio.PlayOneShot(clip);
        oupenDoor = false;



    }

}