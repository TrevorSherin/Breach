using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicInfo
{
    private string name;
    private string description;
    private Sprite icon;

    public BasicInfo(string iName)
    {
        name = iName;
    }

    public BasicInfo(string iName, string iDescription)
    {
        name = iName;
        description = iDescription;
    }

    public BasicInfo(string iName, string iDescription, Sprite iIcon)
    {
        name = iName;
        description = iDescription;
        icon = iIcon;
    }
    
    public string Name
    {
        get { return name; }
    }

    public string Description
    {
        get { return description; }
    }

    public Sprite Icon
    {
        get { return icon; }
    }
}
