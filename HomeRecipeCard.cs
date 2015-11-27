using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HomeRecipeCard : MonoBehaviour {

	public ItemDatabase database;

	public Recipe recipe;
	public GameObject slots;
	public GameObject instructions;
	
	Text recipeTitle;
	Text recipeDescription;
	
	bool embiggened = true;
	
	
	// Use this for initialization
	void Start () {
		database = FindObjectOfType<ItemDatabase>();
		recipe = database.recipeCollection[0];	
		TextSetup ();
		
		// This populates the icons for the ingredients
		for (int i = 0; i < recipe.recipeIngredients.Length; i++){
			GameObject slot = (GameObject)Instantiate(slots);
			slot.GetComponent<RecipeSlot>().slotNumber = i;
			slot.name = ("Recipe Icon " + (i+1));
			slot.transform.SetParent(this.gameObject.transform);
			slot.GetComponent<RectTransform>().localPosition = new Vector3(-145f + (45*i), -170f, 0f);
			slot.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
		}
		
		// This populates the instruction lists
		for (int j = 0; j < recipe.recipeInstructions.Length; j++){
			GameObject instruction = (GameObject) Instantiate(instructions);
			Text text = instruction.GetComponent<Text>();
			text.text = recipe.recipeInstructions[j];
			instruction.name = ("Recipe Instruction " + (j+1));
			instruction.transform.SetParent(this.gameObject.transform);
			instruction.GetComponent<RectTransform>().localPosition = new Vector3(0f, -222f - (35f * j), 0f);
			instruction.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.R)){
			EmbiggenToggle();
		}
	}
	
	void EmbiggenToggle(){
		if(embiggened){
			this.transform.localScale = this.transform.localScale / 2;
			embiggened = !embiggened;
		}
		else if (!embiggened){
			this.transform.localScale = this.transform.localScale * 2;
			embiggened = !embiggened;
		}
	}
	
	void TextSetup(){
		recipeTitle = transform.GetChild(0).GetComponent<Text>();
		recipeTitle.text = recipe.recipeName;
		recipeDescription = transform.GetChild(1).GetComponent<Text>();
		recipeDescription.text = recipe.recipeDesc;
	}
	
	void SetRecipe(int index){
		recipe = database.recipeCollection[index];
	}
}
