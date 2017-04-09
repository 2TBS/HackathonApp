using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DataItem : MonoBehaviour {

    public string type, address, severity, email;
    public Text sType, sAddress;

    public DataItem(string typ, string add, string sev, string eml) {
        type = typ;
        address = add;
        severity = sev;
        email = eml;
    }
    
    
    void Start () {
        refreshDisplay();
    }

    public void ClickAction1 () {

    }

    public void ClickAction2 () {

    }

    public void ClickAction3 () {

    }

    public void refreshDisplay () {
        sType.text = type;
        sAddress.text = address;
    }



}