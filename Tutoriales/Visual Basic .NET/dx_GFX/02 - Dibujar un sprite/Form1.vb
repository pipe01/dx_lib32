Option Strict Off
Option Explicit On
Friend Class Form1
	Inherits System.Windows.Forms.Form
	
	Private Graphics As dx_lib32.dx_GFX_Class ' Instancia del objeto grafico de dx_lib32.
	Private Render As Boolean ' Controla el bucle de renderizado.
	Private Texture As Integer ' Identificador de la textura.
	
	Private Sub Form1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Me.Show() ' Forzamos al formulario a mostrarse.
		Graphics = New dx_lib32.dx_GFX_Class ' Creamos la instancia del objeto grafico.
		Render = Graphics.Init(Me.Handle.ToInt32, 640, 480, 32, True) ' Inicializamos el objeto grafico y el modo de video.
		Texture = Graphics.MAP_Load(My.Application.Info.DirectoryPath & "\texture.png", 0) ' Cargamos la textura para el sprite.
		
		Do While Render
			Graphics.DRAW_Map(Texture, 0, 0, 0, 0, 0) ' Dibujamos el sprite por defecto.
			Graphics.Frame() ' Renderizamos la escena.
		Loop 
	End Sub
	
	Private Sub Form1_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		Graphics.MAP_Unload(Texture) ' Descargamos la textura de memoria.
		Render = False ' Termina el bucle de renderizado.
		Graphics.Terminate() ' Terminamos la ejecucion de la clase grafica y liberamos los recursos utilizados.
		'UPGRADE_NOTE: El objeto Graphics no se puede destruir hasta que no se realice la recolecci�n de los elementos no utilizados. Haga clic aqu� para obtener m�s informaci�n: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		Graphics = Nothing ' Destruimos la instancia del objeto grafico.
	End Sub
End Class