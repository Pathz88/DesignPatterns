using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DesignPatterns.Structural.DecoratorPattern
{
    public class DecoratorPattern
    {
        [Fact]
        void Client()
        {
            IOriginal original = new OriginalConcrete();
            original = new Decorator1(original);
            original = new Decorator2(original);

            Assert.Equal(3, original.Operation().Count());
            Assert.Contains("OriginalConcrete", original.Operation());
            Assert.Contains("Decorator1", original.Operation());
            Assert.Contains("Decorator2", original.Operation());
        }
    }

    interface IOriginal
    {
        IEnumerable<string> Operation();
    }

    class OriginalConcrete : IOriginal
    {
        private readonly List<string> _params = new List<string>();

        public OriginalConcrete()
        {
            _params.Add("OriginalConcrete");
        }

        public IEnumerable<string> Operation() 
        {
            return _params;
        }
    }

    class Decorator1 : IOriginal
    {
        private readonly IOriginal _original;
        public Decorator1(IOriginal original)
        {
            _original = original;
        }

        public IEnumerable<string> Operation()
        {
            return _original.Operation().Concat(new[] { "Decorator1" });
        }
    }

    class Decorator2 : IOriginal
    {
        private readonly IOriginal _original;
        public Decorator2(IOriginal original)
        {
            _original = original;
        }

        public IEnumerable<string> Operation()
        {
            return _original.Operation().Concat(new[] { "Decorator2" });
        }
    }
}
