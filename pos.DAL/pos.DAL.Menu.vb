Imports System.Data.SqlClient
Imports pos.BO
Imports pos.Interface

Public Class CrudMenu
    Implements IMasterMenu
    Private _conn As SqlConnection
    Private strConn As String
    Private cmd As SqlCommand
    Private dr As SqlDataReader
    Public Sub New()
        strConn = "Server=.\SQLEXPRESS01;Database=pos_resto;Trusted_Connection=True;"
        _conn = New SqlConnection(strConn)
    End Sub

    Public Function GetById(id As Integer) As List(Of MasterMenu) Implements IMasterMenu.GetById
        Dim listMenu As New List(Of MasterMenu)
        Try
            Dim strSP = "sp_GetMenu"
            cmd = New SqlCommand(strSP, _conn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@id_menu", id)
            _conn.Open()
            dr = cmd.ExecuteReader()
            While dr.Read()
                Dim menu As New MasterMenu
                menu.id_menu = dr("id_menu")
                menu.nama_menu = dr("nama_menu")
                menu.harga_menu = dr("harga_menu")
                menu.deskripsi_menu = dr("deskripsi_menu")
                listMenu.Add(menu)
            End While
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            _conn.Close()
            _conn.Dispose()
        End Try
        Return listMenu
    End Function

    Public Function Create(obj As MasterMenu) As Integer Implements ICrud(Of MasterMenu).Create
        Dim result As Object
        Try
            Dim strSP = "sp_InsertMenu"
            cmd = New SqlCommand(strSP, _conn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@nama_menu", obj.nama_menu)
            cmd.Parameters.AddWithValue("@harga_menu", obj.harga_menu)
            cmd.Parameters.AddWithValue("@deskripsi_menu", obj.deskripsi_menu)
            _conn.Open()
            result = cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            _conn.Close()
            _conn.Dispose()
        End Try
        Return result
    End Function

    Public Function GetAll() As List(Of MasterMenu) Implements ICrud(Of MasterMenu).GetAll
        Dim listMenu As New List(Of MasterMenu)
        Try
            Dim strSP = "sp_GetAllMenu"
            cmd = New SqlCommand(strSP, _conn)
            cmd.CommandType = CommandType.StoredProcedure
            _conn.Open()
            dr = cmd.ExecuteReader()
            While dr.Read()
                Dim menu As New MasterMenu
                menu.id_menu = dr("id_menu")
                menu.nama_menu = dr("nama_menu")
                menu.harga_menu = dr("harga_menu")
                menu.deskripsi_menu = dr("deskripsi_menu")
                listMenu.Add(menu)
            End While
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            _conn.Close()
            _conn.Dispose()
        End Try
        Return listMenu
    End Function

    Public Function Update(obj As MasterMenu) As Integer Implements ICrud(Of MasterMenu).Update
        Dim result As Object
        Try
            Dim strSP = "sp_UpdateMenu"
            cmd = New SqlCommand(strSP, _conn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@id_menu", obj.id_menu)
            cmd.Parameters.AddWithValue("@nama_menu", obj.nama_menu)
            cmd.Parameters.AddWithValue("@harga_menu", obj.harga_menu)
            cmd.Parameters.AddWithValue("@deskripsi_menu", obj.deskripsi_menu)
            _conn.Open()
            result = cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            _conn.Close()
            _conn.Dispose()
        End Try
        Return result
    End Function

    Public Function Delete(id As Integer) As Integer Implements ICrud(Of MasterMenu).Delete
        Dim result As Object
        Try
            Dim strSP = "sp_DeleteMenu"
            cmd = New SqlCommand(strSP, _conn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@id_menu", id)
            _conn.Open()
            result = cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            _conn.Close()
            _conn.Dispose()
        End Try
        Return result
    End Function
End Class
