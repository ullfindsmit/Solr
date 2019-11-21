Imports CommonServiceLocator
Imports SolrNet
Imports SolrNet.Impl

Public Class _Default
    Inherits System.Web.UI.Page

    Dim _PageAddressBook As List(Of MyAddressBookEntry)
    Public Function PageAddressBook() As List(Of MyAddressBookEntry)
        If _PageAddressBook Is Nothing Then

        End If

        Return _PageAddressBook
    End Function

    Public Sub MyInit()
        Try

            SolrNet.Startup.Init(Of SolrNet.Impl.ISolrHeaderResponseParser)(SolrBaseURL)
            SolrNet.Startup.Init(Of SolrNet.Impl.ISolrStatusResponseParser)(SolrBaseURL)

            SolrNet.Startup.Init(Of MyAddressBookEntry)(SolrABURL)
            SolrNet.Startup.Init(Of SolrNet.ISolrOperations(Of MyAddressBookEntry))(SolrABURL)
        Catch ex As Exception
            litError.Text = ex.Message
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyInit()

        If Not IsPostBack Then
            Dim headerParser = ServiceLocator.Current.GetInstance(Of ISolrHeaderResponseParser)()
            Dim statusParser = ServiceLocator.Current.GetInstance(Of ISolrStatusResponseParser)()
            Dim solrCoreAdmin As ISolrCoreAdmin = New SolrCoreAdmin(New SolrConnection(SolrBaseURL), headerParser, statusParser)

            Dim coreStatus = solrCoreAdmin.Status(ABCoreName)
            If coreStatus.Uptime = 0 Then
                litError.Text = ABCoreName & " core not found or running"
                Dim CreateResult = solrCoreAdmin.Create(ABCoreName, ABCoreName) 'DOES NOT WORK (The remote server returned an error: (400) Bad Request.)
                'http://192.168.1.105:8983/solr/admin/cores?action=CREATE&name=coreX&instanceDir=path_to_instance_directory&config=config_file_name.xml&schema=schema_file_name.xml&dataDir=data
                '   RETURNS: "msg":"Error CREATEing SolrCore 'coreX': Unable to create core [coreX] Caused by: Can't find resource 'config_file_name.xml' in classpath or '/var/solr/data/path_to_instance_directory'"
                '       FIX: https://stackoverflow.com/questions/35407796/cant-find-resource-solrconfig-xml-in-classpath-in-solr
                '           check if folder named'path_to_instance_directory exists' and does it contain config.xml and schema.xml if it is it might be privilege problem and the application needs more privilege to access that folder, try to put your configuration folder in a folder wich is not resticted
                'CREATE MANUALLY ON PUTTY
                'sudo su - solr -c "/opt/solr/bin/solr create -c SolrASPNetCRUD -n data_driven_schema_configs"
                If CreateResult.Status = 0 Then
                    litError.Text = "Created"
                End If
            End If
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim nA As New MyAddressBookEntry
        nA.FirstName = txtFirstName.Text
        nA.LastName = txtLastName.Text
        nA.Phone = txtPhone.Text
        nA.Email = txtEmail.Text

        'Dim oSolr As New SolrConnection(SolrABURL)


        Dim solr As ISolrOperations(Of MyAddressBookEntry) = ServiceLocator.Current.GetInstance(Of ISolrOperations(Of MyAddressBookEntry))()
        Dim addResult = solr.Add(nA)
        If addResult.Status <> 0 Then
            litError.Text = addResult.ToString
        End If
    End Sub
End Class