using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AiCodeManager : MonoBehaviour
{
    [SerializeField]
    TMP_Text aiText1, aiText2;

    [SerializeField]
    Timer timer;

    AiCodePiece currentAICode;



    int completedCodePiece;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "AiPiece")
        {
            currentAICode = other.GetComponent<AiCodePiece>();

            if (completedCodePiece == 0)
            {
                aiText1.text = currentAICode.codeText.text;
            }
            else if (completedCodePiece == 1)
            {
                aiText2.text = currentAICode.codeText.text;
            }

            Destroy(other.gameObject);

            completedCodePiece++;


            if (completedCodePiece >= 2)
            {
                StartCoroutine(AICompletion());
            }
        }
    }

    IEnumerator AICompletion()
    {
        timer.gameWon = true;

        yield return new WaitForSeconds(3);

        //AI shutdown/Open doors

        
    }
}