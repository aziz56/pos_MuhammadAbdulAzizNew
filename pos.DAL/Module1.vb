Imports Microsoft.VisualBasic.ApplicationServices
Imports pos.BO
Imports pos.DAL

Module Module1

    Sub Main()
        'Dim crudpelanggan As New CrudPelanggan()
        'Dim unused As New List(Of MasterPelanggan)
        'Dim listpelanggan = crudpelanggan.GetAllPelanggan()
        'For Each item As MasterPelanggan In listpelanggan
        '    Console.WriteLine("id: " & item.id_pelanggan)
        '    Console.WriteLine("nama: " & item.nama_pelanggan)
        '    Console.WriteLine("telepon: " & item.no_telp_pelanggan)
        '    Console.WriteLine("email: " & item.email_pelanggan)
        '    Console.WriteLine("=====================================) ")
        'Next
        'Console.Clear()
        Dim crudpelanggan1 As New CrudPelanggan()
        Dim pelanggan As New MasterPelanggan
        pelanggan.id_pelanggan = 1
        pelanggan.nama_pelanggan = "Budi"
        pelanggan.no_telp_pelanggan = "08123456789"
        pelanggan.email_pelanggan = "budi999"
        crudpelanggan1.CreatePelanggan(pelanggan)

        'Console.Clear()
        'Console.ReadKey()
        'Dim crudpelanggan2 As New CrudPelanggan()
        'Dim pelanggan2 As New MasterPelanggan
        'pelanggan2.id_pelanggan = 1
        'pelanggan2.nama_pelanggan = "Budi"
        'pelanggan2.no_telp_pelanggan = "08123456789"
        'pelanggan2.email_pelanggan = "budi9919"
        'crudpelanggan2.Update(pelanggan2)
        'Console.Clear()
        'Console.ReadKey()
        'Dim crudpelanggan3 As New CrudPelanggan()
        'Dim pelanggan3 As New MasterPelanggan
        'pelanggan3.id_pelanggan = 1
        'crudpelanggan3.Delete(pelanggan3)
        'Console.Clear()
        'Console.ReadKey()
        'Dim crudpelanggan4 As New CrudPelanggan()
        'Dim pelanggan4 As New MasterPelanggan
        'pelanggan4.id_pelanggan = 1
        'Dim pelanggan5 = crudpelanggan4.GetById(1)
        'Console.WriteLine("id: " & pelanggan5.id_pelanggan)
        'Console.WriteLine("nama: " & pelanggan5.nama_pelanggan)
        'Console.WriteLine("telepon: " & pelanggan5.no_telp_pelanggan)
        'Console.WriteLine("email: " & pelanggan5.email_pelanggan)
        'Console.WriteLine("=====================================) ")

        'Console.ReadKey()



    End Sub


End Module