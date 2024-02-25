Imports System.Security.Cryptography.X509Certificates
Imports pos.BO
Imports pos.DAL


Module Module1
    Sub Main()

        Dim crudPelanggan As New CrudPelanggan()
        Dim pelanggan As New MasterPelanggan
        Dim listPelanggan As New List(Of MasterPelanggan)
        For Each item As MasterPelanggan In listPelanggan

            Console.WriteLine("ID: " & item.id_pelanggan)
            Console.WriteLine("Nama: " & item.nama_pelanggan)
            Console.WriteLine("Telepon: " & item.no_telp_pelanggan)
            Console.WriteLine("Email: " & item.email_pelanggan)
            Console.WriteLine("=====================================")
        Next
        Console.ReadKey()
        Dim 


    End Sub

End Module
