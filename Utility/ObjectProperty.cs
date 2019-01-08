using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectProperty : MonoBehaviour {
    private Vector3 scale;
    private Color color;


    public List<Property> propertyList = new List<Property>();

    private void Start()
    {
        scale = GetComponent<Transform>().localScale;
        color = GetComponent<MeshRenderer>().material.color;
        Property prop1 = new Property(scale);
        Property prop2 = new Property(color);
        propertyList.Add(prop1);
        propertyList.Add(prop2);

    }
    public void UpdateProperty() {

    }
}

public class Property {
    System.Type propertyType;
    public object property;
    public string name;

    public Property(GameObject variable) {
        propertyType = variable.GetType();
        property = variable;
        name = variable.name;
    }

    public Property(object variable) {
        propertyType = variable.GetType();
        property = variable;
        name = variable.ToString();
    }
}
