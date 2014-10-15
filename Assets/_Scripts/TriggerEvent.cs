using UnityEngine;
using System.Collections;

public class TriggerEvent : MonoBehaviour {

	public enum ButtonType{POI, Skin, Movie, AnimationToggle};
	public enum TriggerType{Open, Close};

	public int triggerNumber;
	public TriggerType triggerType;
	public ButtonType buttonType;
	private bool willOpen = false;

	private StateManager SM;

	// Use this for initialization
	void Start () {

		SM = GameObject.Find("Manager").GetComponent<StateManager>();

		if(triggerType == TriggerType.Open){
			willOpen = true;
		}

		else{
			willOpen = false;
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {

		if(buttonType == ButtonType.POI){
			if(willOpen){
	//			SM.OpenPOI(triggerNumber);
			}

			else{
	//			SM.ClosePOI();
			}

		//	SM.OpenPOI(triggerNumber, willOpen);
	    //    Debug.Log("Trigger Event: " +  triggerNumber + " Open:" + willOpen);
    	}

    	else if(buttonType == ButtonType.Skin){
    		SM.ChangeSkin(triggerNumber);

    	}

    	else if(buttonType == ButtonType.Movie){
    		SM.TriggerMovie();

    	}

    	else if(buttonType == ButtonType.AnimationToggle){
    		SM.ToggleAnimation();

    	}
    }
}
