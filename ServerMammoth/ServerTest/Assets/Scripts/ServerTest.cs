using UnityEngine;
using System.Collections;
using UnityEngine;

public class ServerTest : MonoBehaviour {

    public string url = "http://www.sneakymammoth.com/wp-content/uploads/2014/04/Axethrower-Title.png";
    WWW www;

	// Use this for initialization
	void Start () {
        StartCoroutine(Download(url));
       
	}
	
	// Update is called once per frame
	void Update () {
       
	}
    IEnumerator Download(string url)
    {
        Texture2D texture = new Texture2D(4,4, TextureFormat.RGBA32, false);
        www = new WWW(url);
        yield return www;
        www.LoadImageIntoTexture(texture);
        
        Sprite image = Sprite.Create(texture, new Rect(0,0,texture.width, texture.height),new Vector2(.5f,.5f));
        GetComponent<SpriteRenderer>().sprite = image;
    }

}
