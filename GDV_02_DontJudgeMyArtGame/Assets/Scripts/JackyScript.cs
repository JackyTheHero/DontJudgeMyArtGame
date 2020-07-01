using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JackyScript : MonoBehaviour
{

    GameObject visitor; // visitor height --> 4 tiles
    GameObject textBubble;

    // Start is called before the first frame update
    void Start()
    {
        visitor = GameObject.Find("figureWIP1");
        textBubble = GameObject.CreatePrimitive(PrimitiveType.Cube);
        textBubble.active = false;
        

    }

    // Update is called once per frame
    void Update()
    {
        if (visitor.transform.position.x < 3.0f)
        {
            visitor.transform.position += new Vector3(0.01f, 0.0f, 0.01f);
            textBubble.transform.position = visitor.transform.position + new Vector3(0.0f, 2f, 0.0f);
        }
        else {
            textBubble.active = true;
            if (textBubble.transform.position.y < 5.0f)
            {
                textBubble.transform.position += new Vector3(0.0f, 0.01f, 0.0f);
            }
        }
        textBubble.transform.Rotate(0.0f,0.1f,0.0f);
        //Debug.Log("X-Position:" + visitor.transform.position.x);
    }
}
