using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class ClipSelection : MonoBehaviour
{
    VideoEditorManager _videoEditorManager;
    [SerializeField] int _clipValue;
    [SerializeField] VideoPlayer videoPlayer;
    int _clipPos;

    void Start()
    {
        _videoEditorManager = GameObject.Find("Managers").transform.GetChild(2).GetComponent<VideoEditorManager>();
    }

    public void ClipSelected()
    {
        StopAllCoroutines();
        transform.GetChild(0).gameObject.SetActive(true);

        _videoEditorManager.selectedClip = gameObject;
        StartCoroutine(DisableChild());
    }

    //Gets/sets the current position of the clip in the editor
    public int ClipPos
    {
        get { return _clipPos; }
        set { _clipPos = value; }
    }

    //Gets/sets the order value of the clip
    public int ClipValue
    {
        get { return _clipValue; }
        set { _clipValue = value; }
    }

    //Hardfix
    IEnumerator DisableChild()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        videoPlayer.Play();

        yield return new WaitForSeconds(6);
        videoPlayer.Stop();

        transform.GetChild(0).gameObject.SetActive(true);
    }
}
