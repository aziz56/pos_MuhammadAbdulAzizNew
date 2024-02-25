Imports pos.BO

Public Interface IMasterMenu
    Inherits ICrud(Of MasterMenu)
    Function GetById(id As Integer) As List(Of MasterMenu)

End Interface
