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
        _videoEditorManager.selectedClip = gameObject;
        videoPlayer.Play();
    }

    public int ClipPos
    {
        get { return _clipPos; }
        set { _clipPos = value; }
    }
     
    public int ClipValue
    {
        get { return _clipValue; }
        set { _clipValue = value; }
    }
}
