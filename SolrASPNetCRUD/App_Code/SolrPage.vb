
Imports SolrNet.Attributes

Public Module ModSolr

    Public Const SolrBaseURL As String = "http://192.168.1.105:8983/solr"
    Public Const ABCoreName As String = "SolrASPNetCRUDv2"
    Public Const SolrABURL As String = SolrBaseURL & "/" & ABCoreName

End Module

Public Class MyAddressBookEntry

    <SolrUniqueKey("id")>
    Public Property id As String

    <SolrField("FirstName")>
    Public Property FirstName As String

    <SolrField("LastName")>
    Public Property LastName As String

    <SolrField("Email")>
    Public Property Email As String

    <SolrField("Phone")>
    Public Property Phone As String

End Class
