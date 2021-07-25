Imports System.Data.SqlClient
Imports MadMilkman.Ini
Imports System.Text.RegularExpressions

Public Class Form1

    Public cnxStr As String = ""

    'Public Function ConnectToSQL() As String
    '    Dim con As New SqlConnection
    '    Dim reader As SqlDataReader
    '    Try
    '        con.ConnectionString = cnxStr
    '        Dim cmd As New SqlCommand("SELECT * FROM sys.tables", con)
    '        con.Open()
    '        Console.WriteLine("Connection Opened")
    '        reader = cmd.ExecuteReader()
    '        While reader.Read
    '            Console.WriteLine(String.Format("{0}, {1}", reader(0), reader(1)))
    '        End While
    '    Catch ex As Exception
    '        MessageBox.Show("Error while connecting to SQL Server." & ex.Message)
    '    Finally
    '        con.Close()
    '    End Try          '
    '    Return "done"
    'End Function


    Public Function getListOfGO(ByVal NT As String) As List(Of String)
        Dim SQL As String = "SELECT RG_No FROM F_REGLECH WHERE DO_Piece = '" & NT & "' AND DO_Type = '30'"
        Dim output As New List(Of String)()

        Using cn = New SqlConnection(cnxStr)
            Using cmd = New SqlCommand(SQL, cn)
                cn.Open()
                Try
                    Dim dr = cmd.ExecuteReader()
                    While dr.Read()
                        output.Add(dr("RG_No").ToString())
                    End While
                Catch e As SqlException
                    MessageBox.Show("There was an error accessing your data. DETAIL: " & e.ToString())
                End Try
            End Using
        End Using

        Return output

    End Function


    Private Sub AnnulationTicket(ByVal NT As String)

        Dim allRG As New List(Of String)()
        allRG = getListOfGO(NT)

        Using connection As New SqlConnection(cnxStr)
            connection.Open()

            Dim command As SqlCommand = connection.CreateCommand()
            Dim transaction As SqlTransaction

            transaction = connection.BeginTransaction("AnnulationTicket")
            command.Connection = connection
            command.Transaction = transaction

            Dim strSQL As String
            Try
                strSQL = "DELETE FROM F_REGLECH WHERE DO_Piece = '" & NT.Trim & "' AND DO_Type = '30'"
                EcrireTXT(strSQL)
                command.CommandText = strSQL
                command.ExecuteNonQuery()

                For Each g As String In allRG
                    strSQL = "DELETE FROM F_CREGLEMENT WHERE RG_No ='" & g.Trim & "' AND DO_Type = '30'"
                    EcrireTXT(strSQL)
                    command.CommandText = strSQL
                    command.ExecuteNonQuery()
                Next

                strSQL = "DELETE FROM F_DOCREGL WHERE DO_Piece = '" & NT.Trim & "' AND DO_Type = '30'"
                EcrireTXT(strSQL)
                command.CommandText = strSQL
                command.ExecuteNonQuery()
                strSQL = "UPDATE F_DOCENTETE SET DO_VALIDE =0 where DO_Piece='" & NT.Trim & "' AND DO_TYPE ='30'"
                EcrireTXT(strSQL)
                command.CommandText = strSQL
                command.ExecuteNonQuery()
                strSQL = "UPDATE F_DOCENTETE SET DO_Attente=1 where DO_Piece='" & NT.Trim & "' AND DO_TYPE ='30'"
                EcrireTXT(strSQL)
                command.CommandText = strSQL
                command.ExecuteNonQuery()

                transaction.Commit()
                EcrireTXT("Transaction Commited.")
                MsgBox("Ticket Annuler.")
                txtNO.Text = ""

            Catch ex As Exception
                'Console.WriteLine("Commit Exception Type: " & ex.GetType().ToString & "  Message: " & ex.Message)
                EcrireTXT("Commit Exception Type: " & ex.GetType().ToString & "  Message: " & ex.Message)
                Try
                    transaction.Rollback()
                    EcrireTXT("Transaction Rollback.")
                Catch ex2 As Exception

                    EcrireTXT("Commit Exception Type: " & ex.GetType().ToString & "  Message: " & ex.Message)
                    MsgBox("Erreur Transaction voir fichier LOG")
                End Try
            End Try
        End Using
    End Sub

    Private Sub txtNO_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNO.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnValide_Click(sender, e)
        End If
    End Sub

    Private Sub btnValide_Click(sender As Object, e As EventArgs) Handles btnValide.Click
        Dim noticket As Integer = 0
        If Integer.TryParse(txtNO.Text, noticket) Then
            If noticket > 0 Then
                'MsgBox(noticket)
                'ConnectToSQL()
                EcrireTXT("#============ " & Now.ToString("yyyy-MM-dd HH:mm:ss") & " : Debut Annulation Ticket Numero " & noticket)
                AnnulationTicket(noticket)
            Else
                MsgBox("Merci de verifier le numero")
            End If
        Else
            MsgBox("Merci de verifier le numero")
        End If
    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim appPath As String = My.Application.Info.DirectoryPath
        Dim ini As New IniFile()
        ini.Load(appPath & "\CONFIG.INI")
        cnxStr = ini.Sections("DATABASE").Keys("CONNEXION").Value
        cnxStr = Regex.Replace(cnxStr, "[""]", String.Empty)
    End Sub

    Public Sub EcrireTXT(ByVal txt As String)
        Try
            Dim FILE_NAME As String = Application.StartupPath & "\HISTORIE.LOG"
            Dim objWriter As New System.IO.StreamWriter(FILE_NAME, True)
            objWriter.WriteLine(txt)
            objWriter.Close()
        Catch ex As Exception
            EcrireTXT(Now.ToString("HHmm : ") & "Erreur EcrireTXT : " & changeCRLF(ex.Message))
        End Try
    End Sub

    Function changeCRLF(ByVal txt As String) As String
        Return Replace(Replace(Replace(txt, vbCrLf, "<CRLF>"), vbLf, "<LF>"), vbCr, "<CR>")
    End Function



End Class
