using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Audio
{

    public class Bullet
    {
        private readonly AK.Wwise.Event Grappling_Impact;

        public void PlayGrapplingImpact(GameObject gameObject)
        {
            Grappling_Impact.Post(gameObject);
        }

    }
}
