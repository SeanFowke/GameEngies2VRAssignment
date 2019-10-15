using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//use this enum to change the function of this particular button
public enum ButtonFunction
{
	transition = 1
	// if more functions need to be added to the button you can put them here
};

public class VRButton : MonoBehaviour
{
	public Slider slider;
	private Image spr;
	[SerializeField] private bool active;
	public float decrement;
	private float timer;
	public float timerInitial;
	public ButtonFunction buttonFunction;
	public Vector3 newLocation;
	public GameObject pl;
	public bool wasLookedAt = false;

	void Start()
	{
		spr = GetComponent<Image>();
		timer = timerInitial;
	}

	// Update is called once per frame
	void Update()
	{
		HandleClick();
	}

	public void HandleClick()
	{
		if (wasLookedAt == true)
		{
			if (slider.value >= 1 && Input.GetButtonDown("Fire1"))
			{
				// do the thing
				active = true;
			}
			if (active == true)
			{
				// and make it work.... I know my comments aren't helpful it's 12:13 in the morning I fucking wanna play Apex Legends okay
				spr.color = new Color(1, 1, 1, timer -= decrement);
				if (timer <= 0)
				{
					spr.color = new Color(1, 1, 1, 1);
					// change what function happens depending on what happens to the enum
					switch ((int)buttonFunction)
					{
						case 1:
							TransitionToNewSphere();
							break;
						case 0:
							Debug.LogError("You dun fucked and you should know why");
							break;
							// add more to this list to add more functionality I'm just using this method as an example
					}
					active = false;
					slider.value = 0;
				}
			}
		}
	}

	public void TransitionToNewSphere()
	{
		Debug.Log("I'm changing places");
		// go to a new location or as some would say "A WHOLE NEW WORLD!!!!!!!!!!"
		pl.transform.position = newLocation;
		timer = timerInitial;
	}


























//Did you ever hear the tragedy of Darth Plagueis the Wise?

//I thought not.It's not a story the Jedi would tell you. 

//It's a Sith legend. 

//Darth Plagueis was a Dark Lord of the Sith, so powerful and so wise he could use the Force to influence the midichlorians to create life...

//He had such a knowledge of the dark side that he could even keep the ones he cared about from dying.

//The dark side of the Force is a pathway to many abilities some consider to be unnatural. 

//He became so powerful... the only thing he was afraid of was losing his power, which eventually, of course, he did.

//Unfortunately, he taught his apprentice everything he knew, then his apprentice killed him in his sleep. 

//It's ironic he could save others from death, but not himself.

}
