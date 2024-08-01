using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrickJudgerController : MonoBehaviour
{
    public Image goodTrick;
    public Image badTrick;
    public float popUpLength;

    // Start is called before the first frame update
    void Start()
    {
        goodTrick.gameObject.SetActive(false); //disables the GoodTrick image
        badTrick.gameObject.SetActive(false);
    }

    // Update is called once per frame
    public IEnumerator ShowGoodTrick()
    {
        goodTrick.gameObject.SetActive(true); // enables the trick image for the alloted time
        yield return new WaitForSeconds(popUpLength);
        goodTrick.gameObject.SetActive(false);// disables the image after the alloted time
    }
    public IEnumerator ShowBadTrick()
    {
        badTrick.gameObject.SetActive(true); // enables the trick image for the alloted time
        yield return new WaitForSeconds(popUpLength);
        badTrick.gameObject.SetActive(false); //disables the image after the alloted time
    }
}
