using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTeleporter : MonoBehaviour
{
    public Camera mapCam;
    public RectTransform mapTransform;
    public float defaultY = 10.0f;
    public MyPlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClickAction()
    {
      Vector3 clickedPosition = clickedToReal(Input.mousePosition);
      if (Physics.Raycast(clickedPosition,Vector3.down)) { //check if there is ground on the clicked location
        clickedPosition.y = defaultY;
        playerController.TeleportTo(clickedPosition);
      }
    }

    private Vector3 clickedToReal(Vector3 clickedPosition) {
      Vector2 positionOnMap;
      RectTransformUtility.ScreenPointToLocalPointInRectangle(mapTransform, clickedPosition, null, out positionOnMap);
      float xOnMap = (positionOnMap.x - mapTransform.rect.x )/ mapTransform.rect.width;
      float yOnMap = (positionOnMap.y - mapTransform.rect.y)/ mapTransform.rect.height;
      return mapCam.ViewportToWorldPoint(new Vector3(xOnMap,yOnMap,0.0f));
    }



}
