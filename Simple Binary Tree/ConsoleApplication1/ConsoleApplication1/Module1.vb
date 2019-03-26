Module Module1

    'Binary Tree
    Structure NODE
        Dim LeftPointer As Integer
        Dim Data As String
        Dim RightPointer As Integer
    End Structure

    'Binary tree array of size 5(0-4)
    Dim Nodes(4) As NODE


    Sub Main()
        For count = 0 To 4
            Nodes(count).LeftPointer = -1
            Nodes(count).Data = ""
            Nodes(count).RightPointer = -1
        Next

        'Input Cities in any order
        For count = 0 To 4
            Console.WriteLine("Enter City Name " & (count + 1) & ": ")
            Call insertBT(Console.ReadLine)
        Next

        'OUTPUT BINARY TREE
        For count = 0 To 4
            Dim currentNode = Nodes(count)
            Console.WriteLine(count & Space(7) & currentNode.LeftPointer & Space(3) & currentNode.Data & Space(10 - Len(currentNode.Data)) & currentNode.RightPointer)
        Next

        Console.ReadKey()
    End Sub

    Sub insertBT(ByVal Val As String)

        If Nodes(0).Data = "" Then
            'First value is to be inserted
            Nodes(0).Data = Val

        Else
            Call SelectLeftOrRightNode(0, Val)
        End If


    End Sub

    Sub SelectLeftOrRightNode(ByVal curPos As Integer, ByVal Val As String)
        If (Val > Nodes(curPos).Data) Then
            FindNodeRight(curPos, Val)
        Else
            FindNodeLeft(curPos, Val)
        End If
    End Sub

    Sub FindNodeRight(ByVal curPos As Integer, ByVal Val As String)
        Dim TempPos = 0
        If Nodes(curPos).RightPointer = -1 Then
            'Find any next available free space in array linearly
            While (Nodes(TempPos).Data <> "")
                TempPos += 1
            End While
            Nodes(TempPos).Data = Val
            Nodes(curPos).RightPointer = TempPos
        Else
            curPos = Nodes(curPos).RightPointer
            SelectLeftOrRightNode(curPos, Val)
        End If

    End Sub

    Sub FindNodeLeft(ByVal curPos As Integer, ByVal Val As String)
        Dim TempPos = 0
        If Nodes(curPos).LeftPointer = -1 Then
            'Find any next available free space in array linearly
            While (Nodes(TempPos).Data <> "")
                TempPos += 1
            End While
            Nodes(TempPos).Data = Val
            Nodes(curPos).LeftPointer = TempPos
        Else
            curPos = Nodes(curPos).LeftPointer
            SelectLeftOrRightNode(curPos, Val)
        End If

    End Sub

End Module
