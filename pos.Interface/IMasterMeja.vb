Imports pos.BO


Public Interface IMasterMeja
    Inherits ICrud(Of MasterMeja)
    Function GetById(ByVal id As Integer) As List(Of MasterMeja)

End Interface