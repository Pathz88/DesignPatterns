using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DesignPatterns.Structural.AdapterPattern
{
    public class AdapterPattern
    {
        [Fact]
        public void Client()
        {
            var componentB = new ComponentB("B");
            var componentA = new ComponentB_To_ComponentA_Adapter(componentB, "extraDependacyValue");
        }
    }

    public sealed class ComponentB_To_ComponentA_Adapter : IComponentA
    {
        private readonly ComponentB _componentB;
        private readonly string _extaDependancy;

        public ComponentB_To_ComponentA_Adapter(ComponentB componentB, string extaDependancy)
        {
            _componentB = componentB;
            _extaDependancy = extaDependancy;
        }

        public string Operation1()
        {
            return _componentB.Active ? _componentB.Operation1() : _extaDependancy;
        }
    }

    public interface IComponentA
    {
        string Operation1();
    }

    public class ConcreteComponentA : IComponentA
    {
        private readonly string _param;

        public ConcreteComponentA(string param)
        {
            _param = param;
        }

        public string Operation1()
        {
            return _param;
        }
    }

    public class ComponentB
    {
        private readonly string _param;
        public bool Active { get; private set; }

        public ComponentB(string param)
        {
            Active = false;
            _param = param;
        }

        public void Activate()
        {
            Active = true;
        }

        public string Operation1() 
        {
            return _param;
        }
    }
}
