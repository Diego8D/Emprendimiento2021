using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaRestauracion : ObjetoInteractuableBase
{


    protected override void TriggerInternalEnter()
    {
        FedesoftGame.ForzarRestauracion();
    }

    protected override void TriggerInternalExit() {  }



}
