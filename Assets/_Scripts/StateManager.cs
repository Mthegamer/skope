using UnityEngine;
using System.Collections;
using AnimationOrTween;

public class StateManager : MonoBehaviour {

	//public SkinManager SkinM;

	public GameObject ARInstructions;
	public GameObject Header;
	public GameObject TitleInfo;
	public GameObject TriggerSpecsBtn;
	public GameObject EmailButton;

	public GameObject POIPanel;
	public GameObject SpecsPanel;
	//public GameObject SkinSelectPanel;
	public GameObject FridgeColourPanel;
	public GameObject AirflowAnimation;


	public Animation currentAnimation;

	private Animation specsAnimation;
	private Animation colourAnimation;
	private Animation poiAnimation;

	private ActiveAnimation anim;

	private bool isPopupOpen = false;
	private bool isSpecsOpen = false;
	private int lastPopupOpen;

	void Awake(){
		//SkinM = GameObject.Find("Skinning").GetComponent<SkinManager>();

		ARInstructions = GameObject.Find("ARInstructions");
		Header = GameObject.Find("Header");
		TitleInfo = GameObject.Find("TitleInfo");
		TriggerSpecsBtn = GameObject.Find("TriggerSpecs_btn");
		EmailButton = GameObject.Find("TriggerContact_btn");
		POIPanel = GameObject.Find("POI");
		SpecsPanel = GameObject.Find("Specs");
		//SkinSelectPanel = GameObject.Find("SkinSelect");

		FridgeColourPanel = GameObject.Find("FridgeColour");

		AirflowAnimation = GameObject.Find("AirflowAnimation");
		AirflowAnimation.SetActive(false);

		specsAnimation = SpecsPanel.GetComponent<Animation>();
		poiAnimation = POIPanel.GetComponent<Animation>();
		colourAnimation = FridgeColourPanel.GetComponent<Animation>();
	}

	public void ToggleInstructions(bool on){

		bool opposite = !on;
		ARInstructions.SetActive(on);
		TitleInfo.SetActive(opposite);
		TriggerSpecsBtn.SetActive(opposite);

		if(on){

			AirflowAnimation.SetActive(false);

			if(isPopupOpen){
				TogglePOI(false);
				isPopupOpen = false;
			}
		}
		
	}

	public void ToggleTest(){
		Debug.Log("DOES THIS WORK");
	}

	public void TogglePOI(bool on){ 
		
		//POI1.SetActive(on);
		//currentAnimation = POI1.GetComponent<Animation>();
		//currentAnimation.Play();
			if(on){
				//SetPOIText(0);
				anim = ActiveAnimation.Play(currentAnimation, "", Direction.Forward,EnableCondition.DoNothing,DisableCondition.DoNotDisable);
				//anim = ActiveAnimation.Play(currentAnimation, "", Direction.Toggle,EnableCondition.DoNothing,DisableCondition.DoNotDisable);
			}

			else{
				anim = ActiveAnimation.Play(currentAnimation, "", Direction.Reverse,EnableCondition.DoNothing,DisableCondition.DoNotDisable);
			}
		
		
	}

	public void SetPOIText(int POInumber) {

		UILabel lbl = POIPanel.GetComponentInChildren<UILabel>();

		

		switch(POInumber){
				case 1:
					//TogglePOI1(willOpen);
					lbl.text = "Upgraded refrigeration system for significantly improved energy efficiency, performance and noise reduction.";
	            break;

	            case 2:
					//TogglePOI1(willOpen);
					lbl.text = "Stabilised temperature display minimises fluctuations from door openings.";
	            break;

	            case 3:
					//TogglePOI1(willOpen);
					lbl.text = "Premium quality ensures reliability and durability. Performs in high ambient temperatures without being compromised.";
	            break;

	            case 4:
					//TogglePOI1(willOpen);
					lbl.text = "Available in glass or solid door. White, Black, Stainless steel and powder coated in any premium industrial Dulux grade.";
	            break;
			}

	}

	
	/*public void OpenPOI(int POInumber, bool willOpen){

		// 1 == specs panel
		// 2 == contact button
		// 3,4,5,6,7 == POI 1
		// 8 == skin select
		// 9 == Fridge colour select

		if((!willOpen) || (willOpen && !isPopupOpen)){

			if(willOpen){
				lastPopupOpen = POInumber;
			}

			switch(POInumber){
				case 1:
					//currentAnimation = SpecsPanel.GetComponent<Animation>();
					currentAnimation = specsAnimation;
					TogglePOI(willOpen);
	            break;

	            case 2:
					SendEmail();
	            break;

	            case 3:
	            case 4:
	            case 5:
	            case 6:
	            case 7:
	            	//currentAnimation = POIPanel.GetComponent<Animation>();
	            	currentAnimation = poiAnimation;
					TogglePOI(willOpen);

					if(willOpen){
						SetPOIText(POInumber);
					}
	            break;

	            case 8:
	            //	currentAnimation = SkinSelectPanel.GetComponent<Animation>();
				//	TogglePOI(willOpen);
	            break;

	            case 9:
	            //	currentAnimation = FridgeColourPanel.GetComponent<Animation>();
	           		currentAnimation = colourAnimation;
					TogglePOI(willOpen);
	            break;

			}

			isPopupOpen = willOpen;

		}
	}
	*/

	public void OpenPOI(int POInumber){
		if(!isSpecsOpen){
		Debug.Log("OPEN POI");
		if(!isPopupOpen){
			lastPopupOpen = POInumber;
			isPopupOpen = true;

			Debug.Log("OPEN:" + lastPopupOpen);


			switch(POInumber){
				case 1:
	            case 2:
	            case 3:
	            case 4:
	            //currentAnimation = POIPanel.GetComponent<Animation>();
	            	currentAnimation = poiAnimation;
					TogglePOI(true);

					SetPOIText(POInumber);
	            break;

	            case 5:
	           		currentAnimation = colourAnimation;
					TogglePOI(true);
				break;

	            default:
	            break;

			}
		}
	}

	}

	public void ClosePOI(){

		Debug.Log("CLOSE:" + lastPopupOpen);
		TogglePOI(false);
		isPopupOpen = false;
	}



	public void ChangeSkin(int skinNumber){
		//Debug.Log("Skin change to:" + skinNumber);

		//SkinM.SetSkinSprites(skinNumber);
	}



	public void TriggerMovie(){
		Debug.Log("TriggerMovie");
		/*if((!willOpen) || (willOpen && !isPopupOpen)){
			currentAnimation = VideoOverlayPanel.GetComponent<Animation>();
			TogglePOI(willOpen);

			isPopupOpen = willOpen;

			//MovieM.ToggleMovie(willOpen);
		}*/
		
		Handheld.PlayFullScreenMovie ("SKOPEFactoryTour.mp4", Color.black, FullScreenMovieControlMode.CancelOnInput);

		//Handheld.PlayFullScreenMovie ("SkopeMovie.mp4", Color.black, FullScreenMovieControlMode.CancelOnInput);
	}

	public void ToggleAnimation(){
		Debug.Log("ANIM2");

		AirflowAnimation.SetActive(!AirflowAnimation.activeSelf);
		Debug.Log("ANIM3");
	}

	public void AirAnim(){
		Debug.Log("AirAnim");
	}

	public void ToggleSpecs(){

		isSpecsOpen = !isSpecsOpen;

		anim = ActiveAnimation.Play(specsAnimation, "", Direction.Toggle,EnableCondition.DoNothing,DisableCondition.DoNotDisable);
	}

	public void SendEmail ()
	{
	 string email = "hello@skope.com";
	 string subject = MyEscapeURL("Skope Inquiry");
	 string body = MyEscapeURL("");
	 
	 Application.OpenURL("mailto:" + email + "?subject=" + subject + "&body=" + body);
	}
	 
	private string MyEscapeURL (string url)
	{
	 return WWW.EscapeURL(url).Replace("+","%20");
	}
}
