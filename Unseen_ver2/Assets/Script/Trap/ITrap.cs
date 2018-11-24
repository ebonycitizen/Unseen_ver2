using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ITrap : MonoBehaviour{
    public bool isTrigger { get; set; }

    protected Transform startPosition;

	void Awake () {
        startPosition = this.transform;
    }

    public virtual void Initialize() { } // isTrigger -> false、 表示
    public virtual void UpdateTrap() { }//!istrigger ->return
    public virtual void Disable() { } //非表示
}