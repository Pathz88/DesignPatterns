using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Creational.AbstractFactoryPattern
{
    public class AbstractFactoryPattern
    {
        [Theory]
        [InlineData("runtimeParam1")]
        [InlineData("runtimeParam2")]
        public void Client(string runtimeParam)
        {
            var list = new List<int>();
            var param1 = "From external source1";
            var param2 = "From external source2";

            var factories = new Dictionary<string, IFactory>
            {
                { "runtimeParam1", new ConcreteFactory1(list, param1) },
                { "runtimeParam2", new ConcreteFactory2(param2) }
            };

            var factory = factories[runtimeParam];
            var productA = factory.CreateProductA(1);
            var productB = factory.CreateProductB("");
        }
    }

    interface IFactory
    {
        IProductA CreateProductA(int param);
        IProductB CreateProductB(string param);
    }

    interface IProductA 
    {
        public int P { get; }
    }
    interface IProductB 
    {
        public string P { get; }
    }

    //  Family1

    class ConcreteFactory1 : IFactory
    {
        private readonly IEnumerable<int> _param1;
        private readonly string _param2;

        // Dependencies used by family of objects.
        public ConcreteFactory1(IEnumerable<int> param1, string param2)
        {
            _param1 = param1;
            _param2 = param2;
        }


        public IProductA CreateProductA(int param)
        {
            return new ProductA1(_param1.Concat(new[] { param }));
        }

        public IProductB CreateProductB(string param)
        {
            return new ProductB1(_param2 + param);
        }
    }

    class ProductA1 : IProductA 
    {
        public int P { get; }

        public ProductA1(IEnumerable<int> param)
        {
            P = param.Sum();
        }
    }
    
    class ProductB1 : IProductB
    {
        public string P { get; }

        public ProductB1(string param)
        {
            P = param;
        }
    }

    class ConcreteFactory2 : IFactory
    {
        public ConcreteFactory2(string param)
        {
            
        }
        public IProductA CreateProductA(int param)
        {
            throw new NotImplementedException();
        }

        public IProductB CreateProductB(string param)
        {
            throw new NotImplementedException();
        }
    }

    class ProductA2 : IProductA
    {
        public int P { get; }

        public ProductA2(int param)
        {
            P = param;
        }
    }

    class ProductB2 : IProductB 
    { 
        public string P { get; }

        public ProductB2(IEnumerable<string> prarm)
        {
            P = string.Join("-", prarm);
        }
    }
}
