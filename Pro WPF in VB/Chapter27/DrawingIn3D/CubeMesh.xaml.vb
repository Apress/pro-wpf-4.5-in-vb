Imports System.Windows.Media.Media3D

Public Class CubeMesh

    Private Function CalculateNormal(ByVal p0 As Point3D, ByVal p1 As Point3D, ByVal p2 As Point3D) As Vector3D
        Dim v0 As New Vector3D(p1.X - p0.X, p1.Y - p0.Y, p1.Z - p0.Z)
        Dim v1 As New Vector3D(p2.X - p1.X, p2.Y - p1.Y, p2.Z - p1.Z)
        Return Vector3D.CrossProduct(v0, v1)
    End Function

    Private Sub cmd_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        cubeGeometry.Geometry = CType((CType(sender, Button)).Tag, Geometry3D)
    End Sub
End Class