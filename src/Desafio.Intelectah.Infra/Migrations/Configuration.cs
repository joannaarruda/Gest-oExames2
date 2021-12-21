namespace Desafio.Intelectah.Infra.Migrations
{
    using Desafio.Intelectah.Infra.Data.Context;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GestaoExames2Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

       
    }
}
