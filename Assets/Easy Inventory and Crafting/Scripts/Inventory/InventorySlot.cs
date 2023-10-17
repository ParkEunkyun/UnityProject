﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using EZInventory;
using System.Security.Cryptography.X509Certificates;

namespace EZInventory
{
    public class InventorySlot : MonoBehaviour, IPointerDownHandler//, IPointerUpHandler//, IPointerEnterHandler, IPointerExitHandler,
    {
        public ItemSO currentItem { get; set; }
        public int currentItemAmount { get; set; }
        [Tooltip("Whether or not to include in the inventory")]
        public bool includeInInventory = true;
        [Tooltip("What types of items this slot can hold")]
        public ItemSO.Type type;
        public bool interactable = true;

        [SerializeField]
        protected Image itemImage;
        [SerializeField]
        protected Image borderImage;
        [SerializeField]
        protected Image stackImage;
        [SerializeField]
        protected Text stackText;

        public int Id;

        [SerializeField]
        protected bool mouseOver;
        protected static GameObject tooltipPrefab;
        protected GameObject tooltipInstance;

        // Start is called before the first frame update
        void Start()
        {
            if (!tooltipPrefab)
                tooltipPrefab = Resources.Load("Tooltip") as GameObject;
        }

        // Update is called once per frame
        void Update()
        {

            if (currentItemAmount <= 0)
            {
                currentItem = null;
            }

            SetUI();

            if (mouseOver)
            {
                MouseOverChecks();
            }

            //Destroy tooltip if there is no current item
            if (currentItem == null && tooltipInstance != null)
            {
                Destroy(tooltipInstance);
            }
        }

        /// <summary>
        /// Called in Update() while mouseOver == true. All mouse button funcitonality goes here.
        /// </summary>
        protected virtual void MouseOverChecks()
        {
            if (!interactable) return;

            if (Input.touchCount == 1)
            {
                /*
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    InventoryManager.SwapItemWithSlot(this);
                    mouseOver = false;
                }
                */
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    //Grab item from slot if slot contains an item
                    if (currentItem)
                    {
                        //Grab half if mouse is not holding an item, otherwise grab only 1
                        int grabAmount = InventoryManager.currentItem == null ? 1 : -1;
                        InventoryManager.GrabItemFromSlot(this, grabAmount);
                        Debug.Log("InputDown(if)");
                        mouseOver = false;
                    }
                    //Place 1 item if slot is empty
                    else
                    {                        
                        currentItem = InventoryManager.currentItem;
                        InventoryManager.GrabItemFromSlot(this, -1);
                        Debug.Log("InputDown(else)");
                        mouseOver = false;
                    }
                }
                
            }
            DataManager.instance.RecipeinvenSave();
        }        

        /// <summary>
        /// Called in Update(). Sets all UI elements for the slot.
        /// </summary>
        protected virtual void SetUI()
        {
            if (currentItem)
            {
                //Slot UI
                itemImage.sprite = currentItem.itemSprite;
                itemImage.color = Color.white;
                stackImage.color = currentItem.itemBorderColor;
                //borderImage.color = currentItem.itemBorderColor;

                stackImage.gameObject.SetActive(currentItemAmount > 1);
                stackText.text = currentItemAmount.ToString();
                Id = currentItem.id;

                //Create/Destroy Tooltip
                if (mouseOver && !tooltipInstance)
                {
                    tooltipInstance = Instantiate(tooltipPrefab);
                    tooltipInstance.GetComponent<Tooltip>().SetTooltip(currentItem.tooltip, transform.position + Vector3.up * 20);
                }
                else if (!mouseOver && tooltipInstance != null)
                {
                    Destroy(tooltipInstance);
                }
            }
            else
            {
                //Slot UI
                itemImage.sprite = null;
                stackImage.color = Color.white;
                //borderImage.color = Color.white;
                itemImage.color = Color.clear;
                Id = -1;
                stackImage.gameObject.SetActive(false);
            }
        }

        /*   public void OnPointerEnter(PointerEventData pointerEventData)
           {
               mouseOver = true;
           }
           public void OnPointerExit(PointerEventData pointerEventData)
           {
               mouseOver = false;
           }*/
        public void OnPointerDown(PointerEventData pointerEventData)
        {
            mouseOver = true;
            Debug.Log("onPointerDown");
            //Invoke("mousoverfalse", 0.5f);
        }

        public void mousoverfalse()
        {
            mouseOver = false;
        }

        public int AddItemToSlot(ItemSO item, int amount)
        {
            //Early exit if clicking on empty slots with no item.
            if (!currentItem && !item)
                return 0;

            //Check item type for equipment slots
            if (type != ItemSO.Type.All && type != item.type)
                return amount;

            //Add to stack if items are the same
            if (currentItem == item)
            {
                currentItemAmount += amount;
            }
            //Replace stack if items are different
            else
            {
                currentItem = item;
                currentItemAmount = amount;
            }

            //Overflow management
            int overflow = currentItemAmount - currentItem.stackLimit;
            if (overflow > 0)
                currentItemAmount = currentItem.stackLimit;
            if (currentItemAmount == 0)
                currentItem = null;

            return overflow;
        }

        public void SetItemInSlot(ItemSO item, int amount)
        {
            currentItem = item;
            currentItemAmount = amount;
        }

        public bool CheckItemCompatible(ItemSO item)
        {
            return (item == null || type == ItemSO.Type.All || type == item.type);
        }

        private void OnDisable()
        {
            mouseOver = false;
            if (tooltipInstance)
                Destroy(tooltipInstance);
        }
    }
}