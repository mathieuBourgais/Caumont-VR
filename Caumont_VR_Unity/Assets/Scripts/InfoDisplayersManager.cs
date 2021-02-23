using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InfoDisplayersManager : MonoBehaviour
{
    static public float maxPlayerDistance = 15.0f;
    static public float playerLostDistance = 25.0f;
    private List<GameObject> displayersList;
    public GameObject player;
    public string displayerTag = "InfoDisplayer";
    private GameObject nearestDisplayer;
    public GameObject pathIndicator;
    private UnityEngine.AI.NavMeshAgent agent;
    public GameObject hudRightArrow;
    public GameObject hudLeftArrow;
    // Start is called before the first frame update
    void Start()
    {
        displayersList = new List<GameObject>(GameObject.FindGameObjectsWithTag(displayerTag));
        if (displayersList.Count != 0) {
          float minDistance = -1.0f;
          float distanceToPlayer = 0.0f;
          foreach (GameObject displayer in displayersList) {
              distanceToPlayer = Vector3.Distance(player.GetComponent<Transform>().position, displayer.GetComponent<Transform>().position);
              if (minDistance < 0.0f || minDistance > distanceToPlayer) {
                nearestDisplayer = displayer;
                minDistance = distanceToPlayer;
              }
          }
          agent = pathIndicator.GetComponent<UnityEngine.AI.NavMeshAgent>();
          agent.SetDestination(nearestDisplayer.GetComponent<Transform>().position);
        }



    }

    // Update is called once per frame
    void Update()
    {
        if (displayersList.Count != 0) {
          displayersList.RemoveAll(IsVisited); // the indicator won't search for the already vivited displayers
          if (pathIndicator.activeSelf) {
              UpdateHUDArrows();
              float minDistance = -1.0f;
              float distanceToPlayer = 0.0f;
              foreach (GameObject displayer in displayersList) {
                    distanceToPlayer = Vector3.Distance(player.GetComponent<Transform>().position, displayer.GetComponent<Transform>().position);
                    if (minDistance < 0.0f || minDistance > distanceToPlayer) {
                        nearestDisplayer = displayer;
                        minDistance = distanceToPlayer;
                    }
                  }


              float playerIndicatorDistance = Vector3.Distance(player.GetComponent<Transform>().position, pathIndicator.GetComponent<Transform>().position);
              // prevent the path indicator to go too far from the player
              NavMeshHit destinationHit;

              if ( playerIndicatorDistance > maxPlayerDistance) {
                  NavMesh.SamplePosition(player.GetComponent<Transform>().position, out destinationHit, Mathf.Infinity, NavMesh.AllAreas);
                  // agent.SetDestination(player.GetComponent<Transform>().position);
              } else {
                NavMesh.SamplePosition(nearestDisplayer.GetComponent<Transform>().position, out destinationHit, Mathf.Infinity, NavMesh.AllAreas);

                // agent.SetDestination(nearestDisplayer.GetComponent<Transform>().position);
              }
              agent.SetDestination(destinationHit.position);
              if (playerIndicatorDistance > playerLostDistance) {
                agent.Warp(destinationHit.position);
              }
          }

        }
    }

    private static bool IsVisited(GameObject displayer) {
        return displayer.GetComponent<DisplayInfo>().visited;
    }

    private void UpdateHUDArrows() {
      if (pathIndicator.activeSelf) {

        Vector3 pathIndicatorDirection = pathIndicator.GetComponent<Transform>().position-player.GetComponent<Transform>().position ;
        // compute angle between player facing direction and pathIndicator direction (only on horizontal axis)
        float playerIndicatorAngle = Vector3.SignedAngle(player.GetComponent<Transform>().forward, pathIndicatorDirection, Vector3.up);
        if (playerIndicatorAngle > 45) {
          hudRightArrow.SetActive(true);
          hudLeftArrow.SetActive(false);
        } else if (playerIndicatorAngle < -45) {
          hudLeftArrow.SetActive(true);
          hudRightArrow.SetActive(false);
        } else {
          hudRightArrow.SetActive(false);
          hudLeftArrow.SetActive(false);
        }
      }

    }

    public void TogglePathIndicator() {
      pathIndicator.SetActive(!pathIndicator.activeSelf);
      if (pathIndicator.activeSelf) {
        //pathIndicator.GetComponent<Transform>().position = player.GetComponent<Transform>().position;
        agent.Warp(player.GetComponent<Transform>().position);
      } else {
        hudRightArrow.SetActive(false);
        hudLeftArrow.SetActive(false);
      }


    }


}
