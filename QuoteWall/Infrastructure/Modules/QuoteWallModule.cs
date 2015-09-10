using QuoteWall.Data;
using Ninject;
using Ninject.Activation;
using Ninject.Modules;
using Ninject.Web.Common;
using Raven.Client;
using Raven.Client.Document;


namespace QuoteWall.Infrastructure.Modules
{
    public class QuoteWallModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IQuoteRepository>().To<QuoteRepository>().InSingletonScope(); 
            
            Bind<IDocumentStore>().ToMethod(InitDocStore).InSingletonScope();
            Bind<IDocumentSession>().ToMethod(c => c.Kernel.Get<IDocumentStore>().OpenSession()).InRequestScope();
                       
        }
        
        private IDocumentStore InitDocStore(IContext context)
        {
            var documentStore = new DocumentStore
            {
                // todo config
                Url = "http://localhost/RavenDBWeb",
                DefaultDatabase = "QuoteWallStore"
            };
            documentStore.Initialize();
                       
            return documentStore;
        }
    }
}