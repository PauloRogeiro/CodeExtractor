using System;
using System.Collections.Generic;
using System.Reflection;
using Castle.Core;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using MvvmFramework;
using Objects;
using BusinessObjects;
using DataService;



namespace ExtractorUI
{
    public class Bootstrapper : BootstrapperBase
    {
        private WindsorContainer container;

        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            return new[] {
                typeof (MainWindowViewModel).Assembly
            };
        }

        protected override Dictionary<Type, Type> SpecialViewModelMappings()
        {
            return new Dictionary<Type, Type>() {
                {typeof (MainWindowViewModel), typeof (MainWindowViewModel)},
            };
        }


        protected override void ConfigureForRuntime()
        {
            container = new WindsorContainer();
            container.Kernel.Resolver.AddSubResolver(new AppSettingsConvention());
            container.Register(
                Component.For<IDataSource<Menu>>()
                    .ImplementedBy<XMLSerializableDataSource<Menu>>()
                    .DependsOn(Dependency.OnValue<string>("menus.xml"))
                     ,
                Component.For<IMenuRepository>()
                    .ImplementedBy<MenuRepository>()
                    .LifestyleTransient()
                    ,
                Component.For<IEventAggregator>()
                    .ImplementedBy<EventAggregator>()
                    .LifestyleSingleton()
                    ,

                Component.For<IWindowManager>()
                    .ImplementedBy<WindowManager>()
                    .LifestyleSingleton()
                );
            RegisterViewModels();
            RegisterViews();
            container.AddFacility<TypedFactoryFacility>();
        }

        protected override void ConfigureForDesignTime()
        {
            container = new WindsorContainer();
            container.Kernel.Resolver.AddSubResolver(new AppSettingsConvention());
            container.Register(
                Component.For<IDataSource<Menu>>()
                        .ImplementedBy<XMLSerializableDataSource<Menu>>()
                        .DependsOn(Dependency.OnValue<string>("menus.xml"))
                ,
                Component.For<IMenuRepository>()
                    .ImplementedBy<MenuRepository>()
                    .LifestyleTransient()

                    ,
                Component.For<IEventAggregator>()
                    .ImplementedBy<EventAggregator>()
                    .LifestyleSingleton()
                );
            RegisterViewModels();
            RegisterViews();
            container.AddFacility<TypedFactoryFacility>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return string.IsNullOrWhiteSpace(key)
                ? container.Resolve(service)
                : container.Resolve(key, service);
        }

        private void RegisterViewModels()
        {
            container.Register(Classes.FromAssembly(typeof(MainWindowViewModel).Assembly)
                .Where(x => x.Name.EndsWith("ViewModel"))
                .Configure(x => x.LifeStyle.Is(LifestyleType.Transient)));
        }

        private void RegisterViews()
        {
            container.Register(Classes.FromAssembly(typeof(MainWindowView).Assembly)
                .Where(x => x.Name.EndsWith("View"))
                .Configure(x => x.LifeStyle.Is(LifestyleType.Transient)));
        }
    }
}