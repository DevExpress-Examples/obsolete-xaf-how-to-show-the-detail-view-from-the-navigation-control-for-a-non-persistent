Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.SystemModule

Namespace WinWebSolution.Module
	Public Class ShowNonPersistentObjectDetailViewController
		Inherits ViewController
		Public Sub New()
		End Sub
		Protected Overrides Sub OnFrameAssigned()
			MyBase.OnFrameAssigned()
			AddHandler Frame.GetController(Of ShowNavigationItemController)().CustomShowNavigationItem, AddressOf ViewController1_CustomShowNavigationItem
		End Sub
		Private Sub ViewController1_CustomShowNavigationItem(ByVal sender As Object, ByVal e As CustomShowNavigationItemEventArgs)
			If e.ActionArguments.SelectedChoiceActionItem.Info.GetAttributeValue("ViewID") = Application.FindListViewId(GetType(MyNonPersistentDomainObject)) Then
				Dim objectSpaceCore As ObjectSpace = Application.CreateObjectSpace()
				Dim detailViewCore As DetailView = Application.CreateDetailView(objectSpaceCore, New MyNonPersistentDomainObject(objectSpaceCore.Session, "Test"))
				detailViewCore.ViewEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.Edit
				objectSpaceCore.CommitChanges()
				e.ActionArguments.ShowViewParameters.CreatedView = detailViewCore
				e.ActionArguments.ShowViewParameters.Context = TemplateContext.ApplicationWindow
				e.ActionArguments.ShowViewParameters.TargetWindow = TargetWindow.Current
				e.Handled = True
			End If
		End Sub
	End Class
End Namespace