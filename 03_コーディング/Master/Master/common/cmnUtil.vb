Module cmnUtil

    Public Const SYSTEM_VERSION As String = "Ver 0.0.0"

    Public Const GAMEN_SC_M20 As String = "SC-M20"


    ''' <summary>
    ''' 　画面タイトル取得
    ''' </summary>
    ''' <param name="gamenID">画面ID</param>
    Public Function getTitle(ByVal gamenID As String) As String
        Dim rtn As String = ""
        Select Case gamenID
            Case GAMEN_SC_M20
                rtn = " Customer calendar master login(顧客カレンダーマスタ登録)" & " - " & gamenID
            Case Else
                Return rtn
        End Select

        Return rtn & " " & SYSTEM_VERSION
    End Function


    ''' <summary>
    ''' 　OwnerDrowを利かせたコンボボックスを取得し、アイテムリストを設定する
    ''' </summary>
    ''' <param name="cmb">コンボボックス</param>
    ''' <param name="itemList">リストの内容</param>
    Public Sub setDropDownList(ByRef cmb As ComboBox, ParamArray itemList() As String)
        cmb.Items.Clear()

        cmb.DropDownStyle = ComboBoxStyle.DropDownList
        cmb.DrawMode = DrawMode.OwnerDrawFixed
        AddHandler cmb.DrawItem, AddressOf ComboBox_DrawItem
        For Each item As String In itemList
            cmb.Items.Add(item)
        Next
        cmb.SelectedIndex = 0
    End Sub
    Private Sub ComboBox_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs)
        '背景を描画する
        '項目が選択されている時は強調表示される
        e.DrawBackground()

        Dim cmb As ComboBox = CType(sender, ComboBox)
        '項目に表示する文字列
        Dim txt As String
        If e.Index > -1 Then
            txt = cmb.Items(e.Index).ToString()
        Else
            txt = cmb.Text
        End If
        '使用するフォント
        Dim f As New Font(txt, cmb.Font.Size)
        '使用するブラシ
        Dim b = New SolidBrush(e.ForeColor)
        '文字列を描画する
        Dim ym As Single = _
            (e.Bounds.Height - e.Graphics.MeasureString(txt, f).Height) / 2
        e.Graphics.DrawString(txt, f, b, e.Bounds.X, e.Bounds.Y + ym)

        f.Dispose()
        b.Dispose()

        'フォーカスを示す四角形を描画
        e.DrawFocusRectangle()
    End Sub
End Module
