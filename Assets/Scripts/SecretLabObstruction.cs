using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Composites;

public class SecretLabObstruction : MonoBehaviour
{
    public AudioSource draggingSound;
    public bool isDragging;
    public bool isOpenning;
    public float draggingForce = 0.8f;
    public float dragDuration = 2f;
    public float timer = 0;

    void Start(){
        isOpenning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDragging) {
            Vector3 currentPos = gameObject.transform.position;
            if (isOpenning) gameObject.transform.SetPositionAndRotation(new Vector3(currentPos.x, currentPos.y, currentPos.z + draggingForce * Time.deltaTime), gameObject.transform.rotation);
            else gameObject.transform.SetPositionAndRotation(new Vector3(currentPos.x, currentPos.y, currentPos.z - draggingForce * Time.deltaTime), gameObject.transform.rotation);
            
            timer += Time.deltaTime;
            if (timer > dragDuration){
                timer = 0;
                isDragging = false;
                draggingSound.Stop();
            }
        }
    }

    public void OnLeverActive(){
        isDragging = true;
        draggingSound.Play();
    }
    public void OnLeverDeactive(){
        isOpenning = !isOpenning;
    }

    void OnDestroy(){
        draggingSound.Stop();
    }
}
