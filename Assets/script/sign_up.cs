using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;
using UnityEngine.UI;

public class sign_up : MonoBehaviour {
    public GameObject email_tekrari_panel,menu_panel;
    public InputField in_name,in_email,in_pasword;
    public string matn,email,name,pasword;
    private SocketIOComponent socket;
    
	// Use this for initialization

	void Start () {
        email_tekrari_panel.SetActive(false);
        GameObject go = GameObject.Find("SocketIO");
        socket = go.GetComponent<SocketIOComponent>();
        socket.On("email_tekrari", email_tekrari);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void sign_up_btn()
    {
        name = in_name.text;
        email = in_email.text;
        pasword = in_pasword.text;
        pasword = Md5Sum(pasword+"hehe");
         matn = "{\"name\":\"" + name + "\",\"email\":\"" + email + "\",\"pasword\":\"" + pasword + "\"}";
         socket.Emit("add user", new JSONObject(matn));
    }
    private void email_tekrari(SocketIOEvent e)
    {

        email_tekrari_panel.SetActive(true);
    }
    public void email_tekrari_btn()
    {
        email_tekrari_panel.SetActive(false);
    }
    public void back_btn()
    {
        menu_panel.SetActive(true);
        gameObject.SetActive(false);
    }
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
}
