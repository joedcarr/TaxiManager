using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TaxiManager.Customers
{
    
    public class DropOff : MonoBehaviour
    {
        public bool IsOccupied => transform.childCount > 0;
    }
    
}
