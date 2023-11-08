using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using EZInventory;

namespace EZInventory
{
    /// <summary>
    /// This sets up all the UI for grid crafting
    /// </summary>
    public class CraftingMenuGrid : MonoBehaviour
    {
        [Tooltip("Slot where result item appears when crafting")]
        public PickUpOnlySlot resultSlot;
        [Tooltip("Each grid slot")]
        public SlotsGrid craftingSlots;
        public List<RecipeGrid> recipes;
        RecipeGrid currentRecipe;
        public RecipeDataBase recipeData;

        [System.Serializable]
        public class SlotsGrid
        {
            public GridSlot topLeft, topMiddle, topRight,
                middleLeft, middle, middleRight,
                bottomLeft, bottomMiddle, bottomRight;
        }

        // Start is called before the first frame update
        void OnEnable()
        {
            /*
            recipes = new List<RecipeGrid>();
            
            RecipeGrid[] recipeAssets = Resources.LoadAll<RecipeGrid>("/Grid");
            Debug.Log(recipeAssets.Length);
            foreach (RecipeGrid asset in recipeAssets)
            {
                RecipeGrid recipe = asset;
                recipes.Add(recipe);
                Debug.Log(recipe);
            }
            string[] assetNames = AssetDatabase.FindAssets("GR_");
            Debug.Log(assetNames.Length);
            foreach (string assetName in assetNames)
            {
                RecipeGrid recipe = AssetDatabase.LoadAssetAtPath<RecipeGrid>(AssetDatabase.GUIDToAssetPath(assetName));
                recipes.Add(recipe);
                Debug.Log(recipe);
            }*/
        }

        // Update is called once per frame
        void Update()
        {
            resultSlot.SetItemInSlot(currentRecipe ? currentRecipe.output : null, currentRecipe ? currentRecipe.outputAmount : 0);
        }

        /// <summary>
        /// Checks each recipe to see if any match the current grid. Then sets currentRecipe.
        /// </summary>
        public void CheckRecipes ()
        {
            bool recipeFound = false;
            foreach (RecipeGrid recipe in recipes)
            {
                if (!craftingSlots.topLeft || craftingSlots.topLeft.currentItem != recipe.topLeft)
                    continue;
                if (!craftingSlots.topMiddle || craftingSlots.topMiddle.currentItem != recipe.topMiddle)
                    continue;
                if (!craftingSlots.topRight || craftingSlots.topRight.currentItem != recipe.topRight)
                    continue;
                if (!craftingSlots.middleLeft || craftingSlots.middleLeft.currentItem != recipe.middleLeft)
                    continue;
                if (!craftingSlots.middle || craftingSlots.middle.currentItem != recipe.middle)
                    continue;
                if (!craftingSlots.middleRight || craftingSlots.middleRight.currentItem != recipe.middleRight)
                    continue;
                if (!craftingSlots.bottomLeft || craftingSlots.bottomLeft.currentItem != recipe.bottomLeft)
                    continue;
                if (!craftingSlots.bottomMiddle || craftingSlots.bottomMiddle.currentItem != recipe.bottomMiddle)
                    continue;
                if (!craftingSlots.bottomRight || craftingSlots.bottomRight.currentItem != recipe.bottomRight)
                    continue;

                recipeFound = true;
                currentRecipe = recipe;
                break;
            }

            if (!recipeFound)
                currentRecipe = null;
        }

        private void OnDisable()
        {
            currentRecipe = null;
        }

        /// <summary>
        /// After crafting, removes all ingredients used in the recipe.
        /// </summary>
        public void RemoveIngredients()
        {
            if (craftingSlots.topLeft.currentItem != null)
                craftingSlots.topLeft.AddItemToSlot(craftingSlots.topLeft.currentItem, -1);
            if (craftingSlots.topMiddle.currentItem != null)
                craftingSlots.topMiddle.AddItemToSlot(craftingSlots.topMiddle.currentItem, -1);
            if (craftingSlots.topRight.currentItem != null)
                craftingSlots.topRight.AddItemToSlot(craftingSlots.topRight.currentItem, -1);
            if (craftingSlots.middleLeft.currentItem != null)
                craftingSlots.middleLeft.AddItemToSlot(craftingSlots.middleLeft.currentItem, -1);
            if (craftingSlots.middle.currentItem != null)
                craftingSlots.middle.AddItemToSlot(craftingSlots.middle.currentItem, -1);
            if (craftingSlots.middleRight.currentItem != null)
                craftingSlots.middleRight.AddItemToSlot(craftingSlots.middleRight.currentItem, -1);
            if (craftingSlots.bottomLeft.currentItem != null)
                craftingSlots.bottomLeft.AddItemToSlot(craftingSlots.bottomLeft.currentItem, -1);
            if (craftingSlots.bottomMiddle.currentItem != null)
                craftingSlots.bottomMiddle.AddItemToSlot(craftingSlots.bottomMiddle.currentItem, -1);
            if (craftingSlots.bottomRight.currentItem != null)
                craftingSlots.bottomRight.AddItemToSlot(craftingSlots.bottomRight.currentItem, -1);

            //Check recipes again to "refresh" result slot
            CheckRecipes();
        }
        public void GetItem()
        {
            if (resultSlot.Id < 1000)
            {
                DataManager.instance.AddNewEquipItem(resultSlot.Id);
            }
            else
            {
                int rann = resultSlot.Id - 1000;
                ItemSO item = recipeData.RecipeItem[rann];
                EZInventory.InventoryManager.instance.AddItemToInventory(item, 1);
            }            

            RemoveIngredients();
        }

    }
}