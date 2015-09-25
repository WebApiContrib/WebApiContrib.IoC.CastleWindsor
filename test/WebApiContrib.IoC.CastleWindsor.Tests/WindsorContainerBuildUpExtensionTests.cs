namespace WebApiContrib.IoC.CastleWindsor.Tests
{
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;

    using NUnit.Framework;

    [TestFixture]
    public class WindsorContainerBuildUpExtensionTests
    {
        private interface IPerson
        {
        }

        [Test]
        public void Should_Inject_Dependency()
        {
            var container = new WindsorContainer();
            container.Register(Component.For<IPerson>().ImplementedBy<PersonA>());

            var instance = new TestClass();

            container.BuildUp(instance);

            Assert.IsInstanceOf<PersonA>(instance.Person);
        }

        [Test]
        public void Should_Not_Inject_Dependency_When_Injected_Property_Is_Instantiated()
        {
            var container = new WindsorContainer();
            container.Register(Component.For<IPerson>().ImplementedBy<PersonA>());

            var instance = new TestClass() { Person = new PersonB() };

            container.BuildUp(instance);

            Assert.IsInstanceOf<PersonB>(instance.Person);
        }

        [Test]
        public void Should_Not_Inject_Dependency_When_Property_Is_Not_Decorated_With_Dependency_Attribute()
        {
            var container = new WindsorContainer();
            container.Register(Component.For<IPerson>().ImplementedBy<PersonA>());

            var instance = new TestClass() { Person = new PersonB() };

            container.BuildUp(instance);

            Assert.IsNull(instance.AnotherPerson);
        }

        [Test]
        public void Should_Return_Null_When_Type_Is_Not_Instantiated()
        {
            var container = new WindsorContainer();
            container.Register(Component.For<IPerson>().ImplementedBy<PersonA>());

            TestClass instance = null;

            Assert.IsNull(container.BuildUp(instance));
        }

        private class TestClass
        {
            public IPerson AnotherPerson { get; set; }

            [Dependency]
            public IPerson Person { get; set; }
        }

        private class PersonA : IPerson
        {
        }

        private class PersonB : IPerson
        {
        }
    }
}