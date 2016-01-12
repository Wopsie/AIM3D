using UnityEngine;
using System.Collections;

public class Lines : MonoBehaviour
{
    public GameObject makeLine(Vector3 to, Color kleur)
    {
        var tempobject = new GameObject("line");
        //tempobject.transform.parent = this.transform;
        var templine = tempobject.AddComponent<LineRenderer>();
        templine.SetWidth(10f, 10f);
        templine.material = new Material(Shader.Find("Particles/Additive"));
        templine.SetColors(kleur, kleur);
        templine.SetPosition(0, this.transform.position);
        templine.SetPosition(1, to);
        return tempobject;
    }

    public void drawLineTo(GameObject line, Vector3 from, Vector3 to)
    {
        line.GetComponent<LineRenderer>().SetPosition(0, from);
        line.GetComponent<LineRenderer>().SetPosition(1, to);
    }
}