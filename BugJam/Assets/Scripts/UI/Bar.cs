using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bar : MonoBehaviour {
    public Transform target;
    
    
    [SerializeField] float heightOffset = 1f;
    [SerializeField] TextMeshProUGUI damageDisplay;
    [SerializeField] RectTransform healthBar;
    [SerializeField] Transform gridTransform;
    [SerializeField] Transform darkGridTransform;
    [SerializeField] Transform hpBlock;
    [SerializeField] Transform hpBlockDark;

    Unit unit;

    void Start() {
        unit = target.GetComponent<Unit>();
        SetAttackDisplay();
        SetHealthDisplay(unit.health);
        unit.onHealthChanged += UpdateHealthDisplay;
    }


    void SetAttackDisplay() {
        damageDisplay.text = unit.damage.ToString();
    }

    void SetHealthDisplay(int hp) {
        //clean grid
        int c = gridTransform.childCount;
        for (int i = 0; i < c; i++) {
            Destroy(gridTransform.GetChild(i).gameObject);
        }

        //fill grid
        float width = (hp * 15) + (hp + 1) * 5;
        for (int i = 0; i < hp; i++) {
            Instantiate(hpBlock, gridTransform);
        }

        for (int i = 0; i < hp; i++) {
            Instantiate(hpBlockDark, darkGridTransform);
        }

        healthBar.sizeDelta = new Vector2(width, 40);
    }

    void UpdateHealthDisplay(int hp) {
        //clean grid
        int c = gridTransform.childCount;
        for (int i = 0; i < c; i++) {
            Destroy(gridTransform.GetChild(i).gameObject);
        }

        //fill grid
        float width = (hp * 15) + (hp + 1) * 5;
        for (int i = 0; i < hp; i++) {
            Instantiate(hpBlock, gridTransform);
        }
    }

    void LateUpdate() {
        transform.position = Camera.main.WorldToScreenPoint(target.position + Vector3.up * unit.uiHeightOffset);
    }
}