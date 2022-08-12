using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LevelInstaller : MonoInstaller
{
    [SerializeField] private SquareView prefab;
    
    
    public override void InstallBindings()
    {
        Container.BindInstance(prefab).WhenInjectedInto<FactoryBlock>();
        Container.BindInterfacesTo<IFactoryBlock>();
    }
}
