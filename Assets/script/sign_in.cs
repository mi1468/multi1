using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;
using UnityEngine.UI;

public class sign_in : MonoBehaviour {
  
    public string matn, email, name, pasword;
    public InputField  in_email, in_pasword;
    private SocketIOComponent socket;
    public string Md5Sum(string strToEncrypt)
    {
        System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding();
        byte[] bytes = ue.GetBytes(strToEncrypt);

        // encrypt bytes
        System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
        byte[] hashBytes = md5.ComputeHash(bytes);

        // Convert the encrypted bytes back to a string (base 16)
        string hashString = "";

        for (int i = 0; i < hashBytes.Length; i++)
        {
            hashString += System.Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');
        }

        return hashString.PadLeft(32, '0');
    }
	// Use this for initialization
    void Start()
    {

        GameObject go = GameObject.Find("SocketIO");
        socket = go.GetComponent<SocketIOComponent>();
       
    }
	
	
	// Update is called once per frame
	void Update () {
		
	}
    public void sign_btn()
    {
      
        email = in_email.text;
        pasword = in_pasword.text;
        pasword = Md5Sum(pasword + "hehe");
        matn = "{\"email\":\"" + email + "\",\"pasword\":\"" + pasword + "\"}";
        socket.Emit("sign_in", new JSONObject(matn));
    }
}
