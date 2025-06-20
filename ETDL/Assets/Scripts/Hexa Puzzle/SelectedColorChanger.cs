using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectedColorChanger : MonoBehaviour
{
    string currentCode;

    [SerializeField]
    Image currentHexColorVisual, wrongColor;


    [SerializeField]
    TMP_Text hexcode;

    [SerializeField]
    GameObject ParentLogo;

    [SerializeField]
    GameObject codePiece;
    [SerializeField]
    Transform codeSpawn;

    bool _winOnce = false;

    [Header("Audio")]
    AudioSource correctSource;
    public AudioClip[] correctSounds;

    private void Start()
    {
        correctSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CodePiece")
        {
            currentCode = other.GetComponent<CodeBehaviour>().Hexacode;

            if (currentCode == null) return;

            hexcode.text = currentCode;

            ColorUtility.TryParseHtmlString("#" + currentCode, out Color correctColorHex);

            currentHexColorVisual.color = correctColorHex;

            Destroy(other.gameObject);
        }
    }

    public void ConfirmColor()
    {
        if (currentCode == null || _winOnce) return;

        //change wrong color
        ColorUtility.TryParseHtmlString("#" + currentCode, out Color correctColorHex);
        wrongColor.color = correctColorHex;

        if (currentCode == "FA6805")
        {
            correctSource.clip = correctSounds[0];
            correctSource.Play();

            StartCoroutine(CorrectColorWin());

            _winOnce = true;
        }
        else
        {
            correctSource.clip = correctSounds[1];
            correctSource.Play();

            Debug.Log("Wrong Code");
        }
    }

    IEnumerator CorrectColorWin()
    {
        yield return new WaitForSeconds(3);
        ParentLogo.SetActive(false);

        Instantiate(codePiece, codeSpawn.position, codeSpawn.rotation);
    }
}