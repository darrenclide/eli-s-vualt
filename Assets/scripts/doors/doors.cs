using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doors : MonoBehaviour
{
    public bool _isDoorOpen = false;
    Vector3 _doorClosedPos;
    Vector3 _doorOpenPos;
    float _doorSpeed = 1f;
    public AudioSource audioSource;
    public AudioClip door;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void PlaySoundEffect()
    {
        audioSource.PlayOneShot(door, 0.7f); // play audio clip with volume 0.7
    }
    void Awake()
    {
        _doorClosedPos = transform.position;
        _doorOpenPos = new Vector3(transform.position.x, transform.position.y + 1f,transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("k") == true) 
        {
            PlaySoundEffect();
            _isDoorOpen = true;
        }
        else if(Input.GetKey("l") == true)
        {
            PlaySoundEffect();
            _isDoorOpen = false;
        }
        if(_isDoorOpen)
        {
            OpenDoor();
        }
        else if(!_isDoorOpen)
        {
            CloseDoor();
        }
    }
    void OpenDoor()
    {
        if(transform.position != _doorOpenPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, _doorOpenPos, _doorSpeed * Time.deltaTime);
        }
    }
        void CloseDoor()
    {
        if(transform.position != _doorClosedPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, _doorClosedPos, _doorSpeed * Time.deltaTime);
        }
    }
}
