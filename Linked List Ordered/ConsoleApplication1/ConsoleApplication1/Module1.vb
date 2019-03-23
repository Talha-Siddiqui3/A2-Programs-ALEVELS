Module Module1

    Structure LLNode
        Dim Pointer As Integer
        Dim Data As String
    End Structure

    Const NULLPOINTER = -1
    Dim StartPointer As Integer
    Dim FreePointer As Integer
    'Linked list nodes array of size 8(0-7)
    Dim Nodes(7) As LLNode

    Sub Main()
        Call InitialiseList()
        For count = 0 To 7
            InsertNode(Console.ReadLine)
        Next
        OutputArray()
        OutputItems()

        Console.ReadKey()

    End Sub

    Sub InitialiseList()

        StartPointer = NULLPOINTER
        FreePointer = 0
        'INITIALISING FREE LIST
        For count = 0 To 7
            Nodes(count).Pointer = count + 1
        Next
        Nodes(7).Pointer = NULLPOINTER

    End Sub


    Sub InsertNode(ByVal DataInputted As String)
        Dim NewNodePtr As Integer
        Dim CurrentNodePtr As Integer
        Dim PreviousNodePtr As Integer
        If FreePointer <> NULLPOINTER Then
            'We have space so grab a node from free list :)
            NewNodePtr = FreePointer
            Nodes(NewNodePtr).Data = DataInputted
            'Set Free Pointer to next available node in free list
            FreePointer = Nodes(FreePointer).Pointer

            CurrentNodePtr = StartPointer
            While CurrentNodePtr <> NULLPOINTER
                If (Nodes(CurrentNodePtr).Data < DataInputted) Then
                    PreviousNodePtr = CurrentNodePtr
                    CurrentNodePtr = Nodes(CurrentNodePtr).Pointer
                Else
                    Exit While
                End If
            End While

            'JO CURRENT NODE HAI US SE PHELE INSERT KREIN GE NAYI NODE HAMESHA.
            If CurrentNodePtr = StartPointer Then
                'Insert the node at the start of Linked List
                Nodes(NewNodePtr).Pointer = StartPointer
                StartPointer = NewNodePtr
                Console.WriteLine("START POINTER IS:" & StartPointer)
            Else
                'Insert Node between previous node and current node.
                Nodes(NewNodePtr).Pointer = Nodes(PreviousNodePtr).Pointer
                Nodes(PreviousNodePtr).Pointer = NewNodePtr
            End If


        Else
            Console.WriteLine("No available space in free list")
        End If
    End Sub

    Sub OutputArray()
        For count = 0 To 7
            Console.WriteLine("  " & count & Space(3) & Nodes(count).Data & Space(20 - Len(Nodes(count).Data)) & Nodes(count).Pointer)
        Next
    End Sub

    Sub OutputItems()
        Console.WriteLine() 'Just a blank line to sepeate it from above outputs
        Dim CurrentNodePtr As Integer = StartPointer
        While CurrentNodePtr <> NULLPOINTER
            Console.WriteLine("  " & Nodes(CurrentNodePtr).Data)
            CurrentNodePtr = Nodes(CurrentNodePtr).Pointer
        End While
    End Sub


End Module
