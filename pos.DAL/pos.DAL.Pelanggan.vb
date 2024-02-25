Imports System.Data.SqlClient
Imports pos.BO
Imports pos.Interface


Public Class CrudPelanggan
    Implements IMasterPelanggan

    Private _conn As SqlConnection
    Private strConn As String
    Private cmd As SqlCommand
    Private dr As SqlDataReader
    Public Sub New()
        strConn = "Server=.\SQLEXPRESS01;Database=pos_resto;Trusted_Connection=True;"
        _conn = New SqlConnection(strConn)
    End Sub
    Public Function GetAllPelanggan() As List(Of MasterPelanggan) Implements IMasterPelanggan.GetAll

        Dim listPelanggan As New List(Of MasterPelanggan)
        Try
            Dim strSP = "sp_GetAllPelanggan"
            _conn.Open()
            dr = cmd.ExecuteReader()
            While dr.Read()
                Dim pelanggan As New MasterPelanggan
                pelanggan.id_pelanggan = dr("id_pelanggan")
                pelanggan.nama_pelanggan = dr("nama_pelanggan")
                pelanggan.no_telp_pelanggan = dr("no_telp_pelanggan")
                pelanggan.email_pelanggan = dr("email_pelanggan")
                listPelanggan.Add(pelanggan)
            End While
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            _conn.Close()
            _conn.Dispose()
        End Try
        Return listPelanggan
    End Function

    Public Function CreatePelanggan(obj As MasterPelanggan) As Integer Implements IMasterPelanggan(Of MasterPelanggan).Create


        Dim result As Object
        Try
            Dim strSP = "sp_InsertPelanggan"
            cmd = New SqlCommand(strSP, _conn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@nama_pelanggan", obj.nama_pelanggan)
            cmd.Parameters.AddWithValue("@no_telp_pelanggan", obj.no_telp_pelanggan)
            cmd.Parameters.AddWithValue("@email_pelanggan", obj.email_pelanggan)
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


    Public Function GetById(id As Integer) As MasterPelanggan Implements IMasterPelanggan(Of MasterPelanggan).GetById
        Dim pelanggan As New MasterPelanggan
        Try
            Dim strSP = "sp_GetPelanggan"
            cmd = New SqlCommand(strSP, _conn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@id_pelanggan", id)
            _conn.Open()
            dr = cmd.ExecuteReader()
            While dr.Read()
                pelanggan.id_pelanggan = dr("id_pelanggan")
                pelanggan.nama_pelanggan = dr("nama_pelanggan")
                pelanggan.no_telp_pelanggan = dr("no_telp_pelanggan")
                pelanggan.email_pelanggan = dr("email_pelanggan")
            End While
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            _conn.Close()
            _conn.Dispose()
        End Try
        Return pelanggan
    End Function
    Public Function Update(obj As MasterPelanggan) As Integer Implements IMasterPelanggan(Of MasterPelanggan).Update

        Dim result As Object
        Try
            Dim strSP = "sp_UpdatePelanggan"
            cmd = New SqlCommand(strSP, _conn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@id_pelanggan", obj.id_pelanggan)
            cmd.Parameters.AddWithValue("@nama_pelanggan", obj.nama_pelanggan)
            cmd.Parameters.AddWithValue("@no_telp_pelanggan", obj.no_telp_pelanggan)
            cmd.Parameters.AddWithValue("@email_pelanggan", obj.email_pelanggan)
            _conn.Open()
            result = cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            _conn.Close()
            _conn.Dispose()
        End Try

    End Function
    Public Function Delete(id As Integer) As Integer Implements ICrud(Of MasterPelanggan).Delete
        Dim result As Object
        Try
            Dim strSP = "sp_DeletePelanggan"
            cmd = New SqlCommand(strSP, _conn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@id_pelanggan", id)
            _conn.Open()
            result = cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            _conn.Close()
            _conn.Dispose()
        End Try
    End Function
End Class
