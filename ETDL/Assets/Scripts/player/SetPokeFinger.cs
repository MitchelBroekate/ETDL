using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SetPokeFinger : MonoBehaviour
{
    public Transform pokeAttachPoint;
    XRPokeInteractor _xRPokeInteractor;

    void Start()
    {
        _xRPokeInteractor = transform.parent.GetChild(0).GetComponent<XRPokeInteractor>();
        SetPokeAttachPoint();
    }

    void SetPokeAttachPoint()
    {
        _xRPokeInteractor.attachTransform = pokeAttachPoint;
    }
}
