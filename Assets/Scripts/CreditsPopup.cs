using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CreditsPopup : MonoBehaviour
{
    [SerializeField] TMP_Text creditTitle;
    [SerializeField] TMP_Text labels;
    [SerializeField] TMP_Text names;
    [SerializeField] Button settings;

    public void OpenCredits()
    {
        gameObject.SetActive(true);
    }

    public void CloseCredits()
    {
        gameObject.SetActive(false);
    }
}
