Imports pos.BO

Public Interface IMasterPelanggan
    Inherits ICrud(Of MasterPelanggan)
    Function GetById(id As Integer) As List(Of MasterPelanggan)
End Interface