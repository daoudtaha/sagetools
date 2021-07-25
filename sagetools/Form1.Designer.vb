<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnValide = New System.Windows.Forms.Button()
        Me.labNO = New System.Windows.Forms.Label()
        Me.txtNO = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnValide)
        Me.GroupBox1.Controls.Add(Me.labNO)
        Me.GroupBox1.Controls.Add(Me.txtNO)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(297, 115)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "ANNULATION TICKET"
        '
        'btnValide
        '
        Me.btnValide.Location = New System.Drawing.Point(235, 44)
        Me.btnValide.Name = "btnValide"
        Me.btnValide.Size = New System.Drawing.Size(44, 33)
        Me.btnValide.TabIndex = 3
        Me.btnValide.Text = "OK"
        Me.btnValide.UseVisualStyleBackColor = True
        '
        'labNO
        '
        Me.labNO.AutoSize = True
        Me.labNO.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labNO.Location = New System.Drawing.Point(6, 51)
        Me.labNO.Name = "labNO"
        Me.labNO.Size = New System.Drawing.Size(124, 19)
        Me.labNO.TabIndex = 2
        Me.labNO.Text = "Numero Ticket :"
        '
        'txtNO
        '
        Me.txtNO.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNO.Location = New System.Drawing.Point(136, 48)
        Me.txtNO.MaxLength = 8
        Me.txtNO.Name = "txtNO"
        Me.txtNO.Size = New System.Drawing.Size(93, 27)
        Me.txtNO.TabIndex = 1
        Me.txtNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(321, 136)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Form1"
        Me.Text = "SAGE TOOLS"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnValide As System.Windows.Forms.Button
    Friend WithEvents labNO As System.Windows.Forms.Label
    Friend WithEvents txtNO As System.Windows.Forms.TextBox

End Class
