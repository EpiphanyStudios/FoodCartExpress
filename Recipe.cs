using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Recipe {
	
	public string recipeName;
	public int recipeIndex;
	public string recipeDesc;
	public Item[] recipeIngredients;
	public int[] recipeIngredientQuantity;
	public string[] recipeInstructions;
	
	public Recipe(string name, int index, string description, Item[] ingredients, int[] quantities, string[] instructions){
		recipeName = name;
		recipeIndex = index;
		recipeDesc = description;
		recipeIngredients = ingredients;
		recipeIngredientQuantity = quantities;
		recipeInstructions = instructions;
	}

	public Recipe(){
	
	}
}
