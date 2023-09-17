using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinManager1 : MonoBehaviour
{
    public static SkinManager1 Instance;

    [SerializeField] private SSkinInfo[] allSkins;
    public static Sprite equippedSkin { get; private set; }

    private const string skinPref = "skinPref";

    [SerializeField] private Transform skinsInShopPanelsParent;
    [SerializeField] private List<SkininShop1> skinsInShopPanels = new List<SkininShop1>();//SFD

    private Button currentlyEquippedSkinButton;



    private void Awake()
    {
        Instance = this;

        foreach (Transform s in skinsInShopPanelsParent)
        {
            if (s.TryGetComponent(out SkininShop1 skininShop))
                skinsInShopPanels.Add(skininShop);
        }

        EquipPreviousSkin();

        SkininShop1 skinEquippedPanel = Array.Find(skinsInShopPanels.ToArray(), dummyFind => dummyFind._skinInfo._skinSprite == equippedSkin);
        currentlyEquippedSkinButton = skinEquippedPanel.GetComponentInChildren<Button>();
        currentlyEquippedSkinButton.interactable = false;
    }

    private void EquipPreviousSkin()
    {


        string lastSkinUsed = PlayerPrefs.GetString(skinPref, SSkinInfo.SkinIDs.cubuk3.ToString());
        SkininShop1 skinEquippedPanel = Array.Find(skinsInShopPanels.ToArray(), dummyFind => dummyFind._skinInfo._skinID.ToString() == lastSkinUsed);
        EquipSkin1(skinEquippedPanel);
    }

    public void EquipSkin1(SkininShop1 skinInfoInShop)
    {
        equippedSkin = skinInfoInShop._skinInfo._skinSprite;
        PlayerPrefs.SetString(skinPref, skinInfoInShop._skinInfo._skinID.ToString());

        if (currentlyEquippedSkinButton != null)
            currentlyEquippedSkinButton.interactable = true;

        currentlyEquippedSkinButton = skinInfoInShop.GetComponentInChildren<Button>();
        currentlyEquippedSkinButton.interactable = false;
    }

}