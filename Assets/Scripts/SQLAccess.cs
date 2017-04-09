using System.Net;
using System.Net.Security;
using UnityEngine;
using System.Collections.Generic;

public class SQLAccess : MonoBehaviour {

	WebClient webpage;
	public List<string> longitude, latitude, severity, email;
	public const string url = "http://2tbs.club/customapi.php?request=1";
	// Use this for initialization
	void Start () {
		webpage = new WebClient();
		GetTable();
		ConvertJSON();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GetTable () {
		ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });
		webpage.DownloadFile(url, @Application.dataPath+"/test.json");
		Debug.Log("accessed " + url);
	}

	public void DeleteTable () {

	}

	public void ConvertJSON () {
		System.IO.StreamReader fil =
			new System.IO.StreamReader(Application.dataPath+"/test.json", true);
		
		string content = fil.ReadLine();
		content = content.Replace("\"","").Replace("[","").Replace("]","").Replace(":","").Replace("{","");

		string[] contents = content.Split('}');
		latitude = extractJSON(contents, "latitude");
		longitude = extractJSON(contents, "longitude");
		email = extractJSON(contents, "email");
		severity = extractJSON(contents, "severity");
		Debug.Log(contents[0]);
		
		fil.Close();
	}

	public List<string> extractJSON (string[] contents, string search) {
		List<string> rtrn = new List<string>(contents.Length);
		for(int i = 0; i < contents.Length; i++) {
			try {
				rtrn.Add (contents[i].Substring(contents[i].IndexOf(search) + 9, contents[i].IndexOf(",", contents[i].IndexOf(search) - contents[i].IndexOf(search) + 9)));
			} catch{}	
		}

		return rtrn;
	}
}


