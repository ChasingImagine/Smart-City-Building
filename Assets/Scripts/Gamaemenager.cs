using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using ExtraTeypsForBuildingGame;

public class Gamaemenager : MonoBehaviour
{
    private static Gamaemenager _istance; 

    public SO_Building selectedBulding;
    public  static Gamaemenager Isance
    {
        get
        {
            if(_istance == null)
            {
                _istance = Instantiate(new GameObject("gameManager")).AddComponent<Gamaemenager>();
            }

            return _istance;
        }

        set
        {
            _istance = value;
        }
    }



    
    public YData source     = new();
    public XData obeyPrices = new();

    public Dictionary<Vector3Int,SO_Building> buildingDictionary = new Dictionary<Vector3Int,SO_Building>();
   
    public bool isInfintyMode =false;
    [SerializeField] float dayeTickTime = 20f;

    [HideInInspector] public float daye = 0f;
    [HideInInspector] public Collider2D tileconreolColider;
    [HideInInspector] public bool ispanelActive = false;

    [SerializeField] LoseSceneManager loseSceneManager;
    private void Awake()
    {
        if(_istance == null)
        {
            _istance = this;

        }else if(_istance !=this) Destroy(this.gameObject);
    }

    private void Start()
    {
        StartCoroutine(LoopDaye());
    }


    IEnumerator LoopDaye()
    {
        while (true)
        {
            yield return new WaitForSeconds(dayeTickTime);
            daye += 1;
            DayeCostAndGain();
        }
    }

    private void Update()
    {
        LoseControl();
        MaxControl(ref source);
    }




    void MaxControl(ref YData ydata)
    {
        MaxModifed(ref ydata.value.money, ydata.maxValue.money);
        MaxModifed(ref ydata.value.energy, ydata.maxValue.energy);
        MaxModifed(ref ydata.value.water, ydata.maxValue.water);
        MaxModifed(ref ydata.value.food, ydata.maxValue.food);
        MaxModifed(ref ydata.value.person, ydata.maxValue.person);
    }


    void MaxModifed(ref float value,float max)
    {
        if(value > max) value = max;
    }


    void LoseControl()
    {
        if(source.value.money <0 && !isInfintyMode)
        {
            //lose code
            Debug.Log("kaybetin");
            loseSceneManager.Lose();
        }
    }

    public bool AddBuilding(Vector3Int key,SO_Building building)
    {
        if (buildingDictionary.ContainsKey(key)) return false;
        if (!CostControlAndAplay(building.start,ref source.value,false)) return false;
        if (!CostControlAndAplay(building.capastyUp, ref source.maxValue, false)) return false;

        buildingDictionary.Add(key, building);
        return true;
    }


  

    public bool ExectBuilding(Vector3Int key, SO_Building building)
    {
        if (!buildingDictionary.ContainsKey(key))
        {
            Debug.Log("key yok" + " :  " + key);
            return false;
        }
            

        if (!CostControlAndAplay( ToNegativeXData( building.destroing), ref source.value, true))
        {
            Debug.Log("yetrli yokettme kaynagý yok"+ " :  " + building.buildingName);
            return false;
        }
           

        if (!CostControlAndAplay(ToNegativeXData(building.capastyUp), ref source.maxValue, true))
        {
            Debug.Log("yokedilme sýrsýnda düþlecek kadar kapsite yok" + " :  " + building.buildingName);
            return false;
        }
            

        buildingDictionary.Remove(key);
        return true;
    }


    private void DayeCostAndGain()
    {
        foreach (KeyValuePair<Vector3Int,SO_Building> kvp in buildingDictionary)
        {
            CostControlAndAplay(kvp.Value.daye,ref source.value, true);
        }
    }

    private XData ToNegativeXData(XData value)
    {
        XData result = value;

        result.money  *= -1;
        result.energy *= -1;
        result.water  *= -1;
        result.food   *= -1;
        result.person *= -1;

        return result;

    }

    private bool CostControlAndAplay(XData value, ref XData sourceValue,bool forced)
    {
        XData result = sourceValue;
       
        result.money  += value.money;
        result.energy += value.energy;
        result.water  += value.water;
        result.food   += value.food;
        result.person += value.person;

        if(result.person <0 && !isInfintyMode )
        {
            Debug.Log("yetrsiz personel");
            return false;
        }

        result.money -= Obey(ref result.energy,obeyPrices.energy);
        result.money -= Obey(ref result.water, obeyPrices.water);
        result.money -= Obey(ref result.food,obeyPrices.food);
        


        if ( result.money < 0 && !forced && !isInfintyMode)
        {
            Debug.Log("yetersiz para");
            return false;
        }

        sourceValue = result;


        return true;
    }


    private float Obey(ref float value ,float price)
    {
        float resolt;
        if(value < 0)
        {
            resolt = -value *price;
            value = 0f;
            return resolt;
        }

        return 0f;

    }


}




