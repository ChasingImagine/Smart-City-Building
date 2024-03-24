using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using ExtraTeypsForBuildingGame;

[CreateAssetMenu(fileName = "Item", menuName = "SO/Item")]
public class SO_Building : ScriptableObject
{

    [Header("base")]
    public TileBase tile;
    public Sprite   tileSprite;
    public string   buildingName;

    [TextArea(1,20)]
    public string description;
    [Header("chack")]
    public Tile chackTile;


    [Header("data")]
    public XData start    = new XData();
    public XData capastyUp = new XData();
    public XData daye        = new XData();
    public XData destroing = new XData();
    


   

    static string startGaiString  = "Kurlum maliyeti";
    static string dayeGainSting    = "Günlük Kazanç";
    static string capastyUpString = "Ek kapasite";



   static string moneyString  = "altýn";
   static string energyString = "enerji";
   static string foodString   = "gýda";
   static string waterString  = "su";
   static string personString = "iþgücü";


    public string GetData()
    {
        string result = "";
        
        result += (GetDataPart(start) != "" ? startGaiString : "" ) + "<br>" + GetDataPart(start ) + "<br>";
        

        result += ( GetDataPart(capastyUp) != "" ? capastyUpString :"") + "<br>" + GetDataPart(capastyUp)  + "<br>";
        result += (GetDataPart(daye) != "" ?dayeGainSting  :"") + "<br>" + GetDataPart(daye  ) + "<br>";

        result += description;

        return result;
    }

    private string GetDataPart(XData xData)
    {
        string result = "";
        result =
             AddColour(Control(xData.money,  moneyString),    ColorCodeForValue(xData.money))
           + AddColour(Control(xData.energy, energyString),   ColorCodeForValue(xData.energy))
           + AddColour(Control(xData.water,  waterString),    ColorCodeForValue(xData.water))
           + AddColour(Control(xData.food,   foodString),     ColorCodeForValue(xData.food))
           + AddColour(Control(xData.person, personString),   ColorCodeForValue(xData.person));
        return result;
    }

    private string Control(float value,string valueName)
    {
        string result = "";

        result  =  value == 0 ? "" : " " + value +  " "+ valueName;

        return result;
    }

    public string AddColour(string value, string colorname)
    {
        if (colorname =="") return value;
        return "<color=\"" + colorname + "\">" + value + "</color>";
    }

    public string ColorCodeForValue(float value ,string s1="" ,string s2="red" ,string s3="green")
    {
        return (value == 0 ? "" : value < 0 ? s2 : s3);
    }



}


