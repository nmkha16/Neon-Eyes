using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDescriptionOnHover : MonoBehaviour
{
    public GameObject descriptionTxt;

    private void Start()
    {
        descriptionTxt.SetActive(false);
    }


    public void displayDescription()
    {
        descriptionTxt.SetActive(true);
    }

    public void closeDescription()
    {
        descriptionTxt.SetActive(false );
    }
}
