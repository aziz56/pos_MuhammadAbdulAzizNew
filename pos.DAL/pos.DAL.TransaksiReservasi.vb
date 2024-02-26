Imports System.Data.SqlClient
Imports pos.[Interface]

Public Class TransaksiReservasi

    Public Function ReservasiMeja(idPelanggan As Integer, idMeja As Integer, tanggalReservasi As DateTime, jamReservasi As TimeSpan, jumlahOrang As Integer, ByVal keterangan As String) As Integer

        Dim connectionString As String = "Server=.\SQLEXPRESS01;Database=pos_resto;Trusted_Connection=True;"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand("sp_reservasi_meja", connection)
                command.CommandType = CommandType.StoredProcedure
                command.Parameters.AddWithValue("@id_pelanggan", idPelanggan)
                command.Parameters.AddWithValue("@id_meja", idMeja)
                command.Parameters.AddWithValue("@tanggal_reservasi", tanggalReservasi)
                command.Parameters.AddWithValue("@jam_reservasi", jamReservasi)
                command.Parameters.AddWithValue("@jumlah_orang", jumlahOrang)
                command.Parameters.AddWithValue("@keterangan", keterangan)

                connection.Open()
                Dim idReservasi As Integer = command.ExecuteScalar()

                Return idReservasi
            End Using
        End Using
    End Function
    End Function

End Class
