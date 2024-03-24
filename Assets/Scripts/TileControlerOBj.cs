using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileControlerOBj : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] BoxCollider2D colider;
    [SerializeField] Color color = Color.red;

    private void Update()
    {
        if (Gamaemenager.Isance.ispanelActive)
        {
            spriteRenderer.enabled = false;
        }
        else
        {
            spriteRenderer.color = new Color(1f, 1f, 1f, 0.5f);
            
        }
        if(Gamaemenager.Isance.tileconreolColider == null) spriteRenderer.enabled = true;

        Vector3 pozition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        

        spriteRenderer.sprite = Gamaemenager.Isance.selectedBulding.tileSprite;
        colider.size = spriteRenderer.bounds.size;
        this.transform.position = new Vector3 (pozition.x,pozition.y,this.transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Gamaemenager.Isance.tileconreolColider = collision;
        spriteRenderer.color = color;
        Debug.Log("temas");
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        Gamaemenager.Isance.tileconreolColider = null;
        spriteRenderer.color = new Color(1f, 1f, 1f, 0.5f); 
        
    }
}
