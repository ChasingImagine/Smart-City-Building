using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class TileMapModifier : MonoBehaviour
{
    
    [SerializeField] Tilemap tileMap;
    [SerializeField] Tilemap controlTilemap;

    [SerializeField] AudioSource audoSourceBuild;
    [SerializeField] AudioSource audosorceDestroy;
    [SerializeField] AudioSource audoSourceFail;


    private void Update()
    {
       

        if (Input.GetMouseButtonDown(0))
        {
            if (Gamaemenager.Isance.tileconreolColider != null)
            {
                audoSourceFail.Play();
                return;
            }
            if (UICheck()) return;
            Vector3 WorldPoziton = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int celPos = tileMap.WorldToCell(WorldPoziton);
            if(!( controlTilemap.GetTile(celPos) == Gamaemenager.Isance.selectedBulding.chackTile
                || Gamaemenager.Isance.selectedBulding.chackTile == null))
            {
                Debug.Log("bina bu araziye  yerleþtrilemez" +":  " 
                    + controlTilemap.GetTile(celPos)?.name ??"err" + ":" 
                    + (Gamaemenager.Isance.selectedBulding.chackTile?.name ?? "err"));
                return;
            }
            if (Gamaemenager.Isance.AddBuilding(celPos, Gamaemenager.Isance.selectedBulding))
            {
                tileMap.SetTile(celPos, Gamaemenager.Isance.selectedBulding.tile);
                audoSourceBuild.Play();
            }
                
            else
            {
                Debug.Log(" low money");
                audoSourceFail.Play();
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (UICheck()) return;
            Vector3 WorldPoziton = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int celPos = tileMap.WorldToCell(WorldPoziton);
            if (Gamaemenager.Isance.ExectBuilding(celPos, Gamaemenager.Isance.selectedBulding))
            {
                Debug.Log("tile: " + tileMap.GetTile(celPos)?.name);
                tileMap.SetTile(celPos, null);
                audosorceDestroy.Play();
            }
            else
            {
                Debug.Log("baþarýsz silme");
                audoSourceFail.Play();
            }
           

        }
        

    }

    private bool UICheck()
    {
       
        if (EventSystem.current.IsPointerOverGameObject())
        {
            
            Debug.Log("UI Öðesine Týklandý");
            return true;
            
        }
        return false;
    }


}
