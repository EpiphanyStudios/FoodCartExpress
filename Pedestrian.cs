using UnityEngine;
using System.Collections;

public class Pedestrian {
		
	// contiubuting details to the likelihood of their buying from you
	string firstName;
	string lastName;
	int indexOfPedestrian;
	int age;
	float opennessToNewThings;
	int timesVisited;
	float faithInVendors;
	
	// the more prosaic of their characteristics
	float cashOnHand;
	
	public Pedestrian (int index, float openNess, float cash) {
		indexOfPedestrian = index;
		opennessToNewThings = openNess;
		cashOnHand = cash;
	}
	
	public Pedestrian (){
	
	}
	
}
