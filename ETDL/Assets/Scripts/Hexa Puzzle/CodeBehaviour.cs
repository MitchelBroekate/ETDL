using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CodeBehaviour : MonoBehaviour
{
    XRGrabInteractable xRGrabInteractable;
    BoxCollider objectCollider;

    [SerializeField]
    TMP_Text hexacodeText;
    string hexacode;

    void Start()
    {
        xRGrabInteractable = GetComponent<XRGrabInteractable>();
        objectCollider = GetComponent<BoxCollider>();
    }

    void OnCollisionEnter(Collision collision)
    {
        //Ground collsision check to despawn code piece
        if (!xRGrabInteractable.isSelected)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                Destroy(gameObject,1);
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

    public TMP_Text HexacodeText
    {
        get { return hexacodeText; }
        set { hexacodeText = value; }
    }

    public string Hexacode
    {
        get { return hexacode; }
        set { hexacode = value; }
    }
}
