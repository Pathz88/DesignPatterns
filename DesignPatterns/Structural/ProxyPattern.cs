using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DesignPatterns.Structural
{
    public class ProxyPattern
    {
        [Fact]
        public void Client()
        { 
        
        }
    }

    interface IOriginal
    {
        void Operation();
    }

    class ConcreteOriginal : IOriginal
    {
        public void Operation()
        {
            // Do operation
        }
    }

    class ProxiedOriginal : IOriginal
    {
        private readonly IOriginal _original;
        private readonly bool _extraDependancy;
        public ProxiedOriginal(bool extraDependancy)
        {
            _original = new ConcreteOriginal();
            _extraDependancy = extraDependancy;
        }

        public void Operation()
        {
            if (_extraDependancy) 
            { 
                _original.Operation();
            }
        }
    }
}
