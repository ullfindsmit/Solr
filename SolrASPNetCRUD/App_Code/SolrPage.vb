
Public Module ModSolr

    Public Const SolrBaseURL As String = "http://192.168.1.105:8983/solr"
    Public Const ABCoreName As String = "SolrASPNetCRUDv2"
    Public Const SolrABURL As String = SolrBaseURL & "/" & ABCoreName

End Module

Public Class MyAddressBookEntry

    Public Property FirstName As String
    Public Property LastName As String
    Public Property Email As String
    Public Property Phone As String

End Class