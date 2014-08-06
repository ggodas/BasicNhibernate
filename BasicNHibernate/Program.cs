using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;

namespace BasicNHibernate
{
    class Program
    {
        static void Main(string[] args)
        {
            Configuration cfg = new Configuration();
            //cfg.Properties["connection.provider"] = "NHibernate.Connection.DriverConnectionProvider";
            //cfg.Properties["dialect"] = "NHibernate.Dialect.MsSql2008Dialect";
            //cfg.Properties["hibernate.connection.driver_class"] = "NHibernate.Driver.SqlClientDriver";
            //cfg.Properties["connection.connection_string"] = "Data Source=177.47.30.109;Initial Catalog=CONSUMIDOR;User ID=sa;Password=sa";
            cfg.Configure(@"C:\Projetos\Labs\BasicNHibernate\BasicNHibernate\hibernate.cfg.xml");
            cfg.AddFile(@"C:\Projetos\Labs\BasicNHibernate\BasicNHibernate\Usuario.hbm.xml");
            
            ISessionFactory factory = cfg.BuildSessionFactory();
            ISession session = factory.OpenSession();
            //ITransaction transaction = session.BeginTransaction();

            var usuario = CriarUsuario();

            //session.Save(usuario);
            var usuarioRet = session.CreateCriteria<Usuario>().Add(Restrictions.Like("Nome", "%or%")).List();
            //transaction.Commit();
            session.Close();
        }

        public static Usuario CriarUsuario()
        {
            return new Usuario
            {
                Nome = "Phulano",
                Endereco = "Rua XXX, yyy",
                Idade = 20
            };
        }
    }
}
