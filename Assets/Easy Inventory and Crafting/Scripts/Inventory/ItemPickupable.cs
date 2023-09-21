﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZInventory;

namespace EZInventory
{
    /// <summary>
    /// Adds items to inventory on collision with Player
    /// </summary>
    public class ItemPickupable : MonoBehaviour
    {
        ItemSO itemSO;
        int itemAmount;
        static Transform camTransform;

        private void Start()
        {
            if (!camTransform)
                camTransform = Camera.main.transform;
        }

        private void Update()
        {
            transform.forward = -camTransform.forward;
        }

        public void SetUpPickupable(ItemSO item, int amount)
        {
            itemSO = item;
            itemAmount = amount;
            GetComponent<SpriteRenderer>().sprite = item.itemSprite;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                int remaining = InventoryManager.AddItemToInventory(itemSO, itemAmount);

                if (remaining > 0)
                {
                    itemAmount = remaining;
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
