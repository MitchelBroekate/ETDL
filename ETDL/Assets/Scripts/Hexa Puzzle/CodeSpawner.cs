using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class CodeSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject objectToSpawn;

    [SerializeField]
    PosterBehaviour pB;

    //Spawns the grabbed object and sets the new code
    [System.Obsolete]
    void OnGrab(SelectEnterEventArgs args)
    {
        XRBaseInteractor interactor = args.interactorObject as XRBaseInteractor;

        if (interactor != null && objectToSpawn != null)
        {
            GameObject spawned = Instantiate(objectToSpawn, interactor.transform.position, interactor.transform.rotation);
            CodeBehaviour cB = spawned.GetComponent<CodeBehaviour>();
            cB.Hexacode = pB.hexacode.text.ToString();
            cB.HexacodeText.text = cB.Hexacode;

            StartCoroutine(SelectInHand(interactor, spawned));
        }
    }

    //Sets the object in the grabbed hand position
    [System.Obsolete]
    IEnumerator SelectInHand(XRBaseInteractor interactor, GameObject spawnedObject)
    {
        yield return null;

        XRGrabInteractable interactable = spawnedObject.GetComponent<XRGrabInteractable>();
        if (interactable != null)
        {
            interactor.interactionManager.SelectEnter(interactor, interactable);
        }
    }

    //enables a listener
    [System.Obsolete]
    void OnEnable()
    {
        GetComponent<XRGrabInteractable>().selectEntered.AddListener(OnGrab);
    }

    //disables a listener
    [System.Obsolete]
    void OnDisable()
    {
        GetComponent<XRGrabInteractable>().selectEntered.RemoveListener(OnGrab);
    }
}