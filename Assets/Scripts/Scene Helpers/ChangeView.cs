using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeView : MonoBehaviour
{
        [SerializeField] Camera bigView;
        [SerializeField] Camera target;
        
        public void UpdateView()
        {
                bigView.transform.position = target.transform.position;
                bigView.transform.rotation = target.transform.rotation;
        }
}
