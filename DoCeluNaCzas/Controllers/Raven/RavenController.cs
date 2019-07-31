using Microsoft.AspNet.Identity.Owin;
using Raven.Client.Documents.Session;
using System;
using System.Web;
using System.Web.Mvc;

namespace DoCeluNaCzas.Controllers.Raven
{
    public abstract class RavenController : Controller
    {
        IAsyncDocumentSession _dbSession;

        protected RavenController() {}

        public IAsyncDocumentSession DbSession => _dbSession ?? (_dbSession = HttpContext.GetOwinContext().Get<IAsyncDocumentSession>());

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (!filterContext.IsChildAction)
            {
                using (DbSession)
                {
                    if (filterContext.Exception == null && DbSession != null && DbSession.Advanced.HasChanges)
                    {
                        var saveTask = DbSession.SaveChangesAsync();
                        
                        saveTask.ConfigureAwait(continueOnCapturedContext: false);
                        saveTask.Wait(TimeSpan.FromSeconds(10));
                    }
                }
            }
        }
    }
}