using Autofac;
using TuRM.Portrait.Models;

namespace TuRM.Portrait.Other
{
    public class DataModule<T> : Module
        where T : IApplicationDbContext, new()
    {
        private string connStr;

        public DataModule()
            :this("name=DefaultConnection")
        {

        }

        public DataModule(string connString)
        {
            this.connStr = connString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new T()).As<IApplicationDbContext>().InstancePerRequest();

            base.Load(builder);
        }
    }
}