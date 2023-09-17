using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SkinManager4 : MonoBehaviour
{
    public static SkinManager4 Instance;

    [SerializeField] private SSkinInfo[] allSkins;
    public static Sprite equippedSkin { get; private set; }

    private const string skinPref = "skinPref";

    [SerializeField] private Transform skinsInShopPanelsParent;
    [SerializeField] private List<SkininShop4> skinsInShopPanels = new List<SkininShop4>();//SFD

    private Button currentlyEquippedSkinButton;



    private void Awake()
    {
        Instance = this;

        foreach (Transform s in skinsInShopPanelsParent)
        {
            if (s.TryGetComponent(out SkininShop4 skininShop))
                skinsInShopPanels.Add(skininShop);
        }

        EquipPreviousSkin();

        SkininShop4 skinEquippedPanel = Array.Find(skinsInShopPanels.ToArray(), dummyFind => dummyFind._skinInfo._skinSprite == equippedSkin);
        currentlyEquippedSkinButton = skinEquippedPanel.GetComponentInChildren<Button>();
        currentlyEquippedSkinButton.interactable = false;
    }

    private void EquipPreviousSkin()
    {


        string lastSkinUsed = PlayerPrefs.GetString(skinPref, SSkinInfo.SkinIDs.cubuk2.ToString());
        SkininShop4 skinEquippedPanel = Array.Find(skinsInShopPanels.ToArray(), dummyFind => dummyFind._skinInfo._skinID.ToString() == lastSkinUsed);
        EquipSkin(skinEquippedPanel);
    }

    public void EquipSkin(SkininShop4 skinInfoInShop)
    {
        equippedSkin = skinInfoInShop._skinInfo._skinSprite;
        PlayerPrefs.SetString(skinPref, skinInfoInShop._skinInfo._skinID.ToString());

        if (currentlyEquippedSkinButton != null)
            currentlyEquippedSkinButton.interactable = true;

        currentlyEquippedSkinButton = skinInfoInShop.GetComponentInChildren<Button>();
        currentlyEquippedSkinButton.interactable = false;
    }

}
