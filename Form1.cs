namespace EJERCICIO_DE_REPASO_6
{
    public partial class Form1 : Form
    {
        List<Cliente> clientes = new List<Cliente>();
        public Form1()
        {
            InitializeComponent();
        }

        private void CargarCliente()
        {
            FileStream stream = new FileStream("Lista Clientes.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                Cliente cliente = new Cliente();
                cliente.Nit = Convert.ToInt16(reader.ReadLine());
                cliente.Nombre = reader.ReadLine();
                cliente.Direccion = reader.ReadLine();


                clientes.Add(cliente);
            }
            reader.Close();
        }

        private void CargarGrids()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            dataGridView1.DataSource = clientes;

            
        }

        private void Cargar_Click(object sender, EventArgs e)
        {
            CargarCliente();
            CargarGrids();
        }
    }
}