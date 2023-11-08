﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using EZInventory;
using Unity.VisualScripting.Antlr3.Runtime.Misc;

namespace EZInventory
{
    public class InventoryManager : MonoBehaviour
    {
        [Tooltip("If true: hides cursor when inventory is closed, freezes time when open.")]
        public bool inventoryPause = true;
        [Tooltip("The main inventory parent, turns on/off with tab")]
        public GameObject inventoryMain;
        [Tooltip("Item image UI that follows cursor")]
        public Image currentItemImage;
        [Tooltip("Item stack text UI that follows cursor")]
        public Text currentItemStackDisplay;
        public Text currentItemName;
        public Text Log;

        public GameObject TrashWindow;
        public Slider TrashAmountSlider;
        public Text TrasjAmountText;
        public static int SelectRemainAmount;
        public static int SlotNumber;


        public static InventoryManager instance;

        public List<InventorySlot> slots;
        public RecipeDataBase _recipeDataBase;

        public static ItemSO currentItem { get; private set; }
        public static int currentItemAmount { get; private set; }


        // Start is called before the first frame update
        void Awake()
        {
            if (instance == null)
                instance = this;

            //Turn on inventory to grab slots, then turn back off.
            if (inventoryMain) inventoryMain.SetActive(true);

            slots = new List<InventorySlot>();
            foreach (InventorySlot slot in GetComponentsInChildren<InventorySlot>())
            {
                if (slot.includeInInventory)
                    slots.Add(slot);
            }

        }

        // Update is called once per frame
        void Update()
        {
            //Set current item to null if stack is 0
            if (currentItemAmount <= 0)
                currentItem = null;

            if (currentItem)
            {
                //Set current held item UI
                currentItemImage.enabled = true;
                currentItemImage.sprite = currentItem.itemSlotSprite;
                currentItemStackDisplay.text = currentItemAmount.ToString();
                currentItemStackDisplay.gameObject.SetActive(true);
                currentItemName.text = currentItem.tooltip;
            }
            else
            {
                //Clear current held item UI
                currentItemImage.enabled = false;
                currentItemName.text = "아이템 선택";
                currentItemStackDisplay.gameObject.SetActive(false);
            }
            Log.text = currentItemImage.enabled.ToString();


            //Make UI follow cursor
            //currentItemImage.transform.position = Input.mousePosition;
        }
        public static bool IsOpen()
        {
            return instance.inventoryMain.activeSelf;
        }

        public static void OpenInventory()
        {
            instance.inventoryMain.SetActive(true);

            if (instance.inventoryPause)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0;
            }
        }

        public static void CloseInventory()
        {

            if (currentItem)
                DropItem(currentItem, currentItemAmount);

            if (instance.inventoryPause)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Time.timeScale = 1;
            }
            instance.inventoryMain.SetActive(false);
        }

        /// <summary>
        /// Add [amount] of [item] to inventory. Automatically checks slots of matching items and stack limits.
        /// Returns 0 if done successfully, otherwise if inventory is full returns leftover of item.
        /// </summary>
        /// <param name="item">What item to add</param>
        /// <param name="amount">How many of the item to add</param>
        /// <returns></returns>
        public int AddItemToInventory(ItemSO item, int amount)
        {
            int remaining = amount;

            //check slots that contain same item
            foreach (InventorySlot slot in slots)
            {
                if (slot.currentItem == item)
                {
                    int overflow = slot.AddItemToSlot(item, remaining);

                    //add as many to the slot as we can without overflowing
                    if (overflow > 0) remaining = overflow;
                    else remaining = 0;
                }
            }

            if (remaining <= 0)
            {
                return 0;
            }

            //check empty slots
            foreach (InventorySlot slot in slots)
            {
                if (slot.currentItem == null)
                {
                    remaining = slot.AddItemToSlot(item, remaining);
                }
                if (remaining <= 0)
                {
                    break;
                }
            }

            return remaining;
        }

        /// <summary>
        /// Physically drop specified item and place it in front of the player
        /// </summary>
        /// <param name="item"></param>
        /// <param name="amount"></param>
        /// <param name="removeCurrentItem"></param>
        public static void DropItem(ItemSO item, int amount, bool removeCurrentItem = true)
        {
            if (item == null)
                return;

            Transform player = GameObject.FindGameObjectWithTag("Player").transform;

            //Grab forward direction with slight randomness
            Vector3 random = new Vector3(Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f));
            Vector3 direction = player.forward + random;

            //"Throw" item forwards
            ItemPickupable drop = (Instantiate(Resources.Load("Item Pickupable 1"), player.position, Quaternion.identity) as GameObject).GetComponent<ItemPickupable>();
            drop.SetUpPickupable(item, amount);

            //Remove current item
            /*if (removeCurrentItem)
            {
                currentItem = null;
                currentItemAmount = 0;
            }*/
        }

        /// <summary>
        /// Swaps the currently held item stack with the item stack in [slot]. Will add to slot stack if items match.
        /// Works with empty slots, or when not holding an item.
        /// </summary>
        /// <param name="slot"></param>
        public static void SwapItemWithSlot(InventorySlot slot)
        {
            //If items are different, do a complete swap
            if (slot.currentItem != currentItem)
            {
                ItemSO tempItem = slot.currentItem;
                int tempItemAmount = slot.currentItemAmount;

                //Check slot/item type. eg. don't put head items in torso slot.
                if (slot.CheckItemCompatible(currentItem))
                {
                    slot.SetItemInSlot(currentItem, currentItemAmount);
                    currentItem = tempItem;
                    currentItemAmount = tempItemAmount;
                }
            }
            //If items do match and they aren't both null, add current stack onto slot stack.
            else if (currentItem != null)
            {
                int overflow = slot.AddItemToSlot(currentItem, currentItemAmount);

                currentItemAmount = 0;
                if (overflow > 0)
                    currentItemAmount = overflow;

            }
        }

        /// <summary>
        /// Grab [amount] of [slot]'s item. Will only grab as much as possible and will not overflow.
        /// </summary>
        /// <param name="slot"></param>
        /// <param name="amount"></param>
        public static void GrabItemFromSlot(InventorySlot slot, int amount)
        {
            //Can't do anything if the slot's item doesn't match the held item
            if (currentItem != null && slot.currentItem != currentItem)
                return;

            //if not holding item currently, grab entire stack from slot
            if (currentItem == null)
            {
                currentItem = slot.currentItem;
                currentItemAmount = amount;
                slot.AddItemToSlot(currentItem, -amount);
            }

            //if items match, add to currently held item without overflowing
            else if (slot.currentItem == currentItem)
            {
                currentItemAmount += amount;
                slot.AddItemToSlot(currentItem, -amount);

                if (currentItemAmount > currentItem.stackLimit)
                {
                    slot.AddItemToSlot(currentItem, currentItemAmount - currentItem.stackLimit);
                    currentItemAmount = currentItem.stackLimit;
                }
            }
            SelectRemainAmount = slot.currentItemAmount+1;
        }

        /// <summary>
        /// Returns true if entire inventory contains at least [amount] of [item]
        /// </summary>
        /// <param name="item"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool CheckItem(ItemSO item, int amount)
        {
            int remaining = amount;

            foreach (InventorySlot slot in slots)
            {
                if (slot.currentItem == item)
                {
                    remaining -= slot.currentItemAmount;
                }

                if (remaining <= 0)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Removes [amount] of [item] from inventory. 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="amount"></param>
        public void RemoveItemFromInventory(ItemSO item, int amount)
        {
            int remaining = amount;

            foreach (InventorySlot slot in slots)
            {
                if (slot.currentItem == item)
                {
                    if (remaining >= slot.currentItemAmount)
                    {
                        remaining -= slot.currentItemAmount;
                        slot.SetItemInSlot(null, 0);
                    }
                    else
                    {
                        slot.SetItemInSlot(item, slot.currentItemAmount - remaining);
                        remaining = 0;
                    }

                    if (remaining <= 0)
                        return;
                }

            }
        }

        /// <summary>
        /// Removes currently held item completely
        /// </summary>
        ///     

        public static void RemoveItem()
        {
            currentItem = null;
            currentItemAmount = 0;
        }

        public void BinItem()
        {
            RemoveItem();
        }



        public void ClickBinIcon()
        {
            if (currentItem != null)
            {
                TrashWindow.SetActive(true);
                TrashAmountSlider.minValue = 1;
                TrashAmountSlider.maxValue = SelectRemainAmount;
                TrashAmountSlider.value = 1;
            }
        }
        public void ClosedTrashwindow()
        {
            TrashWindow.SetActive(false);
        }
        public void RemoveItem2(int amount)
        {
            amount = (int)TrashAmountSlider.value;
            slots[SlotNumber].currentItemAmount -= amount;
            if (slots[SlotNumber].currentItemAmount < 0)
            {
                currentItem = null;
                currentItemAmount = 0;
                slots[SlotNumber].currentItemAmount = 0;
                DataManager.instance.nowPlayer.RubbyPoint += (amount*5);
            }
            DataManager.instance.SaveData();
            TrashWindow.SetActive(false);
        }
        public void ValueChange()
        {
            int amount = (int)TrashAmountSlider.value;
            TrasjAmountText.text = amount.ToString() + "개 버리기";
        }

    }
    
}
