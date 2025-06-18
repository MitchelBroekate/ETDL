using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PosterManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> posters = new();

    [SerializeField]
    string correctColor;

    [SerializeField]
    Image wrongColor;

    void Start()
    {
        //Creates a color of the correct hex value
        ColorUtility.TryParseHtmlString(correctColor, out Color correctColorHex);

        //Sets random value for correct hexa color poster
        int CorrectColorInt = Random.Range(0, posters.Count);
        int forEachCheck = 0;

        //Sets the hexa values at random for hexa posters
        foreach (GameObject poster in posters)
        {
            PosterBehaviour pB = poster.GetComponent<PosterBehaviour>();

            //Sets the color code for the correct poster
            if (CorrectColorInt == forEachCheck)
            {
                    pB.hexaColor.color = correctColorHex;
                    pB.hexacode.text = "FA6805";
            }
            else
            {
                //Creates a random color code
                Color randomColor = new Color
                (
                    Random.value,
                    Random.value,
                    Random.value,
                    1f
                );

                //Sets the color code of the random posters
                pB.hexaColor.color = randomColor;
                pB.hexacode.text = ColorUtility.ToHtmlStringRGB(randomColor);
            }
            forEachCheck++;
        }

        //Creates a random wrong color for the main puzzle (Ultimate small chance for the same color)
        wrongColor.color = new Color
        (
            0,
            Random.value,
            Random.value,
            1f
        );
    }
}
