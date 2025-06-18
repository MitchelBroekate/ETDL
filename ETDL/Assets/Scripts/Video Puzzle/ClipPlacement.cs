using UnityEngine;

public class ClipPlacement : MonoBehaviour
{
    [SerializeField] VideoEditorManager _videoEditorManager;
    [SerializeField] int clipPos;

    public void PlaceClip()
    {
        if (_videoEditorManager.selectedClip != null)
        {
            _videoEditorManager.selectedClip.transform.position = transform.position;

            _videoEditorManager.selectedClip.GetComponent<ClipSelection>().ClipPos = clipPos;

            _videoEditorManager.clipsPlaced++;

            _videoEditorManager.CheckClipsPlaced();

            _videoEditorManager.selectedClip = null;
            
            gameObject.SetActive(false);
        }
    }
}
