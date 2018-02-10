using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

	public Text textBox;
	private States myState;
	private bool hasKey;
	private bool hasWrench;
	private bool brokenBarrels;
	private bool hasTDKey;
	private bool isOpen;
	private bool hasBones;
	private bool hasGlass;
	private bool isFree;
	private bool isTDOpen;
	private bool isWindowOpen;
	private enum States {start, cellar, table, window, barrels, shelf, shelf_up, room, door, floor, chair, trap_door, courtyard, end};
	// Use this for initialization
	void Start () {
		myState = States.start;
		hasKey = false;
		hasWrench = false;
		brokenBarrels = false;
		hasTDKey = false;
		isOpen = false;
		hasBones = false;
		hasGlass = false;
		isFree = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (myState == States.start) { //Level 1
			introductionStory ();
		} else if (myState == States.cellar) {
			cellarStory ();
		} else if (myState == States.table) {
			tableStory ();
		} else if (myState == States.barrels) {
			barrelStory ();
		} else if (myState == States.window) {
			windowStory ();
		} else if (myState == States.shelf) {
			shelfStory ();
		} else if (myState == States.shelf_up) {
			climbUpShelf ();
		} else if (myState == States.room) { //Level 2
			roomStory ();
		} else if (myState == States.floor) {
			floorStory ();
		} else if (myState == States.door) {
			doorStory ();
		} else if (myState == States.chair) {
			chairStory ();
		} else if (myState == States.trap_door) {
			trapDoorStory ();
		} else if (myState == States.courtyard) { //Level 3
			courtyardStory ();
		} else if (myState == States.end) {
			endStory ();
		}
	}

	void introductionStory() {
		textBox.text = "You wake up and find yourself in a dark room. It looks like an underground cellar. " +
					"The last thing you remember is someone hitting you on the back of your head when you were taking a walk in the park. " +
					"You walk up the stairs and try to open the door. It's locked. Someone has trapped you here. " +
					"Find a way to escape.\n\n" +
					"[Press S to Start]";
		if (Input.GetKeyDown (KeyCode.S)) {
			myState = States.cellar;
		}
	}

	void cellarStory() {
		textBox.text = "The cellar is dark, but you can make out a table on your left, a small window high above it, " +
			"a few barrels to your right, and a shelf right in front of you.\n\n" +
			"[Press T to go to the Table, B to view the Barrels, or S to check out the Shelf]";
		if (Input.GetKeyDown (KeyCode.T)) {
			myState = States.table;
		} else if (Input.GetKeyDown (KeyCode.B)) {
			myState = States.barrels;
		} else if (Input.GetKeyDown (KeyCode.S)) {
			myState = States.shelf;
		}
	}

	void tableStory() {
		textBox.text = "There is nothing on the table. You check the drawers which are also empty. " +
			"Damn your luck! You look up and see the window.\n\n" +
			"[Press W to check out the window, or C to go back to the Cellar]";
		if(Input.GetKeyDown(KeyCode.W)) {
			myState = States.window;
		} else if(Input.GetKeyDown(KeyCode.C)) {
			myState = States.cellar;
		}
	}

	void windowStory() {
		if (isWindowOpen == true) {
			textBox.text = "You stand on the table and look out through the window. " +
				"You could get back to the cellar or go to the room.\n\n" +
				"[Press D to go Down, or R to go to the Room]";
			if (Input.GetKeyDown (KeyCode.R)) {
				myState = States.room;
			}
		} else {
			if (hasKey == true) {
				textBox.text = "You climb up on the table to check out the window. It's closed. " +
				"You try out your luck with the key in your hand.\n\n" +
				"[Press K to use the Key, or D to go back Down]";
				if (Input.GetKeyDown (KeyCode.K)) {
					myState = States.room;
				}
			} else {
				textBox.text = "You climb up to the table to check out the window. It's closed. " +
				"There's a keyhole in it. Now if you could only get your hands on the key...\n\n" +
				"[Press D to go back Down]";
			}
		}
		if (Input.GetKeyDown (KeyCode.D)) {
			myState = States.table;
		}
	}

	void barrelStory() {
		if (hasWrench == true && brokenBarrels == false) {
			textBox.text = "You see the barrels in front of you. They are made of wood and look weak enough to break. " +
				"You might as well try out your luck with the wrench in your hand.\n\n" +
				"[Press B to Break the barrels, or C to go back to the Cellar]";
			if (Input.GetKeyDown (KeyCode.B)) {
				brokenBarrels = true;
			}
		} else if (hasWrench == true && brokenBarrels == true && hasKey == false) {
			textBox.text = "You used the wrench to break the barrels, which are now open. You look into it, " +
				"and find out that there are keys inside. They could be useful.\n\n" +
				"[Press P to Pick up the keys, or C to go back to the Cellar]";
			if (Input.GetKeyDown (KeyCode.P)) {
				hasKey = true;
			}
		} else if (hasWrench == true && brokenBarrels == true && hasKey == true) {
			textBox.text = "You have taken the keys which were in the barrel. You look around to see if there's anything else. " +
				"There isn't. You should go back to the cellar.\n\n" +
				"[Press C to go back to the Cellar]";
		} else {
			textBox.text = "You see a few barrels in front of you. You try to open them but no luck. " +
				"If only you could break them somehow.\n\n" +
				"[Press C to go back to the Cellar]";
		}
		if (Input.GetKeyDown (KeyCode.C)) {
			myState = States.cellar;
		}
	}

	void shelfStory() {
		if (hasWrench == true) {
			textBox.text = "You are now standing in front of the shelf. You have the wrench that you picked up from the top.\n\n" +
				"[Press C to go back to the Cellar, or U to climb Up the shelf]";
		} else {
			textBox.text = "You are now standing in front of the shelf. The shelf is empty as far as you can see. " +
				"But you can't be sure until you have climbed up and checked out the top too.\n\n" +
				"[Press C to go back to the Cellar, or U to climb Up the shelf]";
		}
		if (Input.GetKeyDown (KeyCode.C)) {
			myState = States.cellar;
		} else if (Input.GetKeyDown (KeyCode.U)) {
			myState = States.shelf_up;
		}
	}

	void climbUpShelf() {
		if (hasWrench == true) {
			textBox.text = "You have the wrench in your hand, and look around to see if there's anything else up " +
				"here that might be useful for you. There isn't anything else.\n\n" +
				"[Press D to climb back Down]";
		} else {
			textBox.text = "You have let your honour take a backseat and have climbed up on the shelf. You search around and " +
			"you see a wrench there.\n\n" +
			"[Press P to Pick up the wrench, or D to climb back Down]";
			if (Input.GetKeyDown (KeyCode.P)) {
				hasWrench = true;
			}
		}
		if (Input.GetKeyDown (KeyCode.D)) {
			myState = States.shelf;
		}
	}

	void roomStory() {
		if (isWindowOpen == true) {
			if (hasGlass == true) {
				textBox.text = "You stand at the center of the room. There's a door on the side and a chair at the center. " +
					"Or you could go back down the window.\n\n" +
					"[Press C to go to the chair, D to go to the Door, or W to go back down the window]";
			} else {
				textBox.text = "You stand at the center of the room. There's a door on the side, a chair at the center, and something shining on the floor." +
					"Or you could go back down the window.\n\n" +
					"[Press C to go to the chair, D to go to the Door, F to check out the thing on the Floor, or W to go back down the window]";
				if (Input.GetKeyDown (KeyCode.F)) {
					myState = States.floor;
				}
			}
		} else {
			textBox.text = "You put the key in the keyhole and turn it... Voila! It works! The window opens and " +
				"you climb out of it. You now find yourself in a small room, with a door on one side, a chair at the center, " +
				"and something shining on the floor at the side.\n\n" +
				"[Press C to go to the chair, D to go to the Door, F to check out the thing on the Floor, or W to go back down the window]";
			if (Input.GetKeyDown (KeyCode.F)) {
				myState = States.floor;
			}
		}
		if (Input.GetKeyDown (KeyCode.C)) {
			myState = States.chair;
		} else if (Input.GetKeyDown (KeyCode.D)) {
			myState = States.door;
		} else if (Input.GetKeyDown (KeyCode.W)) {
			myState = States.window;
		}
	}

	void chairStory() {
		if (hasTDKey == true) {
			textBox.text = "You have picked up the keys that were stuck in the cloth. You look at the chair to " +
				"see if there's anything else that you can use. There's nothing else.\n\n" +
				"[Press R to go back to the Room]";
		} else {
			if (hasGlass == true) {
				textBox.text = "You see a piece of metal stuck to the edge of the chair. You look at the glass in your hand which looks sharp enough "+
					"to cut the cloth.\n\n" +
					"[Press C to Cut the cloth, or R to go back to the Room]";
				if (Input.GetKeyDown (KeyCode.C)) {
					hasTDKey = true;
				}
			} else {
				textBox.text = "You see a piece of metal stuck to the edge of the chair. You try to pull it out, but it's stuck to the cloth. " +
				"If only you had something to tear it with.\n\n" +
				"[Press R to go back to the center of the Room]";
			}
		}
		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.room;
		}
		isWindowOpen = true;
	}

	void floorStory() {
		if (hasGlass == true) {
			textBox.text = "You look at the floor to see if there's anything else you might need. There's nothing else.\n\n" +
				"[Press R to go to the center of the Room]";
		} else {
			textBox.text = "You look down to see the shining thing. There are a few pieces of glass scattered on the floor. " +
				"It sharp enough to be used to tear something or to defend yourself.\n\n" +
				"[Press P to Pick up the glass, or R to go back to the center of the Room]";
			if (Input.GetKeyDown (KeyCode.P)) {
				hasGlass = true;
			}
		}
		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.room;
		}
		isWindowOpen = true;
	}

	void doorStory() {
		if (hasBones == true) {
			textBox.text = "You stand at the door with a huge bone that you picked up, and the trap door in front of you. " +
				"You don't know what you'll do with it, but you keep it anyway. Now, moving on...\n\n" +
				"[Press R to go back to the Room, or T to climb up to the Trap door]";
		}
		else {
			textBox.text = "The door seems to be unlocked. You open the door and see. It moves up the stairs and ends in a trap door. " +
				"There is also a bunch of bones in front of you on the floor. Creepy...\n\n" +
				"[Press R to go back to the Room, P to pick up the bones, or T to climb up to the Trap door]";
			if (Input.GetKeyDown (KeyCode.P)) {
				hasBones = true;
			}
		}
		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.room;
		} else if (Input.GetKeyDown (KeyCode.T)) {
			myState = States.trap_door;
		}
		isWindowOpen = true;
	}

	void trapDoorStory() {
		if (isTDOpen == true) {
			textBox.text = "You stand at the stairs in front of the trap door. You could go back to the room, or go out and try to escape.\n\n" +
				"[Press C to go to the Courtyard, or D to go Down to the room]";
			if (Input.GetKeyDown (KeyCode.C)) {
				myState = States.courtyard;
			}
		} else {
			if (hasTDKey == true) {
				textBox.text = "The key in your hand looks to be a fit for the keyhole in the trap door. You could try it out to see if it fits...\n\n" +
				"[Press K to use the Key, or D to go back Down]";
				if (Input.GetKeyDown (KeyCode.K)) {
					myState = States.courtyard;
					isTDOpen = true;
				}
			} else {
				textBox.text = "The trapdoor seems to have been locked from the inside. Just when you thought you were free. " +
				"Now, you need to find the key for this.\n\n" +
				"[Press D to go back Down]";
			}
		}
		if (Input.GetKeyDown (KeyCode.D)) {
			myState = States.door;
		}
	}

	void courtyardStory() {
		textBox.text = "You are out of the cellar and into the courtyard. It's night and there's no one around. There is a gate in front of you and it's open, " +
			"but there are a few dogs in front of it, and they look hungry.\n\n" +
			"[Press D to go back down, or G to go to the Gate]";
		if (Input.GetKeyDown (KeyCode.D)) {
			myState = States.trap_door;
		} else if (Input.GetKeyDown (KeyCode.G)) {
			myState = States.end;
		}
	}

	void endStory() {
		if (hasBones == true) {
			textBox.text = "You throw the bones in your hands to the dogs and they fight over it, completely ignoring you. " +
				"You take this as a chance and run out the gate! You are free!\n\n" +
				"[Press P to Play again!]";
		} else {
			textBox.text = "You decide to trust fate and confront the dogs, but they don't seem to like it. They bark and run towards you. " +
				"Hearing the sound, a man comes out from the house with a gun in his hand, probably the man who trapped you here. " +
				"He points the gun at you and shoots! \n\nYou lose.\n\n" +
				"[Press P to Play again!]";
		}
		if (Input.GetKeyDown (KeyCode.P)) {
			Start ();
		}
	}
}