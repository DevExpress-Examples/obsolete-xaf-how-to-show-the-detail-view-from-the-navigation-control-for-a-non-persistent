using System;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.SystemModule;

namespace WinWebSolution.Module {
    public class ShowNonPersistentObjectDetailViewController : ViewController {
        public ShowNonPersistentObjectDetailViewController() {
        }
        protected override void OnFrameAssigned() {
            base.OnFrameAssigned();
            Frame.GetController<ShowNavigationItemController>().CustomShowNavigationItem += new EventHandler<CustomShowNavigationItemEventArgs>(ViewController1_CustomShowNavigationItem);
        }
        void ViewController1_CustomShowNavigationItem(object sender, CustomShowNavigationItemEventArgs e) {
            if (e.ActionArguments.SelectedChoiceActionItem.Info.GetAttributeValue("ViewID") == Application.FindListViewId(typeof(MyNonPersistentDomainObject))) {
                ObjectSpace objectSpaceCore = Application.CreateObjectSpace();
                DetailView detailViewCore = Application.CreateDetailView(objectSpaceCore, new MyNonPersistentDomainObject(objectSpaceCore.Session, "Test"));
                detailViewCore.ViewEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.Edit;
                objectSpaceCore.CommitChanges();
                e.ActionArguments.ShowViewParameters.CreatedView = detailViewCore;
                e.ActionArguments.ShowViewParameters.Context = TemplateContext.ApplicationWindow;
                e.ActionArguments.ShowViewParameters.TargetWindow = TargetWindow.Current;
                e.Handled = true;
            }
        }
    }
}