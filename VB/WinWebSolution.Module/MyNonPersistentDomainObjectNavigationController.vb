Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.SystemModule
Imports DevExpress.Xpo

Namespace WinWebSolution.Module
	Public Class MyNonPersistentDomainObjectNavigationController
		Inherits ShowNonPersistentObjectDetailViewFromNavigationControllerBase(Of MyNonPersistentDomainObject)
		Protected Overrides Sub CustomizeNonPersistentObject(ByVal obj As MyNonPersistentDomainObject)
			MyBase.CustomizeNonPersistentObject(obj)
			obj.Name = "MyNonPersistentDomainObject"
			'Dennis: do more customizations here
		End Sub
		Protected Overrides Sub CustomizeShowViewParameters(ByVal parameters As ShowViewParameters)
			MyBase.CustomizeShowViewParameters(parameters)
			'Dennis: do more customizations here
		End Sub
	End Class
End Namespace