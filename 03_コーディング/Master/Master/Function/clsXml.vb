Imports System.Xml
Imports System.Collections

''' <summary>
''' XMLクラス
''' </summary>
''' <remarks>XML用の設定を行います。</remarks>
Public Class clsXML

#Region "プロパティ"
    ''' <summary>
    ''' XMLオブジェクト
    ''' </summary>
    ''' <remarks></remarks>
    Public m_xmlDoc As XmlDocument
    ''' <summary>
    ''' エラーメッセージ
    ''' </summary>
    ''' <remarks></remarks>
    Public m_strMsg As String
    ''' <summary>
    ''' エラー番号
    ''' </summary>
    ''' <remarks></remarks>
    Public m_iErrNo As Int32
#End Region

#Region "コンストラクタ"
    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        '初期化
        m_xmlDoc = Nothing
    End Sub
#End Region

#Region "XMLロード"
    ''' <summary>
    ''' XMLファイルを読込む
    ''' </summary>
    ''' <param name="XmlName">XMLファイル名</param>
    ''' <returns>True:正常 False:異常</returns>
    ''' <remarks>XMLファイルを読込みます。</remarks>
    Public Function LoadXML(ByVal XmlName As String) As Boolean
        Dim iLoopCt As Integer
        Dim bRet As Boolean

        m_xmlDoc = New XmlDocument

        '他プロセス使用中の読込みエラー防止の為、リトライする
        For iLoopCt = 0 To 3
            Try
                'XML読込み
                m_xmlDoc.Load(XmlName)
                bRet = True
                Exit For
            Catch ex As XmlException    'XML関連の例外(記述ミス等)
                Me.SetErrorMessage(1, ex.ToString())
                bRet = False
                Exit For
            Catch ex As Exception       'その他の例外
                Me.SetErrorMessage(2, ex.ToString())
                bRet = False
                '500ms待つ
                System.Threading.Thread.Sleep(100)
            End Try
        Next
        '読込みエラーか？
        Return bRet
    End Function
#End Region

#Region "XML保存"
    ''' <summary>
    ''' XMLファイルを保存
    ''' </summary>
    ''' <param name="XmlName">XMLファイル名</param>
    ''' <returns>True:正常 False:異常</returns>
    ''' <remarks>XMLファイルを保存します。</remarks>
    Public Function SaveXML(ByVal XmlName As String) As Boolean
        Dim iLoopCt As Integer
        Dim bRet As Boolean

        'オブジェクトが未設定の場合はエラーとする。
        If m_xmlDoc Is Nothing Then
            Me.SetErrorMessage(3, "XMLドキュメントが読み込まれていません。")
            Return False
        End If

        '他プロセス使用中の読込みエラー防止の為、リトライする
        For iLoopCt = 0 To 3
            Try
                'XML読込み
                m_xmlDoc.Save(XmlName)
                bRet = True
                Exit For
            Catch ex As XmlException    'XML関連の例外(記述ミス等)
                Me.SetErrorMessage(4, ex.ToString())
                bRet = False
                Exit For
            Catch ex As Exception       'その他の例外
                Me.SetErrorMessage(5, ex.ToString())
                bRet = False
                '500ms待つ
                System.Threading.Thread.Sleep(100)
            End Try
        Next
        '保存エラーか？
        Return bRet
    End Function
#End Region

#Region "ノード読込み"
    ''' <summary>
    ''' XMLファイルから指定されたノードの文字列を返す
    ''' </summary>
    ''' <param name="strNodePath">取得対象ノードへのXPath</param>
    ''' <param name="strNodeText">ノード内文字列</param>
    ''' <returns>True:正常 False:異常</returns>
    ''' <remarks>XMLファイルから指定されてノードの文字列を返します。</remarks>
    Public Function GetXmlData(ByVal strNodePath As String, ByRef strNodeText As String) As Boolean
        Dim WkNode As XmlNode
        Dim WkUnit As String
        Dim objCData As XmlNode

        'オブジェクトが未設定の場合はエラーとする。
        If m_xmlDoc Is Nothing Then
            Me.SetErrorMessage(3, "XMLドキュメントが読み込まれていません。")
            Return False
        End If

        Try
            WkNode = m_xmlDoc.SelectSingleNode(strNodePath)
            '指定ノードが見つからないとき。
            If WkNode Is Nothing Then
                Return False
            End If
            If WkNode.HasChildNodes = True Then
                objCData = WkNode.FirstChild
                WkUnit = objCData.InnerText
            Else
                WkUnit = WkNode.InnerText
            End If
            strNodeText = WkUnit
        Catch ex As Exception
            Me.SetErrorMessage(6, ex.ToString())
            Return False
        End Try

        Return True
    End Function

    ''' <summary>
    ''' XMLファイルからコンボボックスのデータを取得
    ''' </summary>
    ''' <param name="strNodePath">取得対象ノードへのXPath</param>
    ''' <param name="arrData">コンボ文字列</param>
    ''' <returns>True:正常 False:異常</returns>
    ''' <remarks>XMLファイルからコンボボックスのデータを取得します。</remarks>
    Public Function GetXmlDataCmb(ByVal strNodePath As String, ByRef arrData As ArrayList) As Boolean
        Dim WkNode As XmlNode

        'オブジェクトが未設定の場合はエラーとする。
        If m_xmlDoc Is Nothing Then
            Me.SetErrorMessage(3, "XMLドキュメントが読み込まれていません。")
            Return False
        End If

        Try
            WkNode = m_xmlDoc.SelectSingleNode(strNodePath)
            '指定ノードが見つからないとき。
            If WkNode Is Nothing Then
                Return False
            End If

            '初期化
            arrData = New ArrayList
            'UFormのAppIDと自分のコントロール名でXMLファイル内を検索
            For Each lcChild As Xml.XmlNode In WkNode.ChildNodes
                '自分の子Node分を全て追加する
                arrData.Add(New cls_CmbBoxData(lcChild.SelectSingleNode("Text/text()").Value, lcChild.SelectSingleNode("Value/text()").Value))
            Next
        Catch ex As Exception
            Me.SetErrorMessage(6, ex.ToString())
            Return False
        End Try

        Return True
    End Function
#End Region

#Region "ノード書込み"
    ''' <summary>
    ''' XMLファイルの指定されたノードに文字列を設定
    ''' </summary>
    ''' <param name="strNodePath">取得対象ノードへのXPath</param>
    ''' <param name="strNodeText">ノード内文字列</param>
    ''' <returns>True:正常 False:異常</returns>
    ''' <remarks>XMLファイルの指定されたノードに文字列を設定します。</remarks>
    Public Function SetXmlData(ByVal strNodePath As String, ByVal strNodeText As String) As Boolean
        Dim WkNode As XmlNode
        Dim objCData As XmlCDataSection

        'オブジェクトが未設定の場合はエラーとする。
        If m_xmlDoc Is Nothing Then
            Me.SetErrorMessage(3, "XMLドキュメントが読み込まれていません。")
            Return False
        End If

        Try
            WkNode = m_xmlDoc.SelectSingleNode(strNodePath)
            '指定ノードが見つからないとき。
            If WkNode Is Nothing Then
                Return False
            End If
            If WkNode.HasChildNodes = True Then
                objCData = WkNode.FirstChild
                objCData.InnerText = strNodeText
            Else
                WkNode.InnerText = strNodeText
            End If
        Catch ex As Exception
            Me.SetErrorMessage(7, ex.ToString())
            Return False
        End Try

        Return True
    End Function
#End Region

#Region "エラー情報"
    ''' <summary>
    ''' クラス内での最後のエラーメッセージを格納する
    ''' </summary>
    ''' <param name="iErrorNo">エラー番号</param>
    ''' <param name="strMsg">エラーメッセージ文字列</param>
    ''' <remarks>クラス内での最後のエラーメッセージを格納します。</remarks>
    Private Sub SetErrorMessage(ByVal iErrorNo As Int32, ByVal strMsg As String)
        'エラー番号の設定
        Me.m_iErrNo = iErrorNo
        'エラーメッセージの設定
        Me.m_strMsg = strMsg
    End Sub
#End Region

End Class

#Region "コンボボックスデータ格納"
''' <summary>
''' コンボボックスデータクラス
''' </summary>
''' <remarks></remarks>
Public Class cls_CmbBoxData
    ''' <summary>
    ''' 表示メンバー
    ''' </summary>
    ''' <remarks></remarks>
    Public Const DisplayMember As String = "Text"
    ''' <summary>
    ''' バリューメンバー
    ''' </summary>
    ''' <remarks></remarks>
    Public Const ValueMember As String = "Value"
    Private _Text As String
    Private _Value As Decimal

    ''' <summary>
    ''' コンボボックスデータ格納
    ''' </summary>
    ''' <param name="strText">文字列</param>
    ''' <param name="decValue">数値</param>
    ''' <remarks>コンボボックスのデータを格納します。</remarks>
    Public Sub New(ByVal strText As String, ByVal decValue As Decimal)
        _Text = strText
        _Value = decValue
    End Sub
    ''' <summary>
    ''' テキストデータ
    ''' </summary>
    ''' <value>テキストデータ</value>
    ''' <returns>テキストデータ</returns>
    ''' <remarks>テキストデータを格納します。</remarks>
    Public ReadOnly Property Text() As String
        Get
            Return _Text
        End Get
    End Property
    ''' <summary>
    ''' 数値データ
    ''' </summary>
    ''' <value>数値データ</value>
    ''' <returns>数値データ</returns>
    ''' <remarks>数値データを格納します。</remarks>
    Public ReadOnly Property Value() As Decimal
        Get
            Return _Value
        End Get
    End Property
End Class
#End Region
