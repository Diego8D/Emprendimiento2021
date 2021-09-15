using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Grupo dialogos", menuName = "Emprendimiento/Nuevo grupo dialogos", order = 1)]
public class DialogueLines : ScriptableObject
{
    [SerializeField] [TextArea(3, 30)] private List<string> parrafos;

    public List<string> Parrafos => parrafos;
}
