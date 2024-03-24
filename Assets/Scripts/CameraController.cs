using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float speed = 20f;
    [SerializeField] float zoomSpeed = 5f;
    [SerializeField] float maxZoom = 10f; // Kameranýn maksimum yakýnlaþtýrma deðeri
    [SerializeField] float minZoom = 1f; // Kameranýn minimum yakýnlaþtýrma deðeri

    Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(2) || Input.GetKey(KeyCode.Z))
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            Vector3 moveVector = new Vector3(mouseX, mouseY, 0f) * speed * Time.deltaTime * (cam.orthographicSize)/5;
            transform.Translate(moveVector, Space.Self);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        // Yeni yakýnlaþtýrma deðerini hesapla
        float newZoom = cam.orthographicSize - scroll * zoomSpeed;

        // Yakýnlaþtýrma deðerini sýnýrla
        newZoom = Mathf.Clamp(newZoom, minZoom, maxZoom);

        // Kameranýn yakýnlaþtýrma deðerini güncelle
        cam.orthographicSize = newZoom ;
    }
}
