using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;       
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Windows.Forms;
using System.IO;
using ClosedXML.Excel; 

namespace Presupuestador
{
    public partial class Form1 : Form
    {
        private string logoPath = "";
        public Form1()
        {
            InitializeComponent();
        }

        // --- Al cargar el formulario, preparamos la tabla ---
        private void Form1_Load(object sender, EventArgs e)
        {
            QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;

            ConfigurarTabla();
            ActualizarTotal();// <--- AÑADIDO
        }

        // --- BLOQUE 1: NUEVA FUNCIÓN PARA CONFIGURAR LA TABLA ---
        // (La llamamos desde Form1_Load)
        private void ConfigurarTabla()
        {
            // Limpia columnas si ya existen
            dgvPresupuesto.Columns.Clear();

            // Configura la tabla (dgvPresupuesto)
            dgvPresupuesto.ReadOnly = true;
            dgvPresupuesto.AllowUserToAddRows = false;
            dgvPresupuesto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Añade las columnas que queremos
            dgvPresupuesto.Columns.Add("Nombre", "Nombre");
            dgvPresupuesto.Columns.Add("Descripcion", "Descripción");
            dgvPresupuesto.Columns.Add("PrecioNeto", "Precio Neto");
            dgvPresupuesto.Columns.Add("PrecioImpuesto", "Precio (IVA Incl.)");
            dgvPresupuesto.Columns.Add("PrecioFinal", "Precio Final (Extra)");

            dgvPresupuesto.Columns.Add("PorcentajeExtra", "Porcentaje Extra");
            dgvPresupuesto.Columns["PorcentajeExtra"].Visible = false;

            // Opcional: Dar formato de moneda a las columnas de precio
            dgvPresupuesto.Columns["PrecioNeto"].DefaultCellStyle.Format = "c";
            dgvPresupuesto.Columns["PrecioImpuesto"].DefaultCellStyle.Format = "c";
            dgvPresupuesto.Columns["PrecioFinal"].DefaultCellStyle.Format = "c";
        }
        // --- BLOQUE 4: NUEVA FUNCIÓN PARA CALCULAR EL TOTAL ---
        private void ActualizarTotal()
        {
            decimal totalGeneral = 0;

            // Recorremos cada FILA en la tabla
            foreach (DataGridViewRow fila in dgvPresupuesto.Rows)
            {
                // Obtenemos el valor de la celda "Precio Final" (está en la columna 4)
                // Usamos [4] porque los índices empiezan en 0
                if (fila.Cells[4].Value != null)
                {
                    totalGeneral += Convert.ToDecimal(fila.Cells[4].Value);
                }
            }

            // Actualizamos el texto del Label con formato de moneda
            lblTotal.Text = $"TOTAL: {totalGeneral:C}"; // "C" es el formato de Moneda
        }

        // --- BLOQUE 2: NUEVA FUNCIÓN PARA EL BOTÓN AGREGAR PRODUCTO ---
        // (Asegúrate de conectar tu botón a esto, mira las instrucciones abajo)
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // --- 1. Definir tasas ---
            const decimal TASA_IVA = 0.16m; // 16% de IVA. 'm' significa 'decimal'

            // --- 2. Validar y obtener datos de los TextBox ---
            // (Asegúrate que tus TextBox se llamen txtNombre, txtDescripcion, etc.)
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("Por favor, rellena el nombre y la descripción.");
                return;
            }

            if (!decimal.TryParse(txtPrecioNeto.Text, out decimal precioNeto))
            {
                MessageBox.Show("El precio neto no es un número válido.");
                return;
            }

            if (!decimal.TryParse(txtPorcentajeExtra.Text, out decimal porcentajeExtra))
            {
                MessageBox.Show("El porcentaje extra no es un número válido.");
                return;
            }

            // --- 3. Hacer los cálculos ---
            decimal precioConImpuesto = precioNeto * (1 + TASA_IVA);
            decimal precioFinal = precioConImpuesto * (1 + (porcentajeExtra / 100));

            // --- 4. Agregar la fila al DataGridView ---
            dgvPresupuesto.Rows.Add(
                txtNombre.Text,
                txtDescripcion.Text,
                precioNeto,
                precioConImpuesto,
                precioFinal,
                porcentajeExtra
            );

            // --- 5. Limpiar los campos para el siguiente producto ---
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtPrecioNeto.Clear();
            txtPorcentajeExtra.Clear();
            txtNombre.Focus();

            ActualizarTotal();
        }

        // --- BLOQUE 3: NUEVA FUNCIÓN PARA EL BOTÓN EXPORTAR ---
        // (Asegúrate de conectar tu botón a esto)
        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgvPresupuesto.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.");
                return;
            }

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Presupuesto");

                // --- 1. AÑADIR EL LOGO ---
                // Definimos la fila donde comenzará la tabla
                int filaInicioTabla = 1;

                if (!string.IsNullOrEmpty(logoPath) && File.Exists(logoPath))
                {
                    try
                    {
                        // Añade la imagen al worksheet
                        var imagen = worksheet.AddPicture(logoPath)
                                            .MoveTo(worksheet.Cell("A1"))
                                            .Scale(0.5); // Escala la imagen al 50% (ajusta si es necesario)

                        // Hacemos que la fila 1 sea más alta para el logo
                        worksheet.Row(1).Height = imagen.Height * 0.8; // Ajusta la altura
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"No se pudo cargar el logo: {ex.Message}");
                    }
                }

                // --- 2. AÑADIR DATOS FISCALES ---
                // Combinamos celdas para el nombre de la empresa
                worksheet.Cell("C2").Value = txtNombreEmpresa.Text;
                worksheet.Range("C2:E2").Merge().Style.Font.SetBold(true).Font.SetFontSize(14);
                worksheet.Range("C2:E2").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                // Datos Fiscales
                worksheet.Cell("C3").Value = txtDatosFiscales.Text;
                worksheet.Range("C3:E3").Merge().Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                // Contacto
                worksheet.Cell("C4").Value = txtContacto.Text;
                worksheet.Range("C4:E4").Merge().Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                // Dejamos un espacio y definimos dónde empieza la tabla
                filaInicioTabla = 7; // La tabla empezará en la fila 7


                // --- 3. ESCRIBIR LA TABLA (AHORA DESDE filaInicioTabla) ---

                // Escribir cabeceras
                for (int i = 0; i < dgvPresupuesto.Columns.Count; i++)
                {
                    // La cabecera va en la fila 7
                    worksheet.Cell(filaInicioTabla, i + 1).Value = dgvPresupuesto.Columns[i].HeaderText;
                    worksheet.Cell(filaInicioTabla, i + 1).Style.Font.SetBold(true);
                    worksheet.Cell(filaInicioTabla, i + 1).Style.Fill.SetBackgroundColor(XLColor.LightGray);
                }

                // Escribir datos
                for (int r = 0; r < dgvPresupuesto.Rows.Count; r++)
                {
                    // Los datos empiezan en la fila 8 (filaInicioTabla + 1)
                    int filaActual = filaInicioTabla + 1 + r;

                    for (int c = 0; c < dgvPresupuesto.Columns.Count; c++)
                    {
                        var cellValue = dgvPresupuesto.Rows[r].Cells[c].Value;
                        var cellDeExcel = worksheet.Cell(filaActual, c + 1);

                        if (c < 2) // Columna 0 (Nombre) o 1 (Descripción)
                        {
                            cellDeExcel.SetValue(cellValue.ToString());
                        }
                        else // Columnas de precio
                        {
                            cellDeExcel.SetValue(Convert.ToDecimal(cellValue));
                            cellDeExcel.Style.NumberFormat.Format = "$#,##0.00";
                        }
                    }
                }

                // Ajustar el ancho de las columnas al contenido
                worksheet.Columns().AdjustToContents();

                // --- 4. GUARDAR EL ARCHIVO ---
                using (var saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Archivos de Excel (*.xlsx)|*.xlsx";
                    saveFileDialog.Title = "Guardar presupuesto";
                    saveFileDialog.FileName = $"Presupuesto_{DateTime.Now:yyyyMMdd}.xlsx";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            workbook.SaveAs(saveFileDialog.FileName);
                            MessageBox.Show("¡Exportado con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error al guardar el archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        // --- ESTOS YA LOS TENÍAS, PUEDEN QUEDARSE VACÍOS ---
        private void label1_Click(object sender, EventArgs e)
        {
            // No necesitas nada aquí
        }

        private void dgvPresupuesto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // No necesitas nada aquí
        }

        private void btnCargarLogo_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Seleccionar Logo";
                ofd.Filter = "Imágenes (*.jpg; *.jpeg; *.png; *.bmp)|*.jpg; *.jpeg; *.png; *.bmp";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    // Guardamos la ruta en nuestra variable global
                    logoPath = ofd.FileName;
                    // Mostramos al usuario el archivo que seleccionó
                    lblLogoPath.Text = Path.GetFileName(logoPath);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // 1. Verificar si hay alguna fila seleccionada
            if (dgvPresupuesto.SelectedRows.Count > 0)
            {
                // 2. Preguntar al usuario si está seguro
                DialogResult confirmacion = MessageBox.Show(
                    "¿Estás seguro de que deseas eliminar este producto?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                // 3. Si el usuario presiona "Sí"
                if (confirmacion == DialogResult.Yes)
                {
                    // 4. Eliminar la fila seleccionada
                    // Usamos SelectedRows[0] porque asumimos que solo se puede seleccionar una fila
                    dgvPresupuesto.Rows.Remove(dgvPresupuesto.SelectedRows[0]);

                    // 5. ¡Volver a calcular el total!
                    ActualizarTotal();
                }
            }
            else
            {
                // Si no hay ninguna fila seleccionada, avisar al usuario
                MessageBox.Show("Por favor, selecciona la fila completa que deseas eliminar.", "Ningún producto seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnExportarPDF_Click(object sender, EventArgs e)
        {
            // 1. Validar que haya datos
            if (dgvPresupuesto.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.");
                return;
            }

            // 2. Preguntar dónde guardar
            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Archivos PDF (*.pdf)|*.pdf";
                saveFileDialog.Title = "Guardar presupuesto en PDF";
                saveFileDialog.FileName = $"Presupuesto_{DateTime.Now:yyyyMMdd}.pdf";

                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return; // El usuario canceló
                }

                try
                {
                    // 3. Crear el documento
                    var document = Document.Create(container =>
                    {
                        // Definimos la página
                        container.Page(page =>
                        {
                            // Configuraciones de la página
                            page.Margin(30); // Márgenes
                            page.Size(PageSizes.Letter); // Tamaño carta
                                                         // --- CORRECCIÓN 2 ---
                            page.DefaultTextStyle(style => style.FontSize(10).FontFamily(Fonts.Arial));

                            // --- ENCABEZADO ---
                            page.Header().Row(row =>
                            {
                                // Columna del Logo
                                if (!string.IsNullOrEmpty(logoPath) && File.Exists(logoPath))
                                {
                                    try
                                    {
                                        // Carga la imagen desde el archivo
                                        byte[] logoData = File.ReadAllBytes(logoPath);
                                        // --- CORRECCIÓN 3 ---
                                        row.RelativeItem().AlignLeft().MaxHeight(75).Image(logoData).FitArea();
                                    }
                                    catch { /* Ignorar error de logo si falla */ }
                                }

                                // Espacio (si no hay logo, esto empuja los datos a la derecha)
                                row.ConstantItem(50);

                                // Columna de Datos Fiscales
                                row.RelativeItem().Column(col =>
                                {
                                    col.Item().AlignRight().Text(txtNombreEmpresa.Text).Bold().FontSize(14);
                                    col.Item().AlignRight().Text(txtDatosFiscales.Text);
                                    col.Item().AlignRight().Text(txtContacto.Text);
                                });
                            });

                            // --- CONTENIDO (LA TABLA) ---
                            page.Content().PaddingTop(20).Table(table =>
                            {
                                // (El resto de tu código de la tabla está perfecto)
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn(2); // Nombre
                                    columns.RelativeColumn(4); // Descripción
                                    columns.RelativeColumn(2); // Precio Neto
                                    columns.RelativeColumn(2); // Precio IVA
                                    columns.RelativeColumn(2); // Precio Final
                                });

                                // --- Cabecera de la tabla ---
                                table.Header(header =>
                                {
                                    header.Cell().Background("#464646").Padding(5).Text("Nombre").FontColor("#FFF");
                                    header.Cell().Background("#464646").Padding(5).Text("Descripción").FontColor("#FFF");
                                    header.Cell().Background("#464646").Padding(5).AlignRight().Text("Precio Neto").FontColor("#FFF");
                                    header.Cell().Background("#464646").Padding(5).AlignRight().Text("Precio (IVA Incl.)").FontColor("#FFF");
                                    header.Cell().Background("#464646").Padding(5).AlignRight().Text("Precio Final").FontColor("#FFF");
                                });

                                // --- Filas de la tabla ---
                                foreach (DataGridViewRow dgvRow in dgvPresupuesto.Rows)
                                {
                                    table.Cell().BorderBottom(1).BorderColor("#CCC").Padding(5)
                                         .Text(dgvRow.Cells[0].Value.ToString());

                                    table.Cell().BorderBottom(1).BorderColor("#CCC").Padding(5)
                                         .Text(dgvRow.Cells[1].Value.ToString());

                                    table.Cell().BorderBottom(1).BorderColor("#CCC").Padding(5).AlignRight()
                                         .Text($"{Convert.ToDecimal(dgvRow.Cells[2].Value):C}"); // Neto

                                    table.Cell().BorderBottom(1).BorderColor("#CCC").Padding(5).AlignRight()
                                         .Text($"{Convert.ToDecimal(dgvRow.Cells[3].Value):C}"); // Con IVA

                                    table.Cell().BorderBottom(1).BorderColor("#CCC").Padding(5).AlignRight()
                                         .Text($"{Convert.ToDecimal(dgvRow.Cells[4].Value):C}"); // Final
                                }
                            });

                            // --- PIE DE PÁGINA (EL TOTAL) ---
                            page.Footer()
                                .PaddingTop(10)
                                .AlignRight()
                                .Text(lblTotal.Text) // Usamos el texto del Label que ya tenemos
                                .Bold()
                                .FontSize(16);
                        });
                    });

                    // 4. Generar y guardar el archivo PDF
                    document.GeneratePdf(saveFileDialog.FileName);

                    MessageBox.Show("¡PDF exportado con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al generar el PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // 1. Preguntar al usuario dónde guardar
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Archivo de Presupuesto (*.json)|*.json";
                saveFileDialog.Title = "Guardar Presupuesto";
                saveFileDialog.FileName = $"Presupuesto_{DateTime.Now:yyyyMMdd}.json";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // 2. Crear el objeto de datos para guardar
                        PresupuestoGuardado datosAGuardar = new PresupuestoGuardado();

                        // 3. Llenar los datos de la empresa
                        datosAGuardar.NombreEmpresa = txtNombreEmpresa.Text;
                        datosAGuardar.DatosFiscales = txtDatosFiscales.Text;
                        datosAGuardar.Contacto = txtContacto.Text;
                        datosAGuardar.LogoPath = this.logoPath; // Usamos la variable global

                        // 4. Llenar la lista de productos
                        datosAGuardar.Productos = new List<ProductoItem>();

                        // Recorremos la tabla (DataGridView)
                        foreach (DataGridViewRow dgvRow in dgvPresupuesto.Rows)
                        {
                            // Creamos un nuevo ProductoItem
                            ProductoItem item = new ProductoItem();

                            item.Nombre = dgvRow.Cells[0].Value.ToString();
                            item.Descripcion = dgvRow.Cells[1].Value.ToString();
                            item.PrecioNeto = Convert.ToDecimal(dgvRow.Cells[2].Value);
                            // Leemos el porcentaje de la columna 5 (oculta)
                            item.PorcentajeExtra = Convert.ToDecimal(dgvRow.Cells[5].Value);

                            // Añadimos el item a nuestra lista
                            datosAGuardar.Productos.Add(item);
                        }

                        // 5. Convertir el objeto completo a un string JSON
                        string json = JsonConvert.SerializeObject(datosAGuardar, Formatting.Indented);

                        // 6. Guardar el string en el archivo
                        File.WriteAllText(saveFileDialog.FileName, json);

                        MessageBox.Show("¡Presupuesto guardado con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al guardar el archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            // 1. Preguntar al usuario qué archivo abrir
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Archivo de Presupuesto (*.json)|*.json";
                openFileDialog.Title = "Abrir Presupuesto";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // 2. Leer todo el texto del archivo
                        string json = File.ReadAllText(openFileDialog.FileName);

                        // 3. Convertir (deserializar) el JSON a nuestro objeto
                        PresupuestoGuardado datosCargados = JsonConvert.DeserializeObject<PresupuestoGuardado>(json);

                        // --- 4. LIMPIAR EL FORMULARIO ACTUAL ---
                        txtNombreEmpresa.Clear();
                        txtDatosFiscales.Clear();
                        txtContacto.Clear();
                        lblLogoPath.Text = "";
                        this.logoPath = "";
                        dgvPresupuesto.Rows.Clear(); // Limpiamos la tabla

                        // --- 5. RELLENAR LOS DATOS DE LA EMPRESA ---
                        txtNombreEmpresa.Text = datosCargados.NombreEmpresa;
                        txtDatosFiscales.Text = datosCargados.DatosFiscales;
                        txtContacto.Text = datosCargados.Contacto;
                        this.logoPath = datosCargados.LogoPath; // Guardamos la ruta del logo
                        if (!string.IsNullOrEmpty(this.logoPath))
                        {
                            lblLogoPath.Text = Path.GetFileName(this.logoPath);
                        }

                        // --- 6. RELLENAR LA TABLA (PRODUCTO POR PRODUCTO) ---
                        const decimal TASA_IVA = 0.16m; // Re-definimos el IVA

                        foreach (ProductoItem item in datosCargados.Productos)
                        {
                            // Volvemos a hacer los cálculos (igual que en btnAgregar)
                            decimal precioConImpuesto = item.PrecioNeto * (1 + TASA_IVA);
                            decimal precioFinal = precioConImpuesto * (1 + (item.PorcentajeExtra / 100));

                            // Añadimos la fila a la tabla
                            dgvPresupuesto.Rows.Add(
                                item.Nombre,
                                item.Descripcion,
                                item.PrecioNeto,
                                precioConImpuesto,
                                precioFinal,
                                item.PorcentajeExtra
                            );
                        }

                        // 7. Actualizar el total
                        ActualizarTotal();

                        MessageBox.Show("¡Presupuesto cargado con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al abrir el archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
/// <summary>
/// Define el "molde" para un solo producto en la lista.
/// Guardamos los datos de entrada, no los calculados.
/// </summary>
public class ProductoItem
{
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public decimal PrecioNeto { get; set; }
    public decimal PorcentajeExtra { get; set; }
}

/// <summary>
/// Define el "molde" para el archivo de presupuesto completo.
/// </summary>
public class PresupuestoGuardado
{
    // Datos de la empresa
    public string NombreEmpresa { get; set; }
    public string DatosFiscales { get; set; }
    public string Contacto { get; set; }
    public string LogoPath { get; set; }

    // Lista de todos los productos
    public List<ProductoItem> Productos { get; set; }
}
