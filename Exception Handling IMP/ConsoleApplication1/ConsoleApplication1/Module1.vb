Module Module1

    Sub Main()

        Dim a As Integer
        Dim valid = False
        Do
            Console.WriteLine("Enter a number:")
            Try
                a = Console.ReadLine()
                valid = True
            Catch
                Console.WriteLine("Wrong input" & vbCrLf & "Please enter a valid number")
                valid = False
            End Try
        Loop Until valid
        Console.ReadKey()
    End Sub

End Module
