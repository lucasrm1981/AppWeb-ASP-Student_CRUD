using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/* Bibliotecas para o Banco de Dados*/
using System.Data.SqlClient;
using System.Data;

namespace AppAlunos
{
    public partial class Default : System.Web.UI.Page
    {
        /* Criação da Conexão com palavras reservados SQL*/
        SqlConnection con = new SqlConnection();
        /* Criação dos comandos cmd SqlCommand com uso de palavras reservadas SQL */
        SqlCommand cmd = new SqlCommand();
        /* Criação do Adaptador */
        SqlDataAdapter  sda = new SqlDataAdapter();
        /* Criação da Tabela recebida pelo objeto dt DataTable para suas manipulações */
        DataTable dt = new DataTable();
        /* Criação do objeto de de exibição ds DataSheet */
        DataSet ds = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            /* Caminho da Conexão da string retirado  na propriedade da conexão com o Servidor */
            con.ConnectionString = "Data Source=36DE250000\\SENAC;Initial Catalog=school;Integrated Security=True";
            /* Abertura da Conexão */
            con.Open();
            /* Essa condição serve para que o conteúdo dentro desse if só seja executado na primeira vez */
            if (!Page.IsPostBack)
            {
                /* Chamda da Função de Exibição */
                dataShow();

                btnExibirId.Visible = false;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            /* Intanciação do objeto dt DataTable*/
            dt = new DataTable();
            /* Comando SQL que será executado */
            cmd.CommandText = "INSERT INTO student (first_name, last_name, city, department)VALUES('"+txbName.Text.ToString()+ "', '" + txbLastName.Text.ToString() + "', '"+txbCity.Text.ToString()+"', '"+txbDepartment.Text.ToString()+"')";
            /* Abertura da Conexão pelo cmd */
            cmd.Connection = con;
            /* Execução do Comando*/
            cmd.ExecuteNonQuery();
            /* Chamada da função de exibição */
            dataShow();
        }

        /* Classe de exibição dos dados */
        public void dataShow()
        {
            /* Instanciação do objeto ds */
            ds = new DataSet();
            /* Comando SQL */
            cmd.CommandText = "SELECT * FROM student";
            /* Conexão com Banco */
            cmd.Connection = con;
            /* Instanciãção do objeto de conexão */
            sda = new SqlDataAdapter(cmd);
            /* Adiciona ou atualiza linhas no DataSet para correspondência na fonte de dados. */
            sda.Fill(ds);
            /* Comando de execução */ 
            cmd.ExecuteNonQuery();
            /* GridView Students recebe o DataSheet*/
            grvStudents.DataSource = ds;
            /* Associa a fonte de dados ao controle GridView.*/
            grvStudents.DataBind(); 
            /* Fecha a Conexão */
            con.Close();
        }

        /* Ação onClick do botão Update*/
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            /* Intanciação do objeto dt DataTable*/
            dt = new DataTable();
            /* Comando SQL */
            cmd.CommandText = "UPDATE student  SET first_name='" + txbName.Text.ToString() + "', last_name='" + txbLastName.Text.ToString() + "', city='" + txbCity.Text.ToString() + "', department='" + txbDepartment.Text.ToString() + "' WHERE id='"+txbId.Text.ToString()+"'";
            /* Abre a Conexão */
            cmd.Connection = con;
            /* Executa a Query SQL */
            cmd.ExecuteNonQuery();
            /* Chama a função de Atualização */
            dataShow();
        }

        /* Ação do botão onClick Delete */
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            /* Intanciação do objeto dt DataTable*/
            dt = new DataTable();
            /* Comando SQL */
            cmd.CommandText = "DELETE student WHERE id='" + txbId.Text.ToString() + "'";
            /* Abre a Conexão */
            cmd.Connection = con;
            /* Executa a Query SQL */
            cmd.ExecuteNonQuery();
            /* Chama a função de Atualização */
            dataShow();
        }

        /* Oculta os campos do ID e Oculta o Botão */
        protected void btnOcultarId_Click(object sender, EventArgs e)
        {
            txbId.Visible = false;
            lblId.Visible = false;
            btnExibirId.Visible = true;
            btnOcultarId.Visible = false;
        }

        /* Exibe os Campos do ID  e Oculta o Botão*/
        protected void btnExibirId_Click(object sender, EventArgs e)
        {
            txbId.Visible = true;
            lblId.Visible = true; 
            btnOcultarId.Visible = true;
            btnExibirId.Visible = false;
        }
    }

   
}