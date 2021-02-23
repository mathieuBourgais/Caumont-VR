using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zinnia.Rule;

public class TagRule : MonoBehaviour,IRule 
{
    public string selectedTag;

    public bool Accepts(object Target) {
      return Target is GameObject && ((GameObject)Target).tag == selectedTag; // target should be a game object and have thespecified tag

    }
}
