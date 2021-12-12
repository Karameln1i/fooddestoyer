using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestroyTransition : Transition
{
    [SerializeField] private DistanceTransition _distanceTransition;
    [SerializeField] private ChangeTargetPosition _changeTargetPosition;
    [SerializeField] private List<Item> _items;

    public event UnityAction Launched;

    private void OnEnable()
   {
       Launched?.Invoke();
       _distanceTransition.Launched += OnDistanceTransitionLaunched;

       _changeTargetPosition.TargetAchived += OnTargetAchived;
       
       for (int i = 0; i < _items.Count; i++)
       {
           //_items[i].Destroyed += OnItemDestroyed;
       }
   }

   private void OnDistanceTransitionLaunched()
   {
       _distanceTransition.Launched -= OnDistanceTransitionLaunched;
        NeedTransit = false;
    }
   
   private void OnItemDestroyed(Item item)
   {
 
      /* item.Destroyed -= OnItemDestroyed;
       _items.Remove(item);
       if (_items.Count!=0)
       {
           NeedTransit = true;
       }
       //NeedTransit = true;*/
   }

   private void OnTargetAchived()
   {
       NeedTransit = true;
   }
   
}
