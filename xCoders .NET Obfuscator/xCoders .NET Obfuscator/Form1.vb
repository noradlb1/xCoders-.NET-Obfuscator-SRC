Imports Mono.Cecil
Public Class Form1

    Private Sub CrystalClearThemeContainer1_Click(sender As Object, e As EventArgs) Handles CrystalClearThemeContainer1.Click

    End Sub

    Private Sub CrystalClearButton1_Click(sender As Object, e As EventArgs) Handles CrystalClearButton1.Click
        Environment.Exit(0)
    End Sub
    Dim nasm As AssemblyDefinition
    Private Sub CrystalClearButton2_Click(sender As Object, e As EventArgs) Handles CrystalClearButton2.Click
        Dim od As New OpenFileDialog
        With od
            .Title = "Select .NET Assembly"
            .Filter = ".NET ASM |*.exe"
            .ShowDialog()
        End With
        CrystalClearTextBox1.Text = od.FileName
        nasm = AssemblyDefinition.ReadAssembly(CrystalClearTextBox1.Text)
    End Sub

    Private Sub CrystalClearButton3_Click(sender As Object, e As EventArgs) Handles CrystalClearButton3.Click
        Dim rand As New Random
        Dim moddef As ModuleDefinition
        moddef = nasm.MainModule
        For Each td As TypeDefinition In moddef.Types
            For Each fd As FieldDefinition In td.Fields
                fd.Name = GenStr(rand.Next(4, 12))
            Next
            If td.Namespace.Contains(".My") = False Then
                For Each method As MethodDefinition In td.Methods
                    If method.IsPInvokeImpl = False Then
                        If method.IsConstructor = False Then
                            method.Name = "Simon-Benyo"
                        End If
                    End If
                Next
            End If
        Next
        Dim sd As New SaveFileDialog
        With sd
            .Title = "Select Where To Save The Obfuscated Assembly"
            .Filter = ".NET Asm|*.exe"
            .ShowDialog()
        End With
        nasm.Write(sd.FileName)
        MsgBox("Obfuscating Done", vbInformation)
    End Sub

    Public Function GenStr(ByVal len As Long)
        Dim rnd As New Random
        Dim arb As String = "ابجدهوزحطيكلمنسعفصقرشت"
        Dim result As String = Nothing
        For i = 0 To len
            result = result & arb(rnd.Next(arb.Length))
        Next
        Return result
    End Function
End Class
