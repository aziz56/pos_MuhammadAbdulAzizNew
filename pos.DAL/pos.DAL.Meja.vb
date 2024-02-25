Imports System.ComponentModel.Design
Imports System.Data.SqlClient
Imports pos.BO
Imports pos.[Interface]

Public Class CrudMeja
    Implements IMasterMeja
    Private _conn As SqlConnection
    Private strConn As String
    Private cmd As SqlCommand
    Private dr As SqlDataReader
    Public Sub New()
        strConn = "Server=.\SQLEXPRESS01;Database=pos_resto;Trusted_Connection=True;"
        _conn = New SqlConnection(strConn)
    End Sub



    Public Function GetById(id As Integer) As List(Of MasterMeja) Implements IMasterMeja.GetById
        Dim listMeja As New List(Of MasterMeja)
        Try
            Dim strSP = "sp_GetMeja"
            cmd = New SqlCommand(strSP, _conn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@id_meja", id)
            _conn.Open()
            dr = cmd.ExecuteReader()
            While dr.Read()
                Dim meja As New MasterMeja
                meja.id_meja = dr("id_meja")
                meja.no_meja = dr("no_meja")
                listMeja.Add(meja)
            End While
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            _conn.Close()
            _conn.Dispose()
        End Try
        Return listMeja
    End Function

    Public Function Create(obj As MasterMeja) As Integer Implements ICrud(Of MasterMeja).Create
        Dim result As Object
        Try
            Dim strSP = "sp_InsertMeja"
            cmd = New SqlCommand(strSP, _conn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@no_meja", obj.no_meja)
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

    Public Function GetAll() As List(Of MasterMeja) Implements ICrud(Of MasterMeja).GetAll
        Dim listMeja As New List(Of MasterMeja)
        Try
            Dim strSP = "sp_GetAllMeja"
            cmd = New SqlCommand(strSP, _conn)
            cmd.CommandType = CommandType.StoredProcedure
            _conn.Open()
            dr = cmd.ExecuteReader()
            While dr.Read()
                Dim meja As New MasterMeja
                meja.id_meja = dr("id_meja")
                meja.no_meja = dr("no_meja")
                listMeja.Add(meja)
            End While
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            _conn.Close()
            _conn.Dispose()
        End Try
        Return listMeja
    End Function

    Public Function Update(obj As MasterMeja) As Integer Implements ICrud(Of MasterMeja).Update
        Dim result As Object
        Try
            Dim strSP = "sp_UpdateMeja"
            cmd = New SqlCommand(strSP, _conn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@id_meja", obj.id_meja)
            cmd.Parameters.AddWithValue("@no_meja", obj.no_meja)
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

    Public Function Delete(id As Integer) As Integer Implements ICrud(Of MasterMeja).Delete
        Dim result As Object
        Try
            Dim strSP = "sp_DeleteMeja"
            cmd = New SqlCommand(strSP, _conn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@id_meja", id)
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
