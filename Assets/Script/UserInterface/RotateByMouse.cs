using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateByMouse : MonoBehaviour
{
    /*
     * Important Credit: the following code is exactly copied from the YouTube Tutorial "Unity Tutorials: Look at Mouse on Screen"
     * Made by Ather Omar
     * https://www.youtube.com/watch?v=-376PylZ5l4
     */
    void Update()
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        float midPoint = (transform.position - Camera.main.transform.position).magnitude * 0.5f;
        transform.LookAt(mouseRay.origin + mouseRay.direction * midPoint);
    }
}
