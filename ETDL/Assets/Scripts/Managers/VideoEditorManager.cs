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

    [SerializeField]
    Transform clipFinishedPosition;

    [SerializeField]
    GameObject codePiece;
    [SerializeField]
    Transform codeSpawn;

    public GameObject selectedClip;
    public int clipsPlaced = 0;

    GameObject clip1;
    GameObject clip2;

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
            currentClip.transform.localScale = new Vector3(2, 2, 2);

            clipSpawnChecks.RemoveAt(randomSpawnPos);
        }
    }

    public void CheckClipsPlaced()
    {
        if (clipsPlaced == 2)
        {
            //play video in order that was chosen
            clipFinishedPosition.GetChild(0).gameObject.SetActive(false);
            PlayClipsInOrder();
        }
    }
    #region Hard Code Fix
    void PlayClipsInOrder()
    {

            clip1 = clipSpawnPos[0].GetChild(0).gameObject;
            clip2 = clipSpawnPos[1].GetChild(0).gameObject;

        StartCoroutine(clipFinishedPlay());
    }

    IEnumerator clipFinishedPlay()
    {

        yield return new WaitForSeconds(2);

        clip1.transform.position = clipFinishedPosition.position;

        clip1.GetComponent<VideoPlayer>().Play();

        yield return new WaitForSeconds(2);//Clip time

        clip1.SetActive(false);

        clip2.transform.position = clipFinishedPosition.position;

        clip2.GetComponent<VideoPlayer>().Play();

        yield return new WaitForSeconds(2);
        clip2.SetActive(false);


        ClipSelection currentClipValues = clip1.GetComponent<ClipSelection>();

        //if wrong reset vars
        if (currentClipValues.ClipPos != 1)
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
            Instantiate(codePiece, codeSpawn.position, codeSpawn.rotation);
            //win fx
        }
    }
    #endregion
}