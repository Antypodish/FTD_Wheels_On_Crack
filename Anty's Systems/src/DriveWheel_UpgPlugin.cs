using System;
using UnityEngine;

// This is required, and provides necessary information to FTD, and provides some important hooks.
public class DriveWheel_UpgPlugin:FTDPlugin
{
    public void OnLoad()
    {
		Debug.Log("Loading Drive Wheel Upgrade...");
    }

    public void OnSave()
    {
    }

    // Required.
    public string name
    {
		get { return "Drive Wheel Upgrade"; }
    }

    // Also required.
    public Version version
    {
        get { return new Version("0.0.1"); }
    }
}