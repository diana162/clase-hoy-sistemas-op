﻿Public Class ParticionDinamicaCfg


#Region " Fields "

    ' Tamaño de la Memoria Ram en Kb 
    Private TamañoMemoria As Integer = 0

    ' Lista de los tamaños de particiones en Kb
    Private ListaParticiones As List(Of Particion) = Nothing

#End Region

#Region " Subs & Functions "

    Private Sub ActualizarDgvParticiones()

        ' Limpiando Datagridview
        dgvParticiones.Rows.Clear()

        ' Agragando filas al control Datagridview
        For Each p As Particion In ListaParticiones
            dgvParticiones.Rows.Add(New String() {p.Numero, p.Tamaño})
        Next

    End Sub

    Private Sub ActualizarNupTamaño()
        nupTamaño.Value = TamañoMemoria
    End Sub

#End Region

#Region " Windows Form Events "

    Private Sub ParticionDinamicaCfg_Load(sender As Object, e As EventArgs) Handles Me.Load

        ' Inicializando objeto List(Of Particion)
        ListaParticiones = New List(Of Particion)

        ' Inicializando tamaño de memoria de prueba
        TamañoMemoria = 700

        ' Inicializando particiones de memoria de prueba
        '
        ListaParticiones.Add(New Particion(1, 0, 50, EstadoParticion.Libre))  ' P1 ~ 100kb
        ListaParticiones.Add(New Particion(2, 0, 30, EstadoParticion.Libre))
        ListaParticiones.Add(New Particion(3, 0, 150, EstadoParticion.Libre))
        ListaParticiones.Add(New Particion(4, 0, 40, EstadoParticion.Libre))
        ListaParticiones.Add(New Particion(5, 0, 80, EstadoParticion.Libre))
        ListaParticiones.Add(New Particion(6, 0, 110, EstadoParticion.Libre))
        ListaParticiones.Add(New Particion(7, 0, 20, EstadoParticion.Libre))
        ListaParticiones.Add(New Particion(8, 0, 90, EstadoParticion.Libre))
        ListaParticiones.Add(New Particion(9, 0, 130, EstadoParticion.Libre))


        ' Actualizando controles 
        ActualizarNupTamaño()
        ActualizarDgvParticiones()
    End Sub

    Private Sub btnIniciar_Click(sender As Object, e As EventArgs) Handles btnIniciar.Click

        ' Declaración e Inicialización de objeto ParticionFija
        Dim frmParticionDinamica As ParticionDinamica = New ParticionDinamica()

        ' Obteniendo Algoritmo de Asignación (Primer Ajuste o Mejor Ajuste)
        Dim algoritmoAsignacion As AlgoritmoAsignacion
        Select Case True
            Case rbPrimerAjuste.Checked
                algoritmoAsignacion = AlgoritmoAsignacion.PrimerAjuste
            Case rbMejorAjuste.Checked
                algoritmoAsignacion = AlgoritmoAsignacion.MejorAjuste
        End Select

        ' Inicialización de parametros y mostrando formulario
        frmParticionDinamica.Inicializar(TamañoMemoria, ListaParticiones, algoritmoAsignacion)
        frmParticionDinamica.ShowDialog()

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub btnAgregarParticion_Click(sender As Object, e As EventArgs) Handles btnAgregarParticion.Click
        ' TODO
    End Sub

    Private Sub btnEliminarParticion_Click(sender As Object, e As EventArgs) Handles btnEliminarParticion.Click
        ' TODO
    End Sub

#End Region


End Class