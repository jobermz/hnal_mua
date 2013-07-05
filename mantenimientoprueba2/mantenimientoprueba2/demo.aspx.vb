Imports oracle
Imports Oracle.DataAccess.Client
Imports System.Data
Public Class demo
    Inherits System.Web.UI.Page
    Dim ds As New DataSet
    Dim conexion As String = "Data Source=XE_FREDY;Persist Security Info=True;User ID=hnal;Password=hnal"
    Dim cn As New OracleConnection(conexion)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        grilla()
    End Sub
    Public Sub bindata()
        cn.Open()
        cmbprovincia.Items.Clear()
        Dim da As New OracleDataAdapter("select PROVINCIASCODIGO,PROVINCIASNOMBRE from PROVINCIAS WHERE DEPARTAMENTOSCODIGO IN '" & cmbdepartamentos.SelectedValue & "'", cn)
        da.Fill(ds, "nombrepro")
        Dim DR1 As DataRow
        For Each DR1 In ds.Tables("nombrepro").Rows
            cmbprovincia.Items.Add(DR1("PROVINCIASNOMBRE"))
            cmbprovincia.DataValueField = (DR1("PROVINCIASCODIGO"))
        Next

        cn.Close()
    End Sub

    Public Sub bindata2()
        cn.Open()
        cmbdistritos.Items.Clear()
        Dim da As New OracleDataAdapter("select distritosCODIGO,distritosNOMBRE from DISTRITOS WHERE PROVINCIASCODIGO IN (SELECT PROVINCIASCODIGO FROM PROVINCIAS WHERE PROVINCIASNOMBRE ='" & cmbprovincia.SelectedValue & "') and DEPARTAMENTOSCODIGO ='" & cmbdepartamentos.SelectedValue & "'", cn)
        da.Fill(ds, "nombrepro2")
        Dim DR As DataRow
        For Each DR In ds.Tables("nombrepro2").Rows
            cmbdistritos.Items.Add(DR("distritosNOMBRE"))
            cmbdistritos.DataValueField = (DR("DISTRITOSCODIGO"))
        Next

        cn.Close()
    End Sub
    Private Sub habiliar()
        txtDni.Text = ""
        txtPaterno.Text = ""
        TxtMaterno.Text = ""
        TxtNombres.Text = ""
        TxtNombres.Text = ""
        cmbdepartamentos.SelectedValue = "01"
        cmbdistritos.Text = "[.:Seleccionar:.]"
        cmbprovincia.Text = "[.:Seleccionar:.]"
        txtDireccion.Text = ""
        Paneltabla.Visible = True
    End Sub
    Protected Sub Btnañadir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Btnañadir.Click
        habiliar()
        cerrarpaneles()
    End Sub

    Private Sub cmbdepartamentos_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdepartamentos.TextChanged
        bindata()
    End Sub



    Private Sub cmbprovincia_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbprovincia.TextChanged
        bindata2()
    End Sub

    Protected Sub btnactualizar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnactualizar.Click
        cerrarpaneles()
        Dim objConn As New OracleConnection
        Dim objCmd As New OracleCommand
        Dim strConnString, strSQL As String

        strConnString = "Data Source=XE_FREDY;User ID=hnal;Password=hnal"

        strSQL = "UPDATE HNAL.DEMO SET DEMOPATERNO = '" & txtPaterno.Text & "',  DEMOMATERNO =     '" & TxtMaterno.Text & "' ,DEMONOMBRES           = '" & TxtNombres.Text & "',  DEPARTAMENTOSNOMBRE   =  '" & cmbdepartamentos.Text & "',  PROVINCIACODIGONOMBRE ='" & cmbprovincia.Text & "' , DISTRITOCODIGONOMBRE  = '" & cmbdistritos.Text & "' , DEMODIRECCION =  '" & txtDireccion.Text & "' WHERE DEMODNI = '" & txtDni.Text & "'"
        objConn.ConnectionString = strConnString
        objConn.Open()
        With objCmd
            .Connection = objConn
            .CommandText = strSQL
            .CommandType = CommandType.Text
        End With
        Try
            objCmd.ExecuteNonQuery()
            Me.LblSucces.Text = "Los datos grabaron correctamente."
            Me.PanelSucces.Visible = True
        Catch ex As Exception
            Me.PanelErros.Visible = True
            Me.LblError.Text = "Record Cannot Insert : Error (" & ex.Message & ")"
        End Try
        objConn.Close()
        objConn = Nothing
        grilla()

    End Sub
    Public Sub grilla()
        Try
            Dim conexion As String = "Data Source=XE_FREDY;User ID=hnal;Password=hnal"
            Dim cn As New OracleConnection(conexion)
            'Dim a As New OracleDataAdapter("SELECT PACIENTESHISTORIA AS HISTORIA ,  PACIENTESNOMBRECOMPLETO AS NOMBRE FROM pacientes where pacientesnombrecompleto like '%" & TextBox1.Text.ToUpper & "%'", cn)
            Dim a As New OracleDataAdapter("SELECT * FROM DEMO", cn)
            Dim t As New DataTable()
            t.Clear()
            cn.Open()
            a.Fill(t)
            GridView1.DataSource = t
            GridView1.DataBind()
            cn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Protected Sub btngrabar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btngrabar.Click
        cerrarpaneles()
        If txtDni.Text = "" Then
            txtDni.Focus()
        ElseIf txtPaterno.Text = "" Then
            txtPaterno.Focus()
        ElseIf TxtMaterno.Text = "" Then
            TxtMaterno.Focus()
        ElseIf TxtNombres.Text = "" Then
            TxtNombres.Focus()
        ElseIf cmbdistritos.Text = "" Then
            cmbdistritos.Focus()
        Else

            Dim objConn As New OracleConnection
            Dim objCmd As New OracleCommand
            Dim strConnString, strSQL As String

            strConnString = "Data Source=XE_FREDY;User ID=hnal;Password=hnal"

            strSQL = "insert into DEMO values( '" & txtDni.Text & "' , '" & txtPaterno.Text & "' , '" & TxtMaterno.Text & "' , '" & TxtNombres.Text & "' , '" & cmbdepartamentos.Text & "','" & cmbprovincia.Text & "' , '" & cmbdistritos.Text & "' , '" & txtDireccion.Text & "')"
            objConn.ConnectionString = strConnString
            objConn.Open()
            With objCmd
                .Connection = objConn
                .CommandText = strSQL
                .CommandType = CommandType.Text
            End With
            Try
                objCmd.ExecuteNonQuery()
                Me.LblSucces.Text = "Los datos grabaron correctamente."
                Me.PanelSucces.Visible = True
            Catch ex As Exception
                Me.PanelErros.Visible = True
                Me.LblError.Text = "Record Cannot Insert : Error (" & ex.Message & ")"
            End Try
            objConn.Close()
            objConn = Nothing
            grilla()
        End If

    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles GridView1.SelectedIndexChanged
        Paneltabla.Visible = True
        txtDni.Text = Me.GridView1.Rows(Me.GridView1.SelectedIndex).Cells(1).Text
        txtPaterno.Text = Me.GridView1.Rows(Me.GridView1.SelectedIndex).Cells(2).Text
        TxtMaterno.Text = Me.GridView1.Rows(Me.GridView1.SelectedIndex).Cells(3).Text
        TxtNombres.Text = Me.GridView1.Rows(Me.GridView1.SelectedIndex).Cells(4).Text
        cmbdepartamentos.Text = Me.GridView1.Rows(Me.GridView1.SelectedIndex).Cells(5).Text
        bindata()
        cmbprovincia.SelectedValue = Me.GridView1.Rows(Me.GridView1.SelectedIndex).Cells(6).Text
        bindata2()
        cmbdistritos.SelectedValue = Me.GridView1.Rows(Me.GridView1.SelectedIndex).Cells(7).Text
        txtDireccion.Text = Me.GridView1.Rows(Me.GridView1.SelectedIndex).Cells(8).Text

    End Sub

    Protected Sub btneliminar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btneliminar.Click
        cerrarpaneles()
        If Len(txtDni.Text) <> 8 Then
            PanelWarning.Visible = True
            lblWarning.Text = "Seleccione Registro que desea Eliminar"
            Btnsi.Visible = False
            Btnno.Visible = False
        Else
            PanelWarning.Visible = True
            lblWarning.Text = "Estos Datos Se Borraran Permanente Esta Seguro de Realizar Esta Operacion "
            Btnsi.Visible = True
            Btnno.Visible = True
        End If
        
    End Sub
    Private Sub cerrarpaneles()
        PanelWarning.Visible = False
        PanelInfo.Visible = False
        PanelSucces.Visible = False
        PanelErros.Visible = False
    End Sub
    Protected Sub btnbuscar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnbuscar.Click
        cerrarpaneles()
        Paneltabla.Visible = False
        Call buscargrilla

    End Sub
    Public Sub buscargrilla()
     
        Dim conexion As String = "Data Source=XE_FREDY;User ID=hnal;Password=hnal"
            Dim cn As New OracleConnection(conexion)
        Dim a As New OracleDataAdapter("SELECT * FROM DEMO where demonombres like '%" & txtbuscar.Text & "%' or demodni  like '%" & txtbuscar.Text & "%' or demopaterno like '%" & txtbuscar.Text & "%' or demomaterno like '%" & txtbuscar.Text & "%'", cn)
            Dim t As New DataTable()
            t.Clear()
            cn.Open()
            a.Fill(t)
            GridView1.DataSource = t
            GridView1.DataBind()
            cn.Close()
    Try
            Catch ex As Exception
            Me.PanelErros.Visible = True
            Me.LblError.Text = "No se encontraron Personas con esos Datos (" & ex.Message & ")"
        End Try
      
    End Sub

    Protected Sub Btnsi_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Btnsi.Click
        cerrarpaneles()
        Dim objConn As New OracleConnection
        Dim objCmd As New OracleCommand
        Dim strConnString, strSQL As String

        strConnString = "Data Source=XE_FREDY;User ID=hnal;Password=hnal"
        strSQL = "delete from demo where DEMODNI ='" & txtDni.Text & "'"

        objConn.ConnectionString = strConnString
        objConn.Open()
        With objCmd
            .Connection = objConn
            .CommandText = strSQL
            .CommandType = CommandType.Text
        End With
        Try
            objCmd.ExecuteNonQuery()
            Me.LblSucces.Text = "Los datos grabaron correctamente."
            Me.PanelSucces.Visible = True
        Catch ex As Exception
            Me.PanelErros.Visible = True
            Me.LblError.Text = "Record Cannot Insert : Error (" & ex.Message & ")"
        End Try
        objConn.Close()
        objConn = Nothing
        grilla()
        habiliar()
        PanelWarning.Visible = False
    End Sub

    Protected Sub Btnno_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Btnno.Click
        cerrarpaneles()
    End Sub

    Protected Sub cmbdepartamentos_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbdepartamentos.SelectedIndexChanged

    End Sub

    Protected Sub cmbprovincia_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbprovincia.SelectedIndexChanged

    End Sub
End Class