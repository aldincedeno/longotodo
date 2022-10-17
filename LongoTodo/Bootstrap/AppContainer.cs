using System;
using Autofac;
using LongoTodo.Contracts.Repository;
using LongoTodo.Contracts.Services;
using LongoTodo.Repository;
using LongoTodo.Services;
using LongoTodo.ViewModels;

namespace LongoTodo.Bootstrap
{
    public class AppContainer
    {
        private static IContainer _container;

        public AppContainer()
        {
        }

        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<TodoItemsViewModel>().SingleInstance();


            builder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();
            builder.RegisterType<GenericRepository>().As<IGenericRepository>().SingleInstance();
            builder.RegisterType<TodoItemService>().As<ITodoItemService>().SingleInstance();

            _container = builder.Build();
        }

        public static object Resolve(Type typeName)
        {
            return _container.Resolve(typeName);
        }

        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
