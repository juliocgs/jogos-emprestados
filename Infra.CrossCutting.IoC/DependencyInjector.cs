using Application.AutoMapper;
using AutoMapper;
using Domain.Interfaces;
using Domain.Interfaces.Validations;
using Domain.Validations;
using Infra.Data.UoW;
using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Web.Common;
using System;

namespace Infra.CrossCutting.IoC
{
    public class DependencyInjector
    {
        public static void RegisterServices(IKernel kernel)
        {
            // Unit of Work
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();

            // Validations
            RegisterValidations(kernel);

            // AutoMapper
            var mapperConfiguration = AutoMapperConfig.RegisterMappings();
            kernel.Bind<MapperConfiguration>().ToConstant(mapperConfiguration).InSingletonScope();
            kernel.Bind<IMapper>().ToMethod(ctx => new Mapper(mapperConfiguration, type => kernel.Get(type)));

            // Generic Injection
            kernel.Bind(x => x.FromAssembliesMatching("*")
                .SelectAllClasses()
                .Excluding<UnitOfWork>()
                .Excluding<Mapper>()
                .Excluding(GetExcludingValidations())
                .BindDefaultInterface()
            );
        }

        private static void RegisterValidations(IKernel kernel)
        {
            kernel.Bind<IGameValidation>().To<GameValidation>().InRequestScope();
            kernel.Bind<IFriendValidation>().To<FriendValidation>().InRequestScope();
            kernel.Bind<IUserValidation>().To<UserValidation>().InRequestScope();
        }

        private static Type[] GetExcludingValidations()
        {
            return new Type[] {
                typeof(GameValidation),
                typeof(FriendValidation),
                typeof(UserValidation)
            };
        }
    }
}
