﻿Imports System.Reflection

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DataGridViewMerge
    Inherits System.Windows.Forms.DataGridView

    'Control は、コンポーネント一覧に後処理を実行するために、dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'コントロール デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    ' メモ: 以下のプロシージャはコンポーネント デザイナーで必要です。
    ' コンポーネント デザイナーを使って変更できます。
    ' コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Interval = 20
        '
        'DataGridViewMerge
        '
        Me.RowTemplate.Height = 23
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Timer1 As Timer
End Class

