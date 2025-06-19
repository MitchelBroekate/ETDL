using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AiCodePiece : MonoBehaviour
{
    public TMP_Text codeText;
    public Transform respawnPoint;
    XRGrabInteractable xRGrabInteractable;
    BoxCollider objectCollider;
    Rigidbody rb;

    void Start()
    {
        codeText.text = GetRandomLetter().ToString();
        xRGrabInteractable = GetComponent<XRGrabInteractable>();
        objectCollider = GetComponent<BoxCollider>();

        rb = gameObject.GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        //Ground collsision check to despawn code piece
        if (!xRGrabInteractable.isSelected)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                RespawnObject();
            }
        }
    }

    void FixedUpdate()
    {
        //Layer exclude so object doesnt stick in the wall when grabbed
        if (xRGrabInteractable.isSelected)
        {
            objectCollider.excludeLayers = LayerMask.GetMask("Default");
        }
        else
        {
            objectCollider.excludeLayers = 0;
        }
    }

    void RespawnObject()
    {
        if (respawnPoint == null) return;

        transform.position = respawnPoint.position;
        transform.rotation = Quaternion.Euler(0,-90,0);
    }
    
    Char GetRandomLetter()
    {
        // Random uppercase letter from A (65) to Z (90)
        return (char)UnityEngine.Random.Range(65, 91);
    }
}
