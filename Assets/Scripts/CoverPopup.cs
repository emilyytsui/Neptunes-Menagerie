using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CoverPopup : MonoBehaviour
{
    [SerializeField] Button startGame;

    public void OpenCover()
    {
        gameObject.SetActive(true);
    }

    public void CloseCover()
    {
        gameObject.SetActive(false);
    }
}
