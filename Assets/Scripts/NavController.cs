using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;

public class NavController : MonoBehaviour {
  
    public AStar AStar;
    private Transform destination;
    private bool _initialized = false;
    private bool _initializedComplete = false;
     List<Node> path = new List<Node>();
    private int currNodeIndex = 0;
    private float maxDistance = 1.1f;



    public Transform character;


    private void Start() {
#if UNITY_EDITOR
        InitializeNavigation();
#endif
    }

    /// <summary>
    /// Returns the closest node to the given position.
    /// </summary>
    /// <returns>The closest node.</returns>
    /// <param name="point">Point.</param>
    Node ReturnClosestNode(Node[] nodes, Vector3 point) {
        float minDist = Mathf.Infinity;
        Node closestNode = null;
        foreach (Node node in nodes) {
            float dist = Vector3.Distance(node.pos, point);
            if (dist < minDist) {
                closestNode = node;
                minDist = dist;
            }
        }
        return closestNode;
    }

    public void InitializeNavigation() {
        StopAllCoroutines();
        StartCoroutine(DelayNavigation());
    }

    IEnumerator DelayNavigation() {
        while(FindObjectOfType<DiamondBehavior>() == null){
            yield return new WaitForSeconds(.5f);
            Debug.Log("waiting for shapes to load...");
        }
        InitNav();
    }

    void InitNav(){
        if (!_initialized) {
            _initialized = true;
            Debug.Log("INTIALIZING NAVIGATION!!!");
            Node[] allNodes = FindObjectsOfType<Node>();
            Debug.Log("NODES: " + allNodes.Length);
            Node closestNode = ReturnClosestNode(allNodes, transform.position);
            Debug.Log("closest: " + closestNode.gameObject.name);
            Node target = FindObjectOfType<DiamondBehavior>().GetComponent<Node>();
            Debug.Log("target: " + target.gameObject.name);
            //set neighbor nodes for all nodes
            foreach (Node node in allNodes) {
                node.FindNeighbors(maxDistance);
            }

            //get path from A* algorithm
            path = AStar.FindPath(closestNode, target, allNodes);

            if (path == null) {
                //increase search distance for neighbors
                maxDistance += .1f;
                Debug.Log("Increasing search distance: " + maxDistance);
                _initialized = false;
                InitNav();
                return;
            }

            //set next nodes 
            for (int i = 0; i < path.Count - 1; i++) {
                path[i].NextInList = path[i + 1];
            }
            //activate first node
            path[0].Activate(true);
            _initializedComplete = true;


            // intial postion for character
           // character.position = path[currNodeIndex].gameObject.transform.position;

        }
    }

  //  public Vector3 PostionOnReail(int seg, float ratio)
  //  {
       
  //              return LinearPostion(seg, ratio);
       

  //  }

  //  public Vector3 LinearPostion(int seg, float ratio)
  //  {
  //      Vector3 p1;
  //Vector3 p2;
  //   p1.x = path[seg].gameObject.transform.position.x;
  //      p1.y = path[seg].gameObject.transform.position.y - 0.9f;
  //      p1.z = path[seg].gameObject.transform.position.z;
  //     // p2 = path[seg+1].gameObject.transform.position;
  //      p2.x = path[seg + 1].gameObject.transform.position.x;
  //      p2.y = path[seg + 1].gameObject.transform.position.y -0.9f;
  //      p2.z = path[seg + 1].gameObject.transform.position.z;
  //      return Vector3.Lerp(p1, p2, ratio);
  //  }
   
  //  public Quaternion Orientation(int seg, float ratio)
  //  {
  //      Quaternion q1 = path[seg].gameObject.transform.rotation;
  //      Quaternion q2 = path[seg + 1].gameObject.transform.rotation;
  //      return Quaternion.Lerp(q1, q2, ratio);
  //  }
  //  private void OnDrawGizmos()
  //  {
  //     // Node[] allNodes = FindObjectsOfType<Node>();
  //      // Node target = FindObjectOfType<DiamondBehavior>().GetComponent<Node>();
  //      for (int i = 0; i < path.Count - 1; i++)
  //      {
  //          Handles.DrawDottedLine(path[i].gameObject.transform.position, path[i + 1].gameObject.transform.position, 3.0f);
  //      }
  //  }

  //  public Vector3 CatmullPostion(int seg, float ratio)
  //  {
  //      Vector3 p1, p2, p3, p4;
  //      if (seg == 0)
  //      {
  //          p1 = path[seg].gameObject.transform.position;
  //          p2 = p1;
  //          p3 = path[seg + 1].gameObject.transform.position;
  //          p4 = path[seg + 2].gameObject.transform.position;

  //      }
  //      else if (seg == path.Count - 2)
  //      {
  //          p1 = path[seg - 1].gameObject.transform.position;
  //          p2 = path[seg].gameObject.transform.position;
  //          p3 = path[seg + 1].gameObject.transform.position;
  //          p4 = p3;

  //      }
  //      else
  //      {
  //          p1 = path[seg - 1].gameObject.transform.position;
  //          p2 = path[seg].gameObject.transform.position;
  //          p3 = path[seg + 1].gameObject.transform.position;
  //          p4 = path[seg + 2].gameObject.transform.position;
  //      }
  //      float t2 = ratio * ratio;
  //      float t3 = t2 * ratio;
  //      float x =
  //          0.5f * ((2.0f * p2.x)
  //          + (-p1.x + p3.x) * ratio
  //          + (2.0f * p1.x - 5.0f * p2.x + 4 * p3.x - p4.x)
  //          * t2 + (-p1.x + 3.0f * p2.x - 3.0f * p3.x + p4.x)
  //          * t3);

  //      float y =
  //         0.5f * ((2.0f * p2.y)
  //         + (-p1.y + p3.y)
  //         * ratio + (2.0f * p1.y - 5.0f * p2.y + 4 * p3.y - p4.y)
  //         * t2 + (-p1.y + 3.0f * p2.y - 3.0f * p3.y + p4.y)
  //         * t3);

  //      float z =
  //         0.5f * ((2.0f * p2.z)
  //         + (-p1.z + p3.z)
  //         * ratio + (2.0f * p1.z - 5.0f * p2.z + 4 * p3.z - p4.z)
  //         * t2 + (-p1.z + 3.0f * p2.z - 3.0f * p3.z + p4.z)
  //         * t3);
  //      return new Vector3(x, y, z);
  //  }
    private void OnTriggerEnter(Collider other) {
        if (_initializedComplete && other.CompareTag("waypoint")) {
            currNodeIndex = path.IndexOf(other.GetComponent<Node>());
            if (currNodeIndex < path.Count - 1) {
                path[currNodeIndex + 1].Activate(true);
            }
        }
    }
}
