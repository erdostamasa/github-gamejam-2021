using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {
    [SerializeField] Transform selectedQuad;
    [SerializeField] Material defaultMaterial;
    public Transform unitPosition;
    
    public int x;
    public int y;
    public bool selectable;
    public bool walkable;
    public List<Tile> neighbours;
    public Unit unit;

    // public void TileClicked() {
    //     Grid.instance.SelectTile(x, y);
    // }

    public void Select() {
        selectedQuad.GetComponent<Renderer>().material = defaultMaterial;
        selectedQuad.gameObject.SetActive(true);
    }
    
    public void Select(Material mat) {
        selectedQuad.GetComponent<Renderer>().material = mat;
        selectedQuad.gameObject.SetActive(true);
    }

    public void Unselect() {
        selectedQuad.gameObject.SetActive(false);
        selectedQuad.GetComponent<Renderer>().material = defaultMaterial;
    }
}