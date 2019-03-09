Module Module1

    Sub Main()
        Console.WriteLine(sumNumbers(1, 0, 2))
        Console.ReadKey()
    End Sub








    Function sumNumbers(ByVal x As Integer, ByVal sum As Integer, ByVal sumTill As Integer) As Integer
        If (x <= sumTill) Then
            sum = sum + x
            Return sumNumbers(x + 1, sum, sumTill)
        Else
            Return sum
        End If

    End Function
End Module
