using System.Net;
using System.Net.Security;
using UnityEngine;
using System.Collections.Generic;

public class SQLAccess : MonoBehaviour {

	WebClient webpage;
	public DataItem[] items; 
	protected List<string> type, address, severity, email;
	public enum Request : int
	{
		read = 1,
		write = 0,
		sort = 20,
		delete = 2,
		deleteAll = 999
	}
	
	// Use this for initialization
	public void Initialize () {
		webpage = new WebClient();
		RefreshList();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RefreshList () {
		SendRequest(1);
		SendRequest(20);
		ConvertJSON();
	}

	public void SendRequest (int request) {
		
		string url = "http://2tbs.club/customapi.php?request=";
		ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });
		webpage.DownloadFile(url + request, @Application.dataPath+"/test.json");
		Debug.Log(url + request);
	}

	public void ConvertJSON () {
		System.IO.StreamReader fil =
			new System.IO.StreamReader(Application.dataPath+"/test.json", true);
		
		string content = fil.ReadLine() + ",";
		content = content.Replace("\"","").Replace("[","").Replace("]","").Replace(":","").Replace("{","");

		string[] contents = content.Split('}');

		type = extractJSON(contents, "type");
		address = extractJSON(contents, "street");
		email = extractJSON(contents, "email");
		severity = extractJSON(contents, "severity");
		
		items = new DataItem[contents.Length];
		
		Debug.Log(content);
		Debug.Log(type.Count);
		Debug.Log(address.Count);
		Debug.Log(email.Count);
		Debug.Log(severity.Count);
		Debug.Log(severity[0]);
		for(int i = 0; i < contents.Length; i++)
			items[i] = (new DataItem(type[i], address[i], severity[i], email[i]));
		Debug.Log(items.Length);
	
		fil.Close();
	}

	protected List<string> extractJSON (string[] contents, string search) {
		List<string> rtrn = new List<string>(contents.Length);
		for(int i = 0; i < contents.Length; i++) {
			try {
				rtrn.Add (contents[i].Substring(contents[i].IndexOf(search) + search.Length, (contents[i].IndexOf(",", contents[i].IndexOf(search)) - contents[i].IndexOf(search) + search.Length)));
				Debug.Log(search + (contents[i].IndexOf(search) - contents[i].IndexOf(search) + search.Length));
			} catch{}	
		}
		
		return rtrn;
	}

	public void SortList () {

	}
}


