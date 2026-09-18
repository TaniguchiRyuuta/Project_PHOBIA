using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PJ_PHOBIA
{
    public class ItemManager : MonoBehaviour
    {
        [SerializeField] private GameObject[] Items;
        private List<GameObject> itemList;
        public int CurrentItemID { get; set; } = 0;
        private int previousID;

        [SerializeField] private ItemData initialItem;
        private void Awake()
        {
            itemList = new List<GameObject>();
            itemList.Add(Items[(int)ItemData.Hand]);        //この初期化のやり方は怪しい。変更の余地あり。
            itemList.Add(Items[(int)ItemData.FlashLight]);　//同上

            SetInitialItem((int)initialItem);
        }
        public void AddItem(int ID)
        {
            if (!itemList.Contains(Items[ID]))
                itemList.Add(Items[ID]);
        }
        public void RemoveItem(int ID)
        {
            SwitchItem(-1);
            itemList.Remove(Items[ID]);
            
        }

        public bool ContainsItem(ItemData ID)
        {
            return itemList.Contains(Items[(int)ID]);
        }

        public int GetItemListCount()
        {
            return itemList.Count;
        }
        public void ActivateItem(int target)
        {
            itemList[target].SetActive(true);
        }
        public void DeactivateItem(int target)
        {
            Debug.Log("[ItemManager] DeativateItem");
            itemList[target].SetActive(false);
        }
        public void UseItem(int target)
        {
            itemList[target].GetComponent<EventBehaviour>()?.OnEvent();
        }

        private void SetInitialItem(int ID)
        {
            Debug.Log($"[ItemManager] SetInitialItem {Enum.GetNames(typeof(ItemData))[CurrentItemID]}");
            if (!itemList.Contains(Items[ID]))
            {
                Debug.LogWarning($"[ItemManager] {Enum.GetNames(typeof(ItemData))[ID]}は所持していないアイテムです");
                return;
            }

            DeactivateItem(CurrentItemID);

            ActivateItem(ID);
            CurrentItemID = ID;
        }
        public void SwitchItem(int input)
        {
            previousID = CurrentItemID;

            CurrentItemID += input;

            if (CurrentItemID >= GetItemListCount())
            {
                CurrentItemID = 0;
            }
            else if (CurrentItemID < 0)
            {
                CurrentItemID = GetItemListCount() - 1;
            }

            OnSwitch();
        }
        void OnSwitch()
        {
            DeactivateItem(previousID);
            ActivateItem(CurrentItemID);
        }
    }

   
    
    public enum ItemData
    {
        Hand,
        FlashLight,
        Phone,
        Key,
    }
}