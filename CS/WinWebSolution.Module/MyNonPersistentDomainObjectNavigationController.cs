using System;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.Xpo;

namespace WinWebSolution.Module {
    public class MyNonPersistentDomainObjectNavigationController: ShowNonPersistentObjectDetailViewFromNavigationControllerBase<MyNonPersistentDomainObject> {
        protected override void CustomizeNonPersistentObject(MyNonPersistentDomainObject obj) {
            base.CustomizeNonPersistentObject(obj);
            obj.Name = "MyNonPersistentDomainObject";
            //Dennis: do more customizations here
        }
        protected override void CustomizeShowViewParameters(ShowViewParameters parameters) {
            base.CustomizeShowViewParameters(parameters);
            //Dennis: do more customizations here
        }
    }
}