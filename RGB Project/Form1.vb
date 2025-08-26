

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = "Red Color
    (R)"
        Label2.Text = "Green Color
    (G)"
        Label3.Text = "Blue Color
    (B)"
        Label4.Text = "3 Digit Hexadecimal Value"
        Label5.Text = "6 Digit Hexadecimal Value"
        Label6.Text = "RGB Values"
        BackColor = Color.Black
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox1.Text = VScrollBar1.Value
        TextBox2.Text = VScrollBar2.Value
        TextBox3.Text = VScrollBar3.Value
        hexconvert(VScrollBar1.Value, VScrollBar2.Value, VScrollBar3.Value)

    End Sub

    Private Sub VScrollBar1_Scroll(sender As Object, e As ScrollEventArgs) Handles VScrollBar1.Scroll
        Me.BackColor = Color.FromArgb(VScrollBar1.Value, VScrollBar2.Value, VScrollBar3.Value)
        TextBox1.Text = VScrollBar1.Value.ToString()
        hexconvert(VScrollBar1.Value, VScrollBar2.Value, VScrollBar3.Value)
    End Sub

    Private Sub VScrollBar2_Scroll(sender As Object, e As ScrollEventArgs) Handles VScrollBar2.Scroll
        Me.BackColor = Color.FromArgb(VScrollBar1.Value, VScrollBar2.Value, VScrollBar3.Value)
        TextBox2.Text = VScrollBar2.Value.ToString()
        hexconvert(VScrollBar1.Value, VScrollBar2.Value, VScrollBar3.Value)
    End Sub

    Private Sub VScrollBar3_Scroll(sender As Object, e As ScrollEventArgs) Handles VScrollBar3.Scroll
        Me.BackColor = Color.FromArgb(VScrollBar1.Value, VScrollBar2.Value, VScrollBar3.Value)
        TextBox3.Text = VScrollBar3.Value.ToString()
        hexconvert(VScrollBar1.Value, VScrollBar2.Value, VScrollBar3.Value)
    End Sub

    Public Sub hexconvert(ByVal r As Integer, ByVal g As Integer, ByVal b As Integer)
        Dim hexColor As String = "#"
        Dim hexThree As String = "#"

        hexColor &= DecimalToHexa6(r)
        hexColor &= DecimalToHexa6(g)
        hexColor &= DecimalToHexa6(b)

        hexThree &= DecimalToHexa3(r \ 16)
        hexThree &= DecimalToHexa3(g \ 16)
        hexThree &= DecimalToHexa3(b \ 16)

        TextBox4.Text = hexColor
        TextBox5.Text = hexThree
    End Sub

    Private Function DecimalToHexa6(ByVal value As Integer) As String
        Dim hex As String = ""

        If value = 0 Then
            Return "00"
        End If

        While value > 0
            Dim remainder As Integer = value Mod 16
            If remainder >= 10 Then
                hex = Chr(remainder + 55) & hex
            Else
                hex = remainder.ToString() & hex
            End If
            value \= 16
        End While

        If hex.Length = 1 Then
            hex = "0" & hex
        End If

        Return hex
    End Function

    Private Function DecimalToHexa3(ByVal value As Integer) As String
        Dim hex As String = ""

        If value = 0 Then
            Return "0"
        End If

        While value > 0
            Dim remainder As Integer = value Mod 16
            If remainder >= 10 Then
                hex = Chr(remainder + 55) & hex
            Else
                hex = remainder.ToString() & hex
            End If
            value \= 16
        End While

        Return hex
    End Function



    Private Sub TextBox4_MouseClick(sender As Object, e As MouseEventArgs) Handles TextBox4.MouseClick
        Clipboard.SetText(TextBox4.Text)

    End Sub

    Private Sub TextBox4_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox4.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim hexclr As String = TextBox4.Text.Replace("#", "").Trim()
            hexclr = hexclr.ToUpper()

            If hexclr.Length = 6 Then

                VScrollBar1.Value = HexToDec(hexclr.Substring(0, 2))
                VScrollBar2.Value = HexToDec(hexclr.Substring(2, 2))
                VScrollBar3.Value = HexToDec(hexclr.Substring(4, 2))

                TextBox1.Text = VScrollBar1.Value
                TextBox2.Text = VScrollBar2.Value
                TextBox3.Text = VScrollBar3.Value
                Me.BackColor = Color.FromArgb(VScrollBar1.Value, VScrollBar2.Value, VScrollBar3.Value)

            End If
        End If

    End Sub


    Private Function HexToDec(ByVal rb As String) As Integer

        Dim base As Integer = 1
        Dim dec As Integer = 0

        For i As Integer = rb.Length - 1 To 0 Step -1
            Dim c As Char = rb(i)

            If c >= "0" And c <= "9" Then
                dec += (Asc(c) - Asc("0")) * base
                base *= 16
            ElseIf c >= "A" And c <= "F" Then
                dec += (Asc(c) - Asc("A"c) + 10) * base
                base *= 16
            End If
        Next

        Return dec
    End Function


End Class