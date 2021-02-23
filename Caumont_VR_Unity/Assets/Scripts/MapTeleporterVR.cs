using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MapTeleporterVR : MonoBehaviour
{
  public Camera mapCam;
  public RectTransform mapTransform;
  //  public float defaultY = 10.0f;
  public VRCharacterController playerController;
  public Transform pointerTransform;
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
    Vector3 clickedPosition = clickedToReal(pointerTransform.position);
    RaycastHit hit;
    if (Physics.Raycast(clickedPosition,Vector3.down, out hit)) { //check if there is ground on the clicked location
      clickedPosition = hit.point;
      playerController.TeleportTo(clickedPosition);
    }
  }

  private Vector3 clickedToReal(Vector3 clickedPosition) {
    Vector3[] corners = new Vector3[4];
    mapTransform.GetWorldCorners(corners);
    Vector3 relativePos = clickedPosition-corners[0];
    Vector3 xAxis = corners[3]-corners[0];
    Vector3 yAxis = corners[1]-corners[0];
    float xOnMap = Vector3.Dot(relativePos,xAxis) / xAxis.sqrMagnitude;
    float yOnMap = Vector3.Dot(relativePos,yAxis) / yAxis.sqrMagnitude;
    /*
    Vector3 positionOnMap = mapTransform.InverseTransformPoint(clickedPosition);
      //RectTransformUtility.ScreenPointToLocalPointInRectangle(mapTransform, clickedPosition, null, out positionOnMap);
    float xOnMap = (positionOnMap.x - mapTransform.rect.x )/ mapTransform.rect.width;
    float yOnMap = (positionOnMap.y - mapTransform.rect.y)/ mapTransform.rect.height;
    */
    return mapCam.ViewportToWorldPoint(new Vector3(xOnMap,yOnMap,0.0f));
  }

}
