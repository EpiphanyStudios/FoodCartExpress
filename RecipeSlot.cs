using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class RecipeSlot : MonoBehaviour {

	public int slotNumber;
	public int itemQuantity;
	
	HomeRecipeCard recipeCard;
	Recipe recipe;
	
	Image itemImage;
	Text itemAmount;
	
	// Use this for initialization
	void Start () {
		recipeCard = GetComponentInParent<HomeRecipeCard>();
		recipe = recipeCard.recipe;
		itemImage = transform.GetChild(0).GetComponent<Image>();
		itemAmount = transform.GetChild(1).GetComponent<Text>();
		itemImage.sprite = recipe.recipeIngredients[slotNumber].itemIcon;
		itemQuantity = recipe.recipeIngredientQuantity[slotNumber];
		itemAmount.text = itemQuantity.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
