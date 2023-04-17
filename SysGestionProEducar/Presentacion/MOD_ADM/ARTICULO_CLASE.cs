using BLL;
using Entidades;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
namespace Presentacion.MOD_ADM
{
    public partial class ARTICULO_CLASE : Form
    {
        string boton = string.Empty; DIALOGOS.Dialog3 obs = new DIALOGOS.Dialog3();
        DataTable dtArticulo, dtArtClase, dtArtUbicacion, dtArticuloContenido = new DataTable();
        //DataSet dsTransportista;
        int fila;
        articulosBLL artBLL = new articulosBLL();
        articulosTo artTo = new articulosTo();
        public ARTICULO_CLASE()
        {
            InitializeComponent();
        }

        private void ARTICULO_CLASE_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            dtArticulo = artBLL.obtenerArticulosBLL();
            cargaDataGrid();
            llenaComboClase();
            llenaComboUM();
            llenaAlmacen();
            btn_nuevo.Select();
        }
        private void cargaDataGrid()
        {
            if (dtArticulo.Rows.Count > 0)
            {
                dgw1.Rows.Clear();
                foreach (DataRow rw in dtArticulo.Rows)
                {
                    int rowId = dgw1.Rows.Add();
                    DataGridViewRow row = dgw1.Rows[rowId];
                    row.Cells["cod"].Value = rw["Codigo"].ToString();
                    row.Cells["desc"].Value = rw["Descripción"].ToString();
                    row.Cells["um"].Value = rw["U.M."].ToString();
                    row.Cells["igv"].Value = rw["IGV"].ToString();
                    row.Cells["suspendido"].Value = rw["SUSPENDIDO"].ToString();
                    row.Cells["status_serie"].Value = rw["STATUS_SERIE"].ToString();
                    row.Cells["observacion"].Value = rw["OBSERVACION"].ToString();
                    row.Cells["imagen"].Value = rw["IMAGEN"].ToString();
                    row.Cells["desc_um"].Value = rw["DESCRIPCION"].ToString();
                    row.Cells["caract"].Value = rw["DESC_CARACTERISTICA"].ToString();
                    row.Cells["status_detalle"].Value = rw["STATUS_DETALLE"].ToString();
                }
            }
        }
        private void llenaComboClase()
        {
            claseBLL claBLL = new claseBLL();
            DataTable dt = claBLL.obtenerClaseArticuloparaGrupoBLL();
            cbo_clase.ValueMember = "COD_CLASE";
            cbo_clase.DisplayMember = "DESC_CLASE";
            cbo_clase.DataSource = dt;
        }
        private void llenaComboUM()
        {
            unidadMedidaBLL umBLL = new unidadMedidaBLL();
            DataTable dt = umBLL.obtenerUnidadMedidaBLL();
            cbo_unidad.ValueMember = "Cod";
            cbo_unidad.DisplayMember = "Descripción";
            cbo_unidad.DataSource = dt;
        }
        private void llenaAlmacen()
        {
            almacenesBLL almBLL = new almacenesBLL();
            DataTable dt = almBLL.obtenerAlmacenesparaArticuloBLL();
            cboalm.ValueMember = "COD_ALMACEN";
            cboalm.DisplayMember = "DESC_CORTA";
            cboalm.DataSource = dt;
        }
        private void ARTICULO_CLASE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void Limpiar()
        {
            txt_cod.Text = "";
            txt_desc.Text = "";
            cbo_unidad.SelectedIndex = -1;
            ch_igv.Checked = false;
            ch_sus.Checked = false;
            txt_obs.Text = "";
            txt_img.Text = "";
            //Clase Articulo
            cbo_clase.SelectedIndex = -1;
            cbo_grupo.SelectedIndex = -1;
            cbo_subgrupo.SelectedIndex = -1;
            txt_minimo.Text = "";
            txt_maximo.Text = "";
            DGW_DET.Rows.Clear();
            //Ubicacion
            cboalm.SelectedIndex = -1;
            txtclase1.Text = "";
            txtgrupo1.Text = "";
            txtsub.Text = "";
            txtstockmin.Text = "";
            //Articulo Contenido
            txt_cod_art_contenido.Text = "";
            txt_desc_contenido.Text = "";
            ch_sus_contenido.Checked = false;
            dgw_articulo_contenido.Rows.Clear();
            dgw_ubi1.Rows.Clear();
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            boton = "NUEVO";
            btn_guardar.Visible = true;
            btn_modificar2.Visible = false;
            Limpiar();
            //string codi = obtieneCodigo();
            txt_cod.Text = "";// codi == "" ? "0000000001" : codi;
            txt_cod.ReadOnly = false;
            TabControl1.SelectedTab = TabPage2;
            txt_cod.Select();
        }
        private string obtieneCodigo()
        {
            return artBLL.obtenerNuevoCodigoBLL();
        }
        private void btn_modificar_Click(object sender, EventArgs e)
        {
            if (dgw1.Rows.Count <= 0)
                return;
            int i = dgw1.CurrentRow.Index;
            boton = "MODIFICAR";
            //-----UBICACION
            dgw_ubi1.Rows.Clear();
            cboalm.SelectedIndex = -1;
            txtclase1.Clear();
            txtgrupo1.Clear();
            txtsub.Clear();
            txtstockmin.Clear();
            //'-------
            LIMPIAR_CABECERA();
            LIMPIAR_DETALLE();
            btn_guardar.Visible = false;
            btn_modificar2.Visible = true;
            //Limpiar();
            //CargarDatos();
            CARGAR_DATOS();
            CARGAR_DGW_DET();
            Panel1.Visible = false;
            DGW_DET.Visible = true;
            txt_cod.ReadOnly = true;
            //txt_cod.ReadOnly = true;
            TabControl1.SelectedTab = TabPage2;
            txt_cod.Select();
        }
        private void CARGAR_DGW_DET()
        {
            articuloClaseBLL arcBLL = new articuloClaseBLL();
            articuloClaseTo arcTo = new articuloClaseTo();
            articuloUbicacionBLL aruBLL = new articuloUbicacionBLL();
            articuloUbicacionTo aruTo = new articuloUbicacionTo();
            articuloContenidoBLL atcBLL = new articuloContenidoBLL();
            articuloContenidoTo atcTo = new articuloContenidoTo();
            DGW_DET.Rows.Clear();
            arcTo.COD_ARTICULO = dgw1[0, dgw1.CurrentRow.Index].Value.ToString();
            dtArtClase = arcBLL.obtenerArticuloClaseBLL(arcTo);
            foreach (DataRow rw in dtArtClase.Rows)
            {
                int rowId = DGW_DET.Rows.Add();
                DataGridViewRow row = DGW_DET.Rows[rowId];
                row.Cells["codcla"].Value = rw["COD_CLASE"].ToString();
                row.Cells["cla"].Value = rw["Column1"].ToString();
                row.Cells["gru"].Value = rw["Column2"].ToString();
                row.Cells["codgru"].Value = rw["COD_GRUPO"].ToString();
                row.Cells["sub"].Value = rw["Column3"].ToString();
                row.Cells["codsub"].Value = rw["COD_SUBGRUPO"].ToString();
                row.Cells["min"].Value = rw["STOCK_MINIMO"].ToString();
                row.Cells["max"].Value = rw["STOCK_MAXIMO"].ToString();
            }
            dgw_ubi1.Rows.Clear();
            aruTo.COD_ARTICULO = dgw1[0, dgw1.CurrentRow.Index].Value.ToString();
            dtArtUbicacion = aruBLL.obtenerArticuloUbicacionBLL(aruTo);
            foreach (DataRow rw in dtArtUbicacion.Rows)
            {
                int rowId = dgw_ubi1.Rows.Add();
                DataGridViewRow row = dgw_ubi1.Rows[rowId];
                row.Cells["item1"].Value = rw["ITEM"].ToString();
                row.Cells["COD_ALMACEN"].Value = rw["COD_ALMACEN"].ToString();
                row.Cells["CAMPO1"].Value = rw["CAMPO1"].ToString();
                row.Cells["CAMPO2"].Value = rw["CAMPO2"].ToString();
                row.Cells["CAMPO3"].Value = rw["CAMPO3"].ToString();
                row.Cells["CAMPO4"].Value = rw["CAMPO4"].ToString();
            }
            dgw_articulo_contenido.Rows.Clear();
            atcTo.COD_ARTICULO = dgw1.CurrentRow.Cells["cod"].Value.ToString();
            dtArticuloContenido = atcBLL.obtenerArticuloContenidoBLL(atcTo);
            foreach (DataRow rw in dtArticuloContenido.Rows)
            {
                int rowId = dgw_articulo_contenido.Rows.Add();
                DataGridViewRow row = dgw_articulo_contenido.Rows[rowId];
                row.Cells["cod_art"].Value = rw["COD_ARTICULO"].ToString();
                row.Cells["cod_art_cont"].Value = rw["COD_ART_CONTENIDO"].ToString();
                row.Cells["desc_art_cont"].Value = rw["DESC_ARTICULO"].ToString();
                row.Cells["st_sus_cont"].Value = rw["ST_SUSPENDIDO"].ToString();
            }
            //CARACTERISTICA
            obs.txt_obs.Text = dgw1.CurrentRow.Cells["caract"].Value.ToString();
        }
        private void CARGAR_DATOS()
        {
            txt_cod.Text = dgw1[0, dgw1.CurrentRow.Index].Value.ToString();
            txt_desc.Text = dgw1[1, dgw1.CurrentRow.Index].Value.ToString();
            cbo_unidad.SelectedValue = dgw1[2, dgw1.CurrentRow.Index].Value.ToString();
            ch_igv.Checked = dgw1[3, dgw1.CurrentRow.Index].Value.ToString() == "1" ? true : false;
            ch_sus.Checked = dgw1[4, dgw1.CurrentRow.Index].Value.ToString() == "1" ? true : false;
            CH_SERIE.Checked = dgw1[5, dgw1.CurrentRow.Index].Value.ToString() == "1" ? true : false;
            txt_obs.Text = dgw1[6, dgw1.CurrentRow.Index].Value.ToString();
            txt_img.Text = dgw1[7, dgw1.CurrentRow.Index].Value.ToString();
            CH_DETALLE.Checked = dgw1.CurrentRow.Cells["STATUS_DETALLE"].Value.ToString() == "1" ? true : false;
        }
        private void LIMPIAR_CABECERA()
        {
            obs.txt_obs.Clear();
            txt_cod.Clear();
            txt_desc.Clear();
            cbo_unidad.SelectedIndex = -1;
            txt_obs.Clear();
            ch_igv.Checked = true;
            ch_sus.Checked = false;
            txt_desc.ReadOnly = false;
            cbo_unidad.Enabled = true;
            txt_obs.ReadOnly = false;
            ch_igv.Enabled = true;
            ch_sus.Enabled = true;
            DGW_DET.Rows.Clear();
            Panel1.Visible = false;// : Panel_apli.Visible = False
            CH_SERIE.Checked = false;
            CH_SERIE.Enabled = true;
            CH_DETALLE.Checked = false;
            CH_DETALLE.Enabled = true;
            TabControl2.Enabled = true;
            txt_img.Clear();
        }
        private void CargarDatos()
        {
            txt_cod.Text = dgw1[0, dgw1.CurrentRow.Index].Value.ToString();
            txt_desc.Text = dgw1[1, dgw1.CurrentRow.Index].Value.ToString();
            cbo_unidad.SelectedIndex = 0;
        }
        private bool validaGuardar()
        {
            bool result = true;
            artTo.COD_ARTICULO = txt_cod.Text.Trim();
            if (txt_cod.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el código !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_cod.Focus();
                return result = false;
            }
            if (txt_desc.Text == "")
            {
                MessageBox.Show("Ingrese la descripcion  !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_desc.Focus();
                return result = false;
            }
            if (cbo_unidad.SelectedIndex == -1)
            {
                MessageBox.Show("Elija la unidad de medida  !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_unidad.Focus();
                return result = false;
            }
            if (artBLL.VerificaArticuloBLL(artTo) > 0)
            {
                MessageBox.Show("El código del articulo ya existe !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_cod.Focus();
                return result = false;
            }

            return result;
        }
        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (!validaGuardar())
                return;
            DialogResult rs = MessageBox.Show("¿ Esta seguro de adicionar un nuevo Artículo ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                //
                artTo.COD_ARTICULO = txt_cod.Text;
                artTo.DESC_ARTICULO = txt_desc.Text;
                artTo.NRO_PARTE = "";
                artTo.DESC_APLICACION = "";
                artTo.UNIDAD_MEDIDA = cbo_unidad.SelectedValue.ToString();
                artTo.STATUS_IGV = ch_igv.Checked == true ? "1" : "0";
                artTo.STATUS_SUSPENDIDO = ch_sus.Checked == true ? "1" : "0";
                artTo.OBSERVACION = txt_obs.Text;
                artTo.COD_EQUIVALENTE = "";
                artTo.STATUS_SERIE = CH_SERIE.Checked == true ? "1" : "0";
                artTo.STATUS_DETALLE = CH_DETALLE.Checked == true ? "1" : "0";
                artTo.COD_ANTERIOR = "";
                artTo.IMAGEN = txt_img.Text;
                artTo.STATUS_PERCEPCION = "";
                dtArtClase = obtieneDTArtClase();
                dtArtUbicacion = obtieneDTArtUbicacion();
                dtArticuloContenido = HelpersBLL.obtenerDT(dgw_articulo_contenido);//obtieneDTArtContenido();
                if (!artBLL.adicionaInsertaArticulosBLL(artTo, dtArtClase, dtArtUbicacion,
                    dtArticuloContenido, txt_cod.Text, obs.txt_obs.Text, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("SE ADICIONÓ CORRECTAMENTE EL ARTICULO!!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //
                    //string igv = ch_igv.Checked == true ? "1" : "0";
                    //string sus = ch_sus.Checked == true ? "1" : "0";
                    //string sta = CH_SERIE.Checked == true ? "1" : "0";

                    dgw1.Rows.Add(txt_cod.Text, txt_desc.Text, cbo_unidad.SelectedValue.ToString(), artTo.STATUS_IGV,
                        artTo.STATUS_SUSPENDIDO, artTo.STATUS_SERIE, txt_obs.Text, txt_img.Text, cbo_unidad.Text, obs.txt_obs.Text,
                        CH_DETALLE.Checked == true ? "1" : "0");
                    TabControl1.SelectedTab = TabPage1;
                    btn_nuevo.Select();
                }
            }

        }
        private DataTable obtieneDTArtClase()
        {
            DataTable table = new DataTable();
            foreach (DataGridViewColumn column in DGW_DET.Columns)
            {
                table.Columns.Add(column.Name, typeof(string));
            }
            foreach (DataGridViewRow row in DGW_DET.Rows)
            {
                DataRow dataRow = table.NewRow();
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    dataRow[i] = row.Cells[i].Value != null ? row.Cells[i].Value : DBNull.Value;
                }
                table.Rows.Add(dataRow);
            }
            return table;
        }
        private DataTable obtieneDTArtUbicacion()
        {
            DataTable table = new DataTable();
            foreach (DataGridViewColumn column in dgw_ubi1.Columns)
            {
                table.Columns.Add(column.Name, typeof(string));
            }
            foreach (DataGridViewRow row in dgw_ubi1.Rows)
            {
                DataRow dataRow = table.NewRow();
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    dataRow[i] = row.Cells[i].Value != null ? row.Cells[i].Value : DBNull.Value;
                }
                table.Rows.Add(dataRow);
            }
            return table;
        }
        private void btn_modificar2_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE MODIFICAR EL ARTICULO ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;
                artTo.COD_ARTICULO = txt_cod.Text;
                artTo.DESC_ARTICULO = txt_desc.Text;
                artTo.NRO_PARTE = "";
                artTo.DESC_APLICACION = "";
                artTo.UNIDAD_MEDIDA = cbo_unidad.SelectedValue.ToString();
                artTo.STATUS_IGV = ch_igv.Checked == true ? "1" : "0";
                artTo.STATUS_SUSPENDIDO = ch_sus.Checked == true ? "1" : "0";
                artTo.OBSERVACION = txt_obs.Text;
                artTo.COD_EQUIVALENTE = "";
                artTo.STATUS_SERIE = CH_SERIE.Checked == true ? "1" : "0";
                artTo.STATUS_DETALLE = CH_DETALLE.Checked == true ? "1" : "0";
                artTo.COD_ANTERIOR = "";
                artTo.IMAGEN = txt_img.Text;
                artTo.STATUS_PERCEPCION = "";
                dtArtClase = obtieneDTArtClase();
                dtArtUbicacion = obtieneDTArtUbicacion();
                dtArticuloContenido = HelpersBLL.obtenerDT(dgw_articulo_contenido);
                if (!artBLL.modificaActualizaArticulosBLL(artTo, dtArtClase, dtArtUbicacion,
                    dtArticuloContenido, txt_cod.Text, obs.txt_obs.Text, ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("SE MODIFICÓ CORRECTAMENTE EL ARTICULO !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //
                    dgw1.CurrentRow.Cells["cod"].Value = txt_cod.Text;
                    dgw1.CurrentRow.Cells["desc"].Value = txt_desc.Text;
                    //dgw1.CurrentRow.Cells["cod_um"].Value = cbo_unidad.SelectedValue.ToString();
                    dgw1.CurrentRow.Cells["um"].Value = cbo_unidad.SelectedValue.ToString();
                    dgw1.CurrentRow.Cells["igv"].Value = ch_igv.Checked == true ? "1" : "0";
                    dgw1.CurrentRow.Cells["suspendido"].Value = ch_sus.Checked == true ? "1" : "0";
                    dgw1.CurrentRow.Cells["status_serie"].Value = CH_SERIE.Checked == true ? "1" : "0";
                    dgw1.CurrentRow.Cells["status_detalle"].Value = CH_DETALLE.Checked == true ? "1" : "0";
                    dgw1.CurrentRow.Cells["observacion"].Value = txt_obs.Text;
                    dgw1.CurrentRow.Cells["imagen"].Value = txt_img.Text;
                    dgw1.CurrentRow.Cells["desc_um"].Value = cbo_unidad.Text;
                    dgw1.CurrentRow.Cells["caract"].Value = obs.txt_obs.Text;
                    TabControl1.SelectedTab = TabPage1;
                    btn_nuevo.Select();
                }
            }

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = TabPage1;
            btn_nuevo.Select();
        }
        private bool validaEliminar()
        {
            bool result = true;
            string errMensaje = "";
            if (dgw1.Rows.Count <= 0)
                return result = false;
            artTo.COD_ARTICULO = dgw1.CurrentRow.Cells["cod"].Value.ToString();
            if (artBLL.validaEliminarArticuloBLL(artTo, ref errMensaje))
            {
                MessageBox.Show("No se puede eliminar porque forma parte de un Kit !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return result = false; ;
            }
            else
            {
                if (errMensaje != "")
                {
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return result = false;
                }
            }
            return result;
        }
        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (!validaEliminar())
                return;
            DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE ELIMINAR ESTE ARTICULO ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string errMensaje = string.Empty;

                if (!artBLL.eliminaArticuloBLL(dgw1[0, dgw1.CurrentRow.Index].Value.ToString(), ref errMensaje))
                    MessageBox.Show("ERROR............... !!!! \n" + errMensaje, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("SE ELIMINÓ CORRECTAMENTE EL ARTICULO !!!" + errMensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //
                    dgw1.Rows.RemoveAt(dgw1.CurrentRow.Index);
                }
            }
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabControl1.SelectedTab == TabPage2)
            {
                if (boton == "NUEVO")
                {
                    boton = "DETALLES1";
                }
                else if (boton == "MODIFICAR")
                {
                    boton = "DETALLES2";
                }
                else
                {
                    boton = "DETALLES";
                    Limpiar();
                    if (dgw1.Rows.Count == 0)
                    {
                    }
                    else
                    {
                        //CargarDatos();
                        CARGAR_DATOS();
                        CARGAR_DGW_DET();
                    }


                    //txt_cod.ReadOnly = true;
                    //txt_desc.ReadOnly = true;
                    //txtdescc.ReadOnly = true;
                    btn_guardar.Visible = false;
                    btn_modificar2.Visible = false;
                }
            }
            else
                btn_nuevo.Select();
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            DGW_DET.Visible = false;
            Panel1.Visible = true;
            BTN_GUARDAR2.Visible = true;
            BTN_MODIFICAR4.Visible = false;
            LIMPIAR_DETALLE();
            cbo_clase.Focus();
        }
        private void LIMPIAR_DETALLE()
        {
            TXT_CLASE.Clear();
            cbo_clase.SelectedIndex = -1;
            TXT_GRUPO.Clear();
            cbo_grupo.SelectedIndex = -1;
            txt_subgrupo.Clear();
            cbo_subgrupo.SelectedIndex = -1;
            cbo_clase.Enabled = true;
            cbo_grupo.Enabled = true;
            cbo_subgrupo.Enabled = true;
            txt_maximo.Text = "0.00";
            txt_minimo.Text = "0.00";
        }
        private void btn_modificar3_Click(object sender, EventArgs e)
        {
            BTN_GUARDAR2.Visible = false;
            BTN_MODIFICAR4.Visible = true;
            LIMPIAR_DETALLE();
            CARGAR_DETALLES();
            cbo_clase.Enabled = false;
            cbo_grupo.Focus();
            ITEM.Text = DGW_DET.CurrentRow.Index.ToString();
            DGW_DET.Visible = false;
            Panel1.Visible = true;
        }
        private void CARGAR_DETALLES()
        {
            int i = DGW_DET.CurrentRow.Index;
            cbo_clase.SelectedValue = DGW_DET[0, i].Value.ToString();
            cbo_grupo.SelectedValue = DGW_DET[3, i].Value.ToString();
            cbo_subgrupo.SelectedValue = DGW_DET[5, i].Value.ToString();
            txt_minimo.Text = DGW_DET[6, i].Value.ToString();
            txt_maximo.Text = DGW_DET[7, i].Value.ToString();
        }
        private void CARGAR_DETALLES_ART_CONTENIDO()
        {
            txt_cod_art_contenido.Text = dgw_articulo_contenido.CurrentRow.Cells["cod_art_cont"].Value.ToString();
            txt_desc_contenido.Text = dgw_articulo_contenido.CurrentRow.Cells["desc_art_cont"].Value.ToString();
            ch_sus_contenido.Checked = dgw_articulo_contenido.CurrentRow.Cells["st_sus_cont"].Value.ToString() == "1" ? true : false;
        }
        private void btn_eliminar2_Click(object sender, EventArgs e)
        {
            if (DGW_DET.Rows.Count > 0)
            {
                DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE ELIMINAR ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    DGW_DET.Rows.RemoveAt(DGW_DET.CurrentRow.Index);
                }
            }
        }
        private bool valida_Guardar_Clase_Articulo()
        {
            bool result = true;
            if (cbo_clase.SelectedIndex < 0)
            {
                MessageBox.Show("Elija la Clase !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_clase.Focus();
                return result = false;
            }
            if (cbo_grupo.SelectedIndex < 0)
            {
                MessageBox.Show("Elija el Grupo !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_grupo.Focus();
                return result = false;
            }
            if (cbo_subgrupo.SelectedIndex < 0)
            {
                MessageBox.Show("Elija el SubGrupo !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_subgrupo.Focus();
                return result = false;
            }
            var query = from DataGridViewRow row in DGW_DET.Rows
                        where row.Cells["codcla"].Value.ToString() == cbo_clase.SelectedValue.ToString()
                        select row;
            int cant = query.Count();
            if (cant > 0)
            {
                MessageBox.Show("El mismo Articulo y Clase ya existe !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbo_clase.Focus();
                return result = false;
            }
            return result;
        }
        private void BTN_GUARDAR2_Click(object sender, EventArgs e)
        {
            //DGW_DET.Rows.Insert(DGW_DET.Rows.Count, TXT_CLASE.Text, cbo_clase.Text, cbo_grupo.Text, TXT_GRUPO.Text, cbo_subgrupo.Text, txt_subgrupo.Text, txt_minimo.Text, txt_maximo.Text, txt_fconv.Text, "", txt_fconv1.Text, "");
            if (!valida_Guardar_Clase_Articulo())
                return;
            DGW_DET.Rows.Add(cbo_clase.SelectedValue.ToString(), cbo_clase.Text, cbo_grupo.Text, cbo_grupo.SelectedValue.ToString(),
                cbo_subgrupo.Text, cbo_subgrupo.SelectedValue.ToString(), txt_minimo.Text, txt_maximo.Text, "", "",
                "", "");

            Panel1.Visible = false;
            DGW_DET.Visible = true;
            txt_obs.Focus();
        }

        private void BTN_MODIFICAR4_Click(object sender, EventArgs e)
        {
            DGW_DET.CurrentRow.Cells["cla"].Value = cbo_clase.Text;
            DGW_DET.CurrentRow.Cells["codgru"].Value = cbo_grupo.SelectedValue.ToString();
            DGW_DET.CurrentRow.Cells["codsub"].Value = cbo_subgrupo.SelectedValue.ToString();
            DGW_DET.CurrentRow.Cells["min"].Value = txt_minimo.Text;
            DGW_DET.CurrentRow.Cells["max"].Value = txt_maximo.Text;
            Panel1.Visible = false;
            DGW_DET.Visible = true;
            txt_obs.Focus();
        }

        private void btn_cancelar2_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            DGW_DET.Visible = true;
        }

        private void btn_obs_Click(object sender, EventArgs e)
        {
            obs.ShowDialog();
        }

        private void btnagregar1_Click(object sender, EventArgs e)
        {
            dgw_ubi1.Visible = false;
            Panel2.Visible = true;
            btnsave1.Visible = true;
            btnmod1.Visible = true;
            LIMPIAR_DETALLE1();
            cboalm.Focus();
        }

        private void LIMPIAR_DETALLE1()
        {
            cboalm.SelectedIndex = -1;
            txtclase1.Clear();
            txtgrupo1.Clear();
            txtsub.Clear();
            txtstockmin.Clear();
        }
        public bool validaGuardarModificarUbicacion()
        {
            bool result = true;
            if (cboalm.SelectedIndex < 0)
            {
                MessageBox.Show("Elija el Almacen !!!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboalm.Focus();
                return result = false;
            }
            return result;
        }

        private void btnsave1_Click(object sender, EventArgs e)
        {
            if (!validaGuardarModificarUbicacion())
                return;
            dgw_ubi1.Rows.Add((dgw_ubi1.Rows.Count + 1).ToString().PadLeft(2, '0'), cboalm.SelectedValue.ToString(), txtclase1.Text, txtgrupo1.Text, txtsub.Text, txtstockmin.Text);
            Panel2.Visible = false;
            dgw_ubi1.Visible = true;
            txt_obs.Focus();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            Panel2.Visible = false;
            dgw_ubi1.Visible = true;
            txt_obs.Focus();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (dgw_ubi1.Rows.Count > 0)
            {
                DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE ELIMINAR ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    dgw_ubi1.Rows.RemoveAt(dgw_ubi1.CurrentRow.Index);
                }
            }
        }

        private void cbo_clase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_clase.SelectedIndex > -1)
            {
                grupoBLL gruBLL = new grupoBLL();
                DataTable dtGrupo = gruBLL.obtenerGrupoClaseBLL(cbo_clase.SelectedValue.ToString());
                cbo_grupo.DisplayMember = "DESC_GRUPO";
                cbo_grupo.ValueMember = "COD_GRUPO";
                cbo_grupo.DataSource = dtGrupo;
            }
        }

        private void cbo_grupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_grupo.SelectedIndex > -1)
            {
                subGrupoBLL sgruBLL = new subGrupoBLL();
                subGrupoTo sgruTo = new subGrupoTo();
                sgruTo.COD_CLASE = cbo_clase.SelectedValue.ToString();
                sgruTo.COD_GRUPO = cbo_grupo.SelectedValue.ToString();
                DataTable dtSGrupo = sgruBLL.obtenerSubGrupoClaseGrupoDAL(sgruTo);
                cbo_subgrupo.DisplayMember = "DESC_SUBGRUPO";
                cbo_subgrupo.ValueMember = "COD_SUBGRUPO";
                cbo_subgrupo.DataSource = dtSGrupo;
            }
        }

        private void BTN_IMG_Click(object sender, EventArgs e)
        {
            //artTo.DESC_APLICACION = "TDEFA";
            //artTo.DESC_ARTICULO = "IMAART";
            string RSLT = "C:\\";//artBLL.obtenerImagenBLL(artTo);//SE COMENTÒ PORQUE DEMORA MUCHO CUANDO BUSCA EN LA TABLA DIRECTORIO, DEVUELVE UNA RUTA  
            string RutaArchivo = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = RSLT;
            ofd.Filter = "Image Files (*.png;*.jpg;)|*.png;*.jpg; | All Files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                RutaArchivo = ofd.SafeFileName;
                txt_img.Text = RutaArchivo;
            }
        }

        private void btnmod1_Click(object sender, EventArgs e)
        {
            btnsave1.Visible = false;
            btnmod1.Visible = true;
            LIMPIAR_DETALLE1();
            CARGAR_DETALLES1();
            txt_item3.Text = dgw_ubi1.CurrentRow.Index.ToString();
            dgw_ubi1.Visible = false;
            Panel2.Visible = true;
        }
        private void CARGAR_DETALLES1()
        {
            int i = dgw_ubi1.CurrentRow.Index;
            cboalm.SelectedValue = dgw_ubi1[1, i].Value.ToString();
            txtclase1.Text = dgw_ubi1[2, i].Value.ToString();
            txtgrupo1.Text = dgw_ubi1[3, i].Value.ToString();
            txtsub.Text = dgw_ubi1[4, i].Value.ToString();
            txtstockmin.Text = dgw_ubi1[5, i].Value.ToString();
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            if (!validaGuardarModificarUbicacion())
                return;
            int i = dgw_ubi1.CurrentRow.Index;
            dgw_ubi1[0, i].Value = (dgw_ubi1.Rows.Count + 1).ToString();
            dgw_ubi1[1, i].Value = cboalm.SelectedValue.ToString();
            dgw_ubi1[2, i].Value = txtclase1.Text;
            dgw_ubi1[3, i].Value = txtgrupo1.Text;
            dgw_ubi1[4, i].Value = txtsub.Text;
            dgw_ubi1[5, i].Value = txtstockmin.Text;
            Panel2.Visible = false;
            dgw_ubi1.Visible = true;
            txt_obs.Focus();
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txt_letra_TextChanged(object sender, EventArgs e)
        {
            int i;
            if (ch_cod.Checked)
            {
                txt_letra.Focus();
                for (i = 0; i < dgw1.Rows.Count; i++)
                {
                    if (txt_letra.TextLength <= dgw1[0, i].Value.ToString().Length)
                    {
                        if (txt_letra.Text.ToLower() == dgw1[0, i].Value.ToString().Substring(0, txt_letra.TextLength).ToLower())
                        {
                            dgw1.CurrentCell = dgw1.Rows[i].Cells[0];
                            break;
                        }
                    }

                }
            }
            else if (ch_rs.Checked)
            {
                txt_letra.Focus();
                for (i = 0; i < dgw1.Rows.Count; i++)
                {
                    if (txt_letra.TextLength <= dgw1[1, i].Value.ToString().Length)
                    {
                        if (txt_letra.Text.ToLower() == dgw1[1, i].Value.ToString().Substring(0, txt_letra.TextLength).ToLower())
                        {
                            dgw1.CurrentCell = dgw1.Rows[i].Cells[1];
                            break;
                        }
                    }
                }
            }

        }

        private void ch_cod_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_cod.Checked)
            {
                dgw1.Sort(dgw1.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
                btn_buscar.Enabled = false;
                btn_sgt.Enabled = false;
                txt_letra.Clear();
                txt_letra.Focus();
            }
        }

        private void ch_rs_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_rs.Checked)
            {
                dgw1.Sort(dgw1.Columns[1], System.ComponentModel.ListSortDirection.Ascending);
                btn_buscar.Enabled = false;
                btn_sgt.Enabled = false;
                txt_letra.Clear();
                txt_letra.Focus();
            }
        }

        private void ch_ca_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_ca.Checked)
            {
                btn_buscar.Enabled = true;
                txt_letra.Clear();
                txt_letra.Focus();
            }
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            int i, f;
            txt_letra.Focus();
            btn_sgt.Enabled = true;
            for (i = 0; i < dgw1.Rows.Count; i++)
            {
                for (f = 0; f <= dgw1[1, i].Value.ToString().Length - txt_letra.TextLength; f++)
                {
                    if (txt_letra.TextLength <= dgw1[1, i].Value.ToString().Length)
                    {
                        if (txt_letra.Text.ToLower() == dgw1[1, i].Value.ToString().Substring(f, txt_letra.TextLength).ToLower())
                        {
                            dgw1.CurrentCell = dgw1.Rows[i].Cells[1];
                            fila = i + 1;
                            return;
                        }
                    }
                }
            }
        }

        private void btn_sgt_Click(object sender, EventArgs e)
        {
            int i, f;//antes de dar a siguiente primero se hace buscar para que lo ubique en la primera coincidencia luego se da siguiente, siguiente..., hasta encontrar el valor buscado.
            for (i = fila; i < dgw1.Rows.Count; i++)
            {
                for (f = 0; f <= dgw1[1, i].Value.ToString().Length - txt_letra.TextLength; f++)
                {
                    if (txt_letra.TextLength <= dgw1[1, i].Value.ToString().Length)
                    {
                        if (txt_letra.Text.ToLower() == dgw1[1, i].Value.ToString().Substring(f, txt_letra.TextLength).ToLower())
                        {
                            dgw1.CurrentCell = dgw1.Rows[i].Cells[1];
                            fila = i + 1;
                            return;
                        }
                    }
                }
            }
            MessageBox.Show("Ya no existen más registros !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btn_agregar_contenido_Click(object sender, EventArgs e)
        {
            dgw_articulo_contenido.Visible = false;
            Panel3.Visible = true;
            btn_agregar_contenido.Visible = true;
            btn_modificar_contenido.Visible = false;
            LIMPIAR_DETALLE_ART_CONTENIDO();
            txt_cod_art_contenido.Focus();
        }
        private void LIMPIAR_DETALLE_ART_CONTENIDO()
        {
            txt_cod_art_contenido.Clear();
            txt_desc_contenido.Clear();
            ch_sus_contenido.Checked = false;
        }

        private void btn_mod_contenido_Click(object sender, EventArgs e)
        {
            btn_guardar_contenido.Visible = false;
            btn_modificar_contenido.Visible = true;
            LIMPIAR_DETALLE_ART_CONTENIDO();
            CARGAR_DETALLES_ART_CONTENIDO();
            dgw_articulo_contenido.Visible = false;
            Panel3.Visible = true;
        }

        private void btn_eliminar_contenido_Click(object sender, EventArgs e)
        {
            if (dgw_articulo_contenido.Rows.Count > 0)
            {
                DialogResult rs = MessageBox.Show("¿ ESTA SEGURO DE ELIMINAR ?", "MENSAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    dgw_articulo_contenido.Rows.RemoveAt(dgw_articulo_contenido.CurrentRow.Index);
                }
            }
        }
        private bool valida_Guardar_Articulo_Contenido()
        {
            bool result = true;
            if (txt_cod_art_contenido.Text == "")
            {
                MessageBox.Show("Ingrese el codigo del articulo contenido !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_cod_art_contenido.Focus();
                return result = false;
            }
            if (txt_desc_contenido.Text == "")
            {
                MessageBox.Show("Ingrese la descripcion del articulo contenido !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_desc_contenido.Focus();
                return result = false;
            }
            //var query = from DataGridViewRow row in DGW_DET.Rows
            //            where row.Cells["codcla"].Value.ToString() == cbo_clase.SelectedValue.ToString()
            //            select row;
            //int cant = query.Count();
            //if (cant > 0)
            //{
            //    MessageBox.Show("El mismo Articulo y Clase ya existe !!!", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    cbo_clase.Focus();
            //    return result = false;
            //}
            return result;
        }
        private void btn_guardar_contenido_Click(object sender, EventArgs e)
        {
            if (!valida_Guardar_Articulo_Contenido())
                return;
            string sus_contenido = ch_sus_contenido.Checked == true ? "1" : "0";
            dgw_articulo_contenido.Rows.Add(txt_cod.Text, txt_cod_art_contenido.Text, txt_desc_contenido.Text, sus_contenido);

            Panel3.Visible = false;
            dgw_articulo_contenido.Visible = true;
            txt_cod_art_contenido.Focus();
        }
        private void btn_modificar_contenido_Click(object sender, EventArgs e)
        {
            dgw_articulo_contenido.CurrentRow.Cells["cod_art"].Value = txt_cod.Text;
            dgw_articulo_contenido.CurrentRow.Cells["cod_art_cont"].Value = txt_cod_art_contenido.Text;
            dgw_articulo_contenido.CurrentRow.Cells["desc_art_cont"].Value = txt_desc_contenido.Text;
            dgw_articulo_contenido.CurrentRow.Cells["st_sus_cont"].Value = ch_sus_contenido.Checked == true ? "1" : "0";
            Panel3.Visible = false;
            dgw_articulo_contenido.Visible = true;
            txt_cod_art_contenido.Focus();
        }
        private void btn_cancelar_contenido_Click(object sender, EventArgs e)
        {
            Panel3.Visible = false;
            dgw_articulo_contenido.Visible = true;
        }


    }
}
