using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using System.IO;

namespace BasicNHibernate
{
    class Program
    {
        static void Main(string[] args)
        {
            Configuration cfg = Configure();

            var diretorio = Directory.GetCurrentDirectory();
            
            ISessionFactory factory = cfg.BuildSessionFactory();
            ISession session = factory.OpenSession();
            //ITransaction transaction = session.BeginTransaction();

            var usuario = CriarUsuario();

            session.Save(usuario);
            var usuarioRet = session.CreateCriteria<Usuario>().Add(Restrictions.Like("Nome", "%or%")).List();
            //transaction.Commit();
            session.Close();
        }

        private static Configuration Configure()
        {
            var cfg = new Configuration();
            cfg.Configure(@"..\..\NHConf\hibernate.cfg.xml");
            cfg.AddFile(@"..\..\NHConf\\Usuario.hbm.xml");

            return cfg;
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
