using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoEditorManager : MonoBehaviour
{
    [SerializeField] List<GameObject> clipList = new();
    [SerializeField] List<GameObject> placementList = new();
    [SerializeField] List<Transform> clipSpawnPos = new();
    List<Transform> clipSpawnChecks = new();
    List<GameObject> clipFinishedList = new();

    [SerializeField]
    Transform clipFinishedPosition;

    [SerializeField]
    GameObject codePiece;
    [SerializeField]
    Transform codeSpawn;

    public GameObject selectedClip;
    public int clipsPlaced = 0;

    //Clips get put in a random order.
    void Start()
    {
        SetClipSpawnPlacements();
    }

    void SetClipSpawnPlacements()
    {
        foreach (Transform spawnPos in clipSpawnPos)
        {
            clipSpawnChecks.Add(spawnPos);
        }

        foreach (GameObject clip in clipList)
        {
            int randomSpawnPos = Random.Range(0, clipSpawnChecks.Count);

            GameObject currentClip = Instantiate(clip, clipSpawnChecks[randomSpawnPos], false);
            currentClip.transform.localScale = new Vector3(2,2,2);

            clipSpawnChecks.RemoveAt(randomSpawnPos);
        }
    }

    public void CheckClipsPlaced()
    {
        if (clipsPlaced == 3)
        {
            //play video in order that was chosen
            clipFinishedPosition.GetChild(0).gameObject.SetActive(false);
            PlayClipsInOrder();
        }
    }

    void PlayClipsInOrder()
    {
        foreach (Transform parent in clipSpawnPos)
        {
            ClipSelection currentClipSelection = parent.GetChild(0).gameObject.GetComponent<ClipSelection>();

            clipFinishedList.Insert(currentClipSelection.ClipValue, parent.GetChild(0).gameObject);
        }

        StartCoroutine(clipFinishedPlay());
    }

    IEnumerator clipFinishedPlay()
    {
        foreach (GameObject clips in clipFinishedList)
        {
            clips.transform.position = clipFinishedPosition.position;

            clips.GetComponent<VideoPlayer>().Play();

            yield return new WaitForSeconds(1);

            clips.SetActive(false);
        }

        //check if clips are in the right place
        foreach (Transform clipParent in clipSpawnPos)
        {
            ClipSelection currentClipValues = clipParent.GetChild(0).gameObject.GetComponent<ClipSelection>();

            //if wrong reset vars
            if (currentClipValues.ClipPos != currentClipValues.ClipValue)
            {
                clipsPlaced = 0;

                foreach (Transform parentObject in clipSpawnPos)
                {
                    Destroy(parentObject.GetChild(0).gameObject);
                }

                foreach (GameObject placementButton in placementList)
                {
                    placementButton.gameObject.SetActive(true);
                }

                SetClipSpawnPlacements();

                //Lose fx
            }
            else
            {
                //Spawn code piece
                Instantiate(codePiece, codeSpawn);
                //win fx
            }
        }
    }
}