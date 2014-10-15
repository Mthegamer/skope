using UnityEngine;
using System.Collections;

public class Trigger_UIButton : MonoBehaviour {

	public enum ButtonType{POIText, POIColour, Movie, AnimationToggle, Specs, Email, Close};
	public ButtonType buttonType;

	public int triggerNumber;
	public string triggerText;

	private StateManager SM;

	// Use this for initialization
	void Start () {
		SM = GameObject.Find("Manager").GetComponent<StateManager>();
	
	}

	void OnClick(){
		if(buttonType == ButtonType.POIText){
			Debug.Log("POIText:" + triggerText);
		}

		else if(buttonType == ButtonType.POIColour){
			Debug.Log("POIColour");
		}

		else if(buttonType == ButtonType.Movie){
			Debug.Log("Movie");
		}

		else if(buttonType == ButtonType.AnimationToggle){
			Debug.Log("Anim");
		}

		else if(buttonType == ButtonType.Specs){
			Debug.Log("Specs");
			SM.ToggleSpecs();
		}

		else if(buttonType == ButtonType.Email){
			Debug.Log("Email");
			SM.SendEmail();
		}

		else if(buttonType == ButtonType.Close){
			Debug.Log("Close");
			SM.ClosePOI();
		}

	}
}
