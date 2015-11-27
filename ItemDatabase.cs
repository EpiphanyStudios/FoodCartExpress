using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour {

	static ItemDatabase instance;

	public List<Item> items = new List<Item>();
	
	public List<Item> QuickInv = new List<Item>(8);
	public List<int> QuickInvQuant = new List<int>(8);
	public List<Item> ShopInv = new List<Item>(72);
	public List<int> ShopInvQuant = new List<int>(72);
	public List<Item> CartInv = new List<Item>(12);
	public List<int> CartInvQuant = new List<int>(12);
	public List<Item> HomeInv = new List<Item>(24);
	public List<int> HomeInvQuant = new List<int>(24);
	
	public List<Recipe> recipeCollection = new List<Recipe>();
	
	
	
	// Use this for initialization
	void Start () {
		
		if (instance != null){
			Destroy(gameObject);
		}
		if (instance == null){
			instance = this;
		}
		DontDestroyOnLoad(gameObject);
		
		items.Add(new Item("bun", 1, "A lovely plain bun!", 25, Item.ItemType.Food, 15, 20, true));
		items.Add(new Item("pizzaslice", 2, "Hmmm... pizza...", 50, Item.ItemType.Food, 5, 25, true));
		items.Add(new Item("mushrooms", 3, "Not the magic variety", 5, Item.ItemType.Ingredient, 50, 250, false));
		items.Add(new Item("salmonngiri", 4, "Deliciousness itself", 25, Item.ItemType.Food, 25, 50, true));
		items.Add(new Item("sausage", 5, "Don't ask where this is from... but it is pretty delicious", 10, Item.ItemType.Food, 8, 64, true));
		items.Add(new Item("egg", 6, "Chicken Egg, obvs.", 5, Item.ItemType.Ingredient, 6, 24, false));
		items.Add(new Item("friedegg", 7,"Fried chicken Egg, obvs.", 5, Item.ItemType.Food, 6, 24, true));
		items.Add(new Item("friedbacon", 8,"Nice streaky back bacon", 10, Item.ItemType.Ingredient, 8, 64, false));
		items.Add(new Item("bacon", 9, "Nice sizzling streaky back bacon", 10, Item.ItemType.Food, 8, 64, false));
		items.TrimExcess();
		
		Item[] baconAndEggIngredients = new Item[3];
		int[] baconAndEggIngredientQuantities = new int[3];
		string[] baconAndEggInstructions = new string[4];
		
		baconAndEggIngredients[0] = items[2];
		baconAndEggIngredients[1] = items[3];
		baconAndEggIngredients[2] = items[0];
		
		baconAndEggIngredientQuantities[0] = 2;
		baconAndEggIngredientQuantities[1] = 2;
		baconAndEggIngredientQuantities[2] = 1;
		
		baconAndEggInstructions[0] = "1. Cut the bun in half and put on the plate";
		baconAndEggInstructions[1] = "2. Fry both of the eggs in a pan then place on the halved bun";
		baconAndEggInstructions[2] = "3. Fry the bacon and add next to the egg";
		
		recipeCollection.Add(new Recipe("Bacon and Eggs", 1, "A deliciously nutritious breakfast", baconAndEggIngredients, baconAndEggIngredientQuantities, baconAndEggInstructions));
		
		Debug.Log (recipeCollection[0].recipeDesc);
	}
	
	
	void Update () {
	
	}
}
