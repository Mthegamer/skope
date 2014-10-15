using UnityEngine;
using System.Collections;

public class Trigger_ARButton : MonoBehaviour {

	public enum ButtonType{POIText, POIColour, Movie, AnimationToggle, Specs, Email, Close};
	public ButtonType buttonType;

	public int triggerNumber;
	public string triggerText;

	public StateManager SM;

	// Use this for initialization
	void Start () {

		SM = GameObject.Find("Manager").GetComponent<StateManager>();
	
	}

	void Update(){
		
}


	void OnMouseDown() {

		#if UNITY_ANDROID

		Debug.Log("TOUCH:" + Input.touches.Length);
		for(int i = 0; i < Input.touches.Length; i++)//How many touches do we have? 
	    { 
	        Touch touch = Input.touches[i];//The touch 
	        Ray ray = Camera.main.ScreenPointToRay(touch.position); 
	         
	        RaycastHit hit;// = new RaycastHit(); 
	        if(Physics.Raycast(ray, out hit, 1000)) 
	        { 
	            if(hit.collider.gameObject == this.gameObject) 
	            { 
	                switch(touch.phase) 
	                { 
	                    case TouchPhase.Began://if the touch begins 
	                       // Debug.Log("Ticked");

	                        if(buttonType == ButtonType.POIText){
								Debug.Log("POIText:" + triggerText);
								SM.OpenPOI(triggerNumber);
							}

							else if(buttonType == ButtonType.POIColour){
								Debug.Log("POIColour");
								SM.OpenPOI(5);
								//SM.ToggleTest();

							}

							else if(buttonType == ButtonType.Movie){
								Debug.Log("Movie");
								SM.TriggerMovie();
							}

							else if(buttonType == ButtonType.AnimationToggle){
								Debug.Log("Anim");
								//SM.AirAnim();
								SM.ToggleAnimation();
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
	                    break; 
	                    /* 
	                    case TouchPhase.Ended://If the touch ends 
	                         
	                    break; 
	                     
	                    case TouchPhase.Moved://If the finger moved 
	                         
	                    break; 
	                     
	                    case TouchPhase.Stationary://While touching the screen and didn move the finger. 
	                         
	                    break; 
	                    */ 
	                    default: 
	                         
	                    break; 
	                } 
	            } 
	        }
	}

	#endif

	#if UNITY_EDITOR

	                        if(buttonType == ButtonType.POIText){
								Debug.Log("POIText:" + triggerText);
								SM.OpenPOI(triggerNumber);
							}

							else if(buttonType == ButtonType.POIColour){
								Debug.Log("POIColour");
								SM.OpenPOI(5);
								//SM.ToggleTest();

							}

							else if(buttonType == ButtonType.Movie){
								Debug.Log("Movie");
								SM.TriggerMovie();
							}

							else if(buttonType == ButtonType.AnimationToggle){
								Debug.Log("Anim");
								//SM.AirAnim();
								SM.ToggleAnimation();
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

	#endif 
							

	}
}
