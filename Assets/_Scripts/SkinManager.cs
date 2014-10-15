using UnityEngine;
using System.Collections;

public class SkinManager : MonoBehaviour {

	public GameObject sprite1;

	public Texture [] sprite1skins;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetSkinSprites(int spriteNumber){

		sprite1.renderer.material.mainTexture = sprite1skins[spriteNumber-1];
	}
}
