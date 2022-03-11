namespace EJERCICIO_DE_REPASO_6
{
    public partial class Form1 : Form
    {
        List<Cliente> clientes = new List<Cliente>();
        List<Carro> carros = new List<Carro>();
        List<Alquiler> alquileres = new List<Alquiler>();
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

        private void CargarCarros()
        {
            FileStream stream = new FileStream("Lista Carros.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                Carro carro = new Carro();
                carro.placa = reader.ReadLine();
                carro.marca = reader.ReadLine();
                carro.modelo = reader.ReadLine();
                carro.color = reader.ReadLine();
                carro.precio = Convert.ToInt16(reader.ReadLine());
 
                carros.Add(carro);
            }
            reader.Close();
        }

        private void CargarGrids()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            dataGridView1.DataSource = clientes;

            dataGridView2.DataSource = null;
            dataGridView2.Refresh();
            dataGridView2.DataSource = carros;

            dataGridView3.DataSource = null;
            dataGridView3.Refresh();
            dataGridView3.DataSource = alquileres;


        }

        private void Cargar_Click(object sender, EventArgs e)
        {
            CargarCliente();
            CargarCarros();
            CargarGrids();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string placa = textBox1.Text;
            string marca = textBox2.Text;
            string modelo= textBox3.Text;
            string color = textBox4.Text;
            int precioK= Convert.ToInt16(textBox5.Text);

            Carro carro = new Carro();
            carro.placa = placa;
            carro.marca = marca;
            carro.modelo= modelo;
            carro.color = color;
            carro.precio  = precioK;

            carros.Add(carro);
            CargarGrids();
        }

        private void CargaTotal_Click(object sender, EventArgs e)
        {
            int nit = Convert.ToInt16(textBox6.Text);
            string placa = textBox7.Text;
            string falquiler = textBox8.Text;
            string fdevolucion = textBox9.Text;
            int kilo = Convert.ToInt16(textBox10.Text);

            
            Cliente cliente = clientes.Find(clientes => clientes.Nit == nit);


            Alquiler alquilere = new Alquiler();
            alquilere.nombre = cliente.Nombre;
            alquilere.placa = placa;
            alquilere.alquiler = falquiler;
            alquilere.devolucion = fdevolucion;
            alquilere.kilo = kilo;

            alquileres.Add(alquilere);
            CargarGrids();
        }
    }
}