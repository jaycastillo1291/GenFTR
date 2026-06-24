Imports System.Data.SqlClient
Imports System.Collections.Generic

Class DataAccessLayer
    Private m_Params As New Dictionary(Of String, Object)()
    Private _conn As SqlConnection
    Private _tran As SqlTransaction

    Private _transLevel As Integer = 0

    Public ReadOnly Property TransactionLevel As Integer
        Get
            Return _transLevel
        End Get
    End Property


    'Public Sub BeginTransaction()
    '    If _conn Is Nothing Then
    '        SetConnectionString()
    '        _conn = New SqlConnection(ConnectionString)
    '        _conn.Open()
    '    End If
    '    _tran = _conn.BeginTransaction()
    'End Sub

    Public Sub BeginTransaction()
        ' If this is the first level, open the connection
        If _transLevel = 0 Then
            If _conn Is Nothing Then
                SetConnectionString()
                _conn = New SqlConnection(ConnectionString)
                _conn.Open()
            End If
            _tran = _conn.BeginTransaction()
        End If

        ' Increment the level
        _transLevel += 1
    End Sub

    'Public Sub Commit()
    '    If _tran IsNot Nothing Then
    '        _tran.Commit()
    '        _tran.Dispose()
    '        _tran = Nothing
    '    End If
    '    CloseConnection()
    'End Sub

    Public Sub Commit()
        If _tran IsNot Nothing AndAlso _transLevel = 1 Then
            ' Only actually Commit on the final (outermost) level
            _tran.Commit()
            _tran.Dispose()
            _tran = Nothing
            CloseConnection()
        End If

        ' Decrement the level, but don't go below 0
        If _transLevel > 0 Then _transLevel -= 1
    End Sub


    'Public Sub Rollback()
    '    If _tran IsNot Nothing Then
    '        _tran.Rollback()
    '        _tran.Dispose()
    '        _tran = Nothing
    '    End If
    '    CloseConnection()
    'End Sub

    Public Sub Rollback()
        If _tran IsNot Nothing Then
            ' Usually, if ANY level rolls back, the WHOLE thing must go
            _tran.Rollback()
            _tran.Dispose()
            _tran = Nothing
            CloseConnection()
        End If

        ' Reset counter on Rollback
        _transLevel = 0
    End Sub

    Private Sub CloseConnection()
        If _conn IsNot Nothing Then
            _conn.Close()
            _conn.Dispose()
            _conn = Nothing
        End If
    End Sub


    Private ConnectionString As String

    Public Sub SetConnectionString()

        Dim strNewSvrName As String
        Dim strNewSvrAdd As String
        'Dim fileReader As System.IO.StreamReader

        'fileReader = My.Computer.FileSystem.OpenTextFileReader(Application.StartupPath & "\ServerName.txt")
        'Dim stringReader As String
        'stringReader = fileReader.ReadLine()
        'strNewSvrName = stringReader
        'stringReader = fileReader.ReadLine()
        'strNewSvrAdd = stringReader



        strNewSvrName = "192.168.11.5,51909"
        strNewSvrAdd = "192.168.11.5"
        ConnectionString = "Data Source=" & strNewSvrName & ";Initial Catalog=FOODSAMPLING;User ID=sa;Password=GenOSI2017;"

    End Sub

    Public Property StrParams As Dictionary(Of String, Object)
        Get
            Return m_Params
        End Get
        Set(value As Dictionary(Of String, Object))
            m_Params = value
        End Set
    End Property

    ' SELECT queries
    'Public Function ExecuteQuery(strQry As String) As DataTable
    '    Dim dt As New DataTable()
    '    SetConnectionString()

    '    Try
    '        Using _conn As New SqlConnection(ConnectionString)
    '            _conn.Open()

    '            Using cmd As New SqlCommand(strQry, _conn)
    '                ' Add parameters
    '                For Each kvp As KeyValuePair(Of String, Object) In m_Params
    '                    cmd.Parameters.AddWithValue("@" & kvp.Key, kvp.Value)
    '                Next

    '                Using reader As SqlDataReader = cmd.ExecuteReader()
    '                    dt.Load(reader)
    '                End Using
    '            End Using
    '        End Using
    '    Catch ex As Exception
    '        Throw New ApplicationException("Error executing query: " & ex.Message, ex)
    '    Finally
    '        m_Params.Clear()
    '    End Try

    '    Return dt
    'End Function

    Public Function ExecuteQuery(strQry As String) As DataTable
        Dim dt As New DataTable()
        Dim cmd As SqlCommand = Nothing
        Dim localConn As SqlConnection = Nothing

        Try
            If _tran IsNot Nothing Then
                cmd = New SqlCommand(strQry, _conn, _tran)
            Else
                SetConnectionString()
                localConn = New SqlConnection(ConnectionString)
                localConn.Open()
                cmd = New SqlCommand(strQry, localConn)
            End If

            ' Add parameters
            For Each kvp As KeyValuePair(Of String, Object) In m_Params
                cmd.Parameters.AddWithValue("@" & kvp.Key, kvp.Value)
            Next

            Using reader As SqlDataReader = cmd.ExecuteReader()
                dt.Load(reader)
            End Using

        Catch ex As Exception
            Throw New ApplicationException("Error executing query: " & ex.Message, ex)
        Finally
            m_Params.Clear()
            ' Only clean up if NOT in a transaction
            If _tran Is Nothing Then
                If cmd IsNot Nothing Then cmd.Dispose()
                If localConn IsNot Nothing Then
                    localConn.Close()
                    localConn.Dispose()
                End If
            End If
        End Try

        Return dt
    End Function

    ' INSERT/UPDATE/DELETE queries
    'Public Function ExecuteNonQuery(strQry As String) As Integer
    '    Dim rowsAffected As Integer = 0
    '    SetConnectionString()

    '    Try
    '        Using _conn As New SqlConnection(ConnectionString)
    '            _conn.Open()

    '            Using cmd As New SqlCommand(strQry, _conn)
    '                For Each kvp As KeyValuePair(Of String, Object) In m_Params
    '                    cmd.Parameters.AddWithValue("@" & kvp.Key, kvp.Value)
    '                Next

    '                rowsAffected = cmd.ExecuteNonQuery()
    '            End Using
    '        End Using
    '    Catch ex As Exception
    '        Throw New ApplicationException("Error executing non-query: " & ex.Message, ex)
    '    Finally
    '        m_Params.Clear()
    '    End Try

    '    Return rowsAffected
    'End Function

    Public Function ExecuteNonQuery(strQry As String) As Integer
        Dim rowsAffected As Integer = 0
        Dim cmd As SqlCommand = Nothing
        Dim localConn As SqlConnection = Nothing

        Try
            ' Determine if we use the Transactional Connection or a Temporary one
            If _tran IsNot Nothing Then
                ' Use the connection opened by BeginTransaction
                cmd = New SqlCommand(strQry, _conn, _tran)
            Else
                ' Standard behavior: Create, Open, and Close a local connection
                SetConnectionString()
                localConn = New SqlConnection(ConnectionString)
                localConn.Open()
                cmd = New SqlCommand(strQry, localConn)
            End If

            ' Add parameters
            For Each kvp As KeyValuePair(Of String, Object) In m_Params
                cmd.Parameters.AddWithValue("@" & kvp.Key, kvp.Value)
            Next

            rowsAffected = cmd.ExecuteNonQuery()

        Catch ex As Exception
            Throw New ApplicationException("Execution failed: " & ex.Message, ex)
        Finally
            m_Params.Clear()

            ' IMPORTANT: Only dispose if we are NOT in a transaction
            If _tran Is Nothing Then
                If cmd IsNot Nothing Then cmd.Dispose()
                If localConn IsNot Nothing Then
                    localConn.Close()
                    localConn.Dispose()
                End If
            End If
        End Try

        Return rowsAffected
    End Function


    ' Single value (e.g. COUNT(*), MAX(ID), etc.)
    'Public Function ExecuteScalar(strQry As String) As Object
    '    Dim result As Object = Nothing
    '    SetConnectionString()

    '    Try
    '        Using _conn As New SqlConnection(ConnectionString)
    '            _conn.Open()

    '            Using cmd As New SqlCommand(strQry, _conn)
    '                For Each kvp As KeyValuePair(Of String, Object) In m_Params
    '                    cmd.Parameters.AddWithValue("@" & kvp.Key, kvp.Value)
    '                Next

    '                result = cmd.ExecuteScalar()
    '            End Using
    '        End Using
    '    Catch ex As Exception
    '        Throw New ApplicationException("Error executing scalar: " & ex.Message, ex)
    '    Finally
    '        m_Params.Clear()
    '    End Try

    '    Return result
    'End Function

    Public Function ExecuteScalar(strQry As String) As Object
        Dim result As Object = Nothing
        Dim cmd As SqlCommand = Nothing
        Dim localConn As SqlConnection = Nothing

        Try
            If _tran IsNot Nothing Then
                cmd = New SqlCommand(strQry, _conn, _tran)
            Else
                SetConnectionString()
                localConn = New SqlConnection(ConnectionString)
                localConn.Open()
                cmd = New SqlCommand(strQry, localConn)
            End If

            For Each kvp As KeyValuePair(Of String, Object) In m_Params
                cmd.Parameters.AddWithValue("@" & kvp.Key, kvp.Value)
            Next

            result = cmd.ExecuteScalar()

        Catch ex As Exception
            Throw New ApplicationException("Error executing scalar: " & ex.Message, ex)
        Finally
            m_Params.Clear()
            ' Only clean up if NOT in a transaction
            If _tran Is Nothing Then
                If cmd IsNot Nothing Then cmd.Dispose()
                If localConn IsNot Nothing Then
                    localConn.Close()
                    localConn.Dispose()
                End If
            End If
        End Try

        Return result
    End Function


End Class