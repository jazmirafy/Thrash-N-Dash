using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PopUpController : MonoBehaviour
{
    public Image popUpImage;
    public float popUpWait = 15f; // How often pop-ups happen
    public float popUpLength = 4f; // How long the pop-up stays on the screen

    private void Start()
    {
        popUpImage.gameObject.SetActive(false); // Make sure the pop-up starts off inactive
        StartCoroutine(PopUpRoutine());
    }

    private IEnumerator PopUpRoutine()
    {
        while (true) // This will make the coroutine run indefinitely
        {
            yield return new WaitForSeconds(popUpWait); //waits 15 seconds before starting a coroutine that shows the pop up
            yield return StartCoroutine(ShowPopUp());
        }
    }

    private IEnumerator ShowPopUp()
    {
        popUpImage.gameObject.SetActive(true); //enables the pop up for 3 seconds
        yield return new WaitForSeconds(popUpLength);
        popUpImage.gameObject.SetActive(false); //disables the pop up after 3 seconds
    }
}