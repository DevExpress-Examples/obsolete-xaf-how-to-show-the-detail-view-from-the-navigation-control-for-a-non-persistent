Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.SystemModule
Imports DevExpress.Xpo
Imports DevExpress.Persistent.BaseImpl

Namespace WinWebSolution.Module
	Public MustInherit Class ShowNonPersistentObjectDetailViewFromNavigationControllerBase(Of NonPersistentObjectType As XPCustomObject)
		Inherits ViewController
		Private Const DefaultReason As String = "ShowNonPersistentObjectDetailViewFromNavigationControllerBase is active"
		Public Sub New()
			TargetObjectType = GetType(NonPersistentObjectType)
		End Sub
		Protected Overrides Sub OnFrameAssigned()
			MyBase.OnFrameAssigned()
			AddHandler Frame.GetController(Of ShowNavigationItemController)().CustomShowNavigationItem, AddressOf OnCustomShowNavigationItem
		End Sub
		Protected Overrides Sub OnActivated()
			MyBase.OnActivated()
			UpdateControllersState(False)
		End Sub
		Protected Overrides Sub OnDeactivating()
			MyBase.OnDeactivating()
			UpdateControllersState(True)
		End Sub
		Protected Overridable Sub UpdateControllersState(ByVal flag As Boolean)
			Frame.GetController(Of DetailViewController)().Active(DefaultReason) = flag
			Frame.GetController(Of DeleteObjectsViewController)().Active(DefaultReason) = flag
			Frame.GetController(Of NewObjectViewController)().Active(DefaultReason) = flag
			Frame.GetController(Of FilterController)().Active(DefaultReason) = flag
			Frame.GetController(Of ViewNavigationController)().Active(DefaultReason) = flag
			Frame.GetController(Of RecordsNavigationController)().Active(DefaultReason) = flag
		End Sub
		Private Sub OnCustomShowNavigationItem(ByVal sender As Object, ByVal e As CustomShowNavigationItemEventArgs)
			If e.ActionArguments.SelectedChoiceActionItem.Info.GetAttributeValue("ViewID") = Application.FindListViewId(GetType(NonPersistentObjectType)) Then
				Dim os As ObjectSpace = ObjectSpaceInMemory.CreateNew()
				Dim obj As NonPersistentObjectType = CreateNonPersistemObject(os)
				CustomizeNonPersistentObject(obj)
				Dim dv As DetailView = Application.CreateDetailView(os, obj)
				e.ActionArguments.ShowViewParameters.CreatedView = dv
				CustomizeShowViewParameters(e.ActionArguments.ShowViewParameters)
				e.Handled = True
			End If
		End Sub
		Protected Overridable Function CreateNonPersistemObject(ByVal objectSpace As ObjectSpace) As NonPersistentObjectType
			Return objectSpace.CreateObject(Of NonPersistentObjectType)()
		End Function
		Protected Overridable Sub CustomizeShowViewParameters(ByVal parameters As ShowViewParameters)
			parameters.Context = TemplateContext.ApplicationWindow
			parameters.TargetWindow = TargetWindow.Current
			CType(parameters.CreatedView, DetailView).ViewEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.Edit
		End Sub
		Protected Overridable Sub CustomizeNonPersistentObject(ByVal obj As NonPersistentObjectType)
		End Sub
	End Class
End Namespace