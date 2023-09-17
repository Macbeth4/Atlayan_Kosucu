using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SkininShop1 : MonoBehaviour
{
    [SerializeField] private SSkinInfo skinInfo;
    public SSkinInfo _skinInfo { get { return skinInfo; } }

    [SerializeField] private TextMeshProUGUI buttonText;
    [SerializeField] private Image skinImage;

    [SerializeField] private bool isSkinUnlocked;//SFD

    [SerializeField] private bool isFreeSkin;

    public GameObject skinPrefab;

    private void Awake()
    {
        skinImage.sprite = skinInfo._skinSprite;

        if (isFreeSkin)
        {
            if (PlayerMoney.Instance.TryRemoveMoney(0))
            {
                PlayerPrefs.SetInt(skinInfo._skinID.ToString(), 1);
            }
        }

        IsSkinUnlocked();
    }

    private void IsSkinUnlocked()
    {
        if (PlayerPrefs.GetInt(skinInfo._skinID.ToString()) == 1)
        {
            isSkinUnlocked = true;
            buttonText.text = "OYNA";
        }
        else
        {
            buttonText.text = "SATIN AL: " + skinInfo._skinPrice;
        }
    }

    public void OnButtonPress()
    {
        if (isSkinUnlocked)
        {

            //equip
            GameObject skin = Instantiate(skinPrefab);
            SceneManager.LoadScene(3);
        }
        else
        {

            //buy
            if (PlayerMoney.Instance.TryRemoveMoney(skinInfo._skinPrice))
            {

                PlayerPrefs.SetInt(skinInfo._skinID.ToString(), 1);
                IsSkinUnlocked();

            }

        }
    }

}