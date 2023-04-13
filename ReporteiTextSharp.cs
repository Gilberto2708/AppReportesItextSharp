using iTextSharp.text;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using waiTextSharp.utilidades;

namespace waiTextSharp
{

  public partial class ReporteiTextSharp : Form
  {

    #region "variables"

    /// <summary>
    /// Obtener la ruta y nombre logotipo 
    /// </summary>
    public string ArchivoLogotipo = Comun.AppRuta() + Comun.AppLogotipo;

    /// <summary>
    /// Obtener la ruta donde se crea y guarda el reporte (archivo) PDF
    /// </summary>
    public string RutaReporte = Comun.AppRuta() + Comun.AppRutaReporte;

    /// <summary>
    /// Obtener la cadena de conexión desde App.config, para conexíón con SQL Server 
    /// </summary>
    public string CadenaConexion = System.Configuration.ConfigurationManager.ConnectionStrings["csMSQLServer"].ConnectionString;

    #endregion 

    #region "constructor"

    public ReporteiTextSharp()
    {
      InitializeComponent();
    }

    #endregion 

    #region "barra de herramientas"

    private void Menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
    {
      try
      {
        // verificar
        switch (e.ClickedItem.Name)
        {
          case "tsbImprimir":
            // verificar
            if (tscboInformacion.SelectedItem != null)
            {
              ImprimirInformacion(tscboInformacion.SelectedItem.ToString().ToUpper());
            }
            else
            {
              MessageBox.Show("Seleccione una opción de la lista Información.", Comun.AppNombre(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            break;
          case "tsbSalir":
            // salir
            Application.Exit();
            break;
          default:
            // salir
            Application.Exit();
            break;
        }

      } catch (Exception Ex)
      {
        // excepción
        txtExcepcion.Text = Ex.ToString();
        // mensaje 
        MensajeMostrar(" - [ Ha ocurrido una Excepción... ]");
      }
    }

    #endregion 

    #region "imprimir"

    /// <summary>
    /// Genera reporte PDF con la información de la tabla solicitada
    /// </summary>
    /// <param name="TablaImnprimir">Nombre de la tabla</param>
    private void ImprimirInformacion(string TablaImnprimir)
    {
      SqlConnection conTmp = new SqlConnection();
      SqlCommand cmdTmp = new SqlCommand();
      SqlDataAdapter daTmp;
      DataSet dstTmp = new DataSet();
      string ArchivoNombre;
      string Encabezado;
      string Subencabezado = "";
      string PiePagina = "";
      ArrayList arlColumnas = new ArrayList();
      Rectangle PapelTamanio = iTextSharp.text.PageSize.LETTER;
      try
      {

        // cambiar puntero del ratón
        Cursor.Current = Cursors.WaitCursor;

        // mensaje inicializar
        MensajeLimpiar();

        // mensaje
        MensajeMostrar(" - [ Reporte en proceso... ]");

        // ruta y nombre del archivo con extensión
        ArchivoNombre = RutaReporte + "rpt" + TablaImnprimir + DateTime.Now.ToFileTime().ToString() + ".pdf";

        // Encabezado
        Encabezado = Comun.AppNombre();

        // instanciar conexion
        using (conTmp = new SqlConnection(CadenaConexion))
        {
          // abrir
          conTmp.Open();

          // verificar
          switch (TablaImnprimir)
          {
            case "EMPLEADO":
              // preparar comando
              cmdTmp = new SqlCommand("SELECT HumanResources.Employee.BusinessEntityID, ISNULL(Person.Person.FirstName, '') + ' ' + ISNULL(Person.Person.MiddleName, '') + ' ' + ISNULL(Person.Person.LastName, '') AS Name, JobTitle, BirthDate, CASE MaritalStatus WHEN 'S' THEN 'Soltero' WHEN 'M' THEN 'Casado' ELSE '' END AS MaritalStatus, CASE Gender WHEN 'F' THEN 'Mujer' WHEN 'M' THEN 'Hombre' ELSE '' END AS Gender, HireDate FROM HumanResources.Employee LEFT JOIN Person.Person ON HumanResources.Employee.BusinessEntityID = Person.Person.BusinessEntityID ORDER BY HumanResources.Employee.BusinessEntityId", conTmp);

              // tamaño de la hoja
              PapelTamanio = iTextSharp.text.PageSize.LETTER;

              // encabezado
              Subencabezado = "Reporte de Empleados";

              // columnas
              arlColumnas.Add(new ReporteColumna("Identificador", 10, true, Element.ALIGN_CENTER, Element.ALIGN_CENTER, "", FontFactory.TIMES_ROMAN, 8));
              arlColumnas.Add(new ReporteColumna("Nombre", 25, true, Element.ALIGN_CENTER, Element.ALIGN_LEFT, "", FontFactory.TIMES_ROMAN, 8));
              arlColumnas.Add(new ReporteColumna("Puesto", 25, true, Element.ALIGN_CENTER, Element.ALIGN_LEFT, "", FontFactory.TIMES_ROMAN, 8));
              arlColumnas.Add(new ReporteColumna("Fecha nacimiento", 10, true, Element.ALIGN_CENTER, Element.ALIGN_CENTER, "d", FontFactory.TIMES_ROMAN, 8));
              arlColumnas.Add(new ReporteColumna("Estado civil", 10, true, Element.ALIGN_CENTER, Element.ALIGN_CENTER, "", FontFactory.TIMES_ROMAN, 8));
              arlColumnas.Add(new ReporteColumna("Género", 10, true, Element.ALIGN_CENTER, Element.ALIGN_CENTER, "", FontFactory.TIMES_ROMAN, 8));
              arlColumnas.Add(new ReporteColumna("Fecha contratación", 10, true, Element.ALIGN_CENTER, Element.ALIGN_CENTER, "d", FontFactory.TIMES_ROMAN, 8));

              // pie de página
              PiePagina = "Puedes poner un mensaje en el pie de página";
              break;
            case "PERSONA":
              // preparar comando
              cmdTmp = new SqlCommand("SELECT BusinessEntityID, PersonType, ISNULL(Person.Person.FirstName, '') + ' ' + ISNULL(Person.Person.MiddleName, '') + ' ' + ISNULL(Person.Person.LastName, '') AS Name, ModifiedDate FROM Person.Person WHERE BusinessEntityID <= @BusinessEntityID", conTmp);

              // adicionar parametro
              cmdTmp.Parameters.Add("@BusinessEntityID", SqlDbType.Int).Value = 300;

              // tamaño de la hoja
              PapelTamanio = iTextSharp.text.PageSize.LETTER;

              // encabezado
              Subencabezado = "Reporte de Personas";

              // columnas
              arlColumnas.Add(new ReporteColumna("Identificador", 10, true, Element.ALIGN_CENTER, Element.ALIGN_CENTER, "", FontFactory.TIMES_ROMAN, 8));
              arlColumnas.Add(new ReporteColumna("Tipo de persona", 12, true, Element.ALIGN_CENTER, Element.ALIGN_CENTER, "", FontFactory.TIMES_ROMAN, 8));
              arlColumnas.Add(new ReporteColumna("Nombre", 66, true, Element.ALIGN_CENTER, Element.ALIGN_LEFT, "", FontFactory.TIMES_ROMAN, 8));
              arlColumnas.Add(new ReporteColumna("Fecha modificación", 12, true, Element.ALIGN_CENTER, Element.ALIGN_CENTER, "d", FontFactory.TIMES_ROMAN, 8));

              // pie de página
              PiePagina = "";
              break;
            case "PRODUCTO":
              // preparar comando
              //cmdTmp = new SqlCommand("SELECT ProductID, Name, ProductNumber, Color, SafetyStockLevel, ReorderPoint, StandardCost FROM Production.Product WHERE ProductID <= @ProductID ORDER BY ProductID", conTmp);
              cmdTmp = new SqlCommand("SELECT ProductID, Name, ProductNumber, Color, SafetyStockLevel, ReorderPoint, StandardCost, ListPrice FROM Production.Product WHERE ProductID <= @ProductID ORDER BY ProductID", conTmp);

              // adicionar parametro
              cmdTmp.Parameters.Add("@ProductID", SqlDbType.Int).Value = 500;

              // tamaño de la hoja
              PapelTamanio = iTextSharp.text.PageSize.LETTER.Rotate();

              // encabezado
              Subencabezado = "Reporte de Productos";

              // columnas
              arlColumnas.Add(new ReporteColumna("Identificador", 10, true, Element.ALIGN_CENTER, Element.ALIGN_CENTER, "", FontFactory.TIMES_ROMAN, 8));
              arlColumnas.Add(new ReporteColumna("Nombre", 28, true, Element.ALIGN_CENTER, Element.ALIGN_LEFT, "", FontFactory.TIMES_ROMAN, 8));
              arlColumnas.Add(new ReporteColumna("Número", 12, true, Element.ALIGN_CENTER, Element.ALIGN_CENTER, "", FontFactory.TIMES_ROMAN, 8));
              arlColumnas.Add(new ReporteColumna("Color", 10, true, Element.ALIGN_CENTER, Element.ALIGN_CENTER, "", FontFactory.TIMES_ROMAN, 8));
              arlColumnas.Add(new ReporteColumna("Existencia mínima", 13, true, Element.ALIGN_CENTER, Element.ALIGN_RIGHT, "N0", FontFactory.TIMES_ROMAN, 8));
              arlColumnas.Add(new ReporteColumna("Punto de pedido", 13, true, Element.ALIGN_CENTER, Element.ALIGN_RIGHT, "N0", FontFactory.TIMES_ROMAN, 8));
              arlColumnas.Add(new ReporteColumna("Costo", 13, true, Element.ALIGN_CENTER, Element.ALIGN_RIGHT, "N2", FontFactory.TIMES_ROMAN, 8));
              arlColumnas.Add(new ReporteColumna("Precio de lista", 13, true, Element.ALIGN_CENTER, Element.ALIGN_RIGHT, "C2", FontFactory.TIMES_ROMAN, 8));

              // pie de página
              PiePagina = "";
              break;
          }

          // obtener informacion
          daTmp = new SqlDataAdapter(cmdTmp);
          daTmp.Fill(dstTmp);

          // asignar el nombre a la tabla
          dstTmp.Tables[0].TableName = TablaImnprimir;

          // instanciar reporte
          Reporte udtReporte = new Reporte(ArchivoLogotipo);

          // crear reporte
          udtReporte.Generar(ArchivoNombre, PapelTamanio, Encabezado, Subencabezado, PiePagina, arlColumnas, dstTmp.Tables[0]);

          // entregar el reporte con la aplicación asociada
          System.Diagnostics.Process.Start(ArchivoNombre);
        }

        // mensaje
        MensajeMostrar(" - [ Reporte terminado... ]");

        // cambiar puntero ratón
        Cursor.Current = Cursors.Default;
      }
      catch (Exception Ex)
      {
        // heredar
        throw Ex;
      }
      finally {
        // cerrar y destruir
        cmdTmp.Dispose();
        conTmp.Close();
        conTmp.Dispose();
      }
    }

    /// <summary>
    /// Mostrar mensaje en la barra de estado
    /// </summary>
    /// <param name="mensaje">Mensaje a mortrar</param>
    private void MensajeMostrar(string mensaje)
    {
      try
      {
        // mostrar
        tssMensaje.Text = mensaje;
        tssMensaje.ForeColor = mensaje.StartsWith(" - [ Ha ocurrido una Excepción... ]") ? System.Drawing.Color.Red : System.Drawing.Color.DodgerBlue;
      }
      catch (Exception Ex)
      {
        // heredar
        throw Ex;
      }
    }

    /// <summary>
    /// Inicializar el control del mensaje
    /// </summary>
    private void MensajeLimpiar()
    {
      try
      {
        // mostrar
        tssMensaje.Text = "";
        tssMensaje.ForeColor = DefaultForeColor;
      }
      catch (Exception Ex)
      {
        // heredar
        throw Ex;
      }
    }

        #endregion

        private void ReporteiTextSharp_Load(object sender, EventArgs e)
        {

        }
    }
}