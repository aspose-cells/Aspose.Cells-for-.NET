Imports System.Web.Optimization

Public Class Global_asax
    Inherits HttpApplication

    Sub Application_Start(sender As Object, e As EventArgs)
        ' Fires when the application is started      
        RouteConfig.RegisterRoutes(RouteTable.Routes)
    End Sub
End Class