public class Cliente{
    private string? nombre{get;set;}
    private string? direccion{get;set;}
    private string? telefono{get;set;}
    private string? datosReferenciaDireccion{get;set;}
    public Cliente(string? Nombre, string? Direccion, string? Telefono, string? DatosReferenciaDireccion){
        nombre=Nombre;
        direccion=Direccion;
        telefono=Telefono;
        datosReferenciaDireccion=DatosReferenciaDireccion;
    }
    public string? VerNombreCliente(){
        return nombre;
    }
    public string? VerDireccionCliente(){
        return direccion;
    }
    public string? VerTelefonoCliente(){
        return telefono;
    }
    public string? VerRefCliente(){
        return datosReferenciaDireccion;
    }
}
public class Pedidos{
    private static int contador=1;
    private int numero{get;set;}
    private string? obs{get;set;}
    private Cliente? cliente{get;set;}
    private string? estado{get;set;}
    private Cadete? cadete{get;set;}
    public Pedidos(string? Obs, Cliente Cliente){
        numero=contador++;
        obs=Obs;
        cliente=Cliente;
        estado="Sin entregar";
        cadete=null;
    }
    public void VerNombreCliente(){
        Console.WriteLine("Nombre: "+cliente?.VerNombreCliente());
    }
    public void VerDireccionCliente(){
        Console.WriteLine("Direccion: "+cliente?.VerDireccionCliente());
    }
    public void VerTelefonoCliente(){
        Console.WriteLine("Telefono: "+cliente?.VerTelefonoCliente());
    }
    public void VerRefCliente(){
        Console.WriteLine("Datos de Referencia de Direccion: "+cliente?.VerRefCliente());
    }
    public void VerDatosCliente(){
        VerNombreCliente();
        VerDireccionCliente();
        VerTelefonoCliente();
        VerRefCliente();
    }
    public void EliminarCliente(){
        if(cliente!=null){
            cliente=null;
        }else{
            Console.WriteLine("El cliente no existe");
        }
    }
    public void cambiarEstadoAEntregado(){
        estado="Entregado";
    }
    public void cambiarEstadoASinEntregar(){
        estado="Sin entregar";
    }
    public int mostrarNumeroDePedido(){
        return numero;
    }
    public string? mostarEstadoDePedido(){
        return estado;
    }
    public void agregarCadeteAPedido(Cadete Cadete){
        cadete=Cadete;
    }
}
public class Cadete{
    public int id{get;set;}
    private string? nombre{get;set;}
    private string? direccion{get;set;}
    private string? telefono{get;set;}
    private int cantidadDePedidosEntregados{get;set;}
    public Cadete(int Id, string Nombre, string Direccion, string Telefono){
        id=Id;
        nombre=Nombre;
        direccion=Direccion;
        telefono=Telefono;
        cantidadDePedidosEntregados=0;
    }
    public int VerIdCadete(){
        return id;
    }
    public string? VerNombreCadete(){
        return nombre;
    }
    public void aumentarPedidosEntregados(){
        cantidadDePedidosEntregados++;
    }
    public int verCantidadDePedidosEntregados(){
        return cantidadDePedidosEntregados;
    }
}
public class Cadeteria{
    private string? nombre{get;set;}
    private string? telefono{get;set;}
    private static int pedidosEntregados{get;set;}
    private int pedidosReasignados{get;set;}
    private List<Cadete> listadoCadetes{get;set;}
    private List<Pedidos> listadoPedidos{get;set;}

    public Cadeteria(string Nombre, string Telefono){
        nombre=Nombre;
        telefono=Telefono;
        pedidosEntregados=0;
        pedidosReasignados=0;
        listadoCadetes=new List<Cadete>();
        listadoPedidos=new List<Pedidos>();
    }
    
    public void AsignarCadeteAPedido(int idCadete, int idPedido){
        Cadete? cadete=BuscarCadetePorId(idCadete);
        Pedidos? pedido=BuscarPedidoPorNumero(idPedido);
        if(cadete!=null && pedido!=null){
            if(pedido.mostarEstadoDePedido()=="Sin entregar"){
                pedido.agregarCadeteAPedido(cadete);
                pedido.cambiarEstadoAEntregado();
                pedido.EliminarCliente();
                cadete.aumentarPedidosEntregados();
                pedidosEntregados++;
                listadoPedidos.Add(pedido);
                Console.WriteLine("Pedido n° "+idPedido+" asignado con exito a cadete n° "+idCadete+" y entregado con exito");
            }else{
                Console.WriteLine("Pedido n° "+idPedido+" ya fue entregado");
            }
        }else{
            Console.WriteLine("El cadete n° "+idCadete+" o el pedido n° "+idPedido+" no se encuentra en la lista");
        }
    }
    public void ReasignarPedido(Cadete viejo, Cadete nuevo, Pedidos pedido){
        if(viejo!=null && nuevo!=null){
            if(viejo!=nuevo){
                pedido.agregarCadeteAPedido(nuevo);
                Console.WriteLine("Pedido n° "+pedido.mostrarNumeroDePedido()+" reasignado con exito del cadete n° "+viejo.VerIdCadete()+" al cadete n° "+nuevo.VerIdCadete());
            }else{
                Console.WriteLine("El cadete viejo y el nuevo son el mismo");
            }
        }else{
            Console.WriteLine("El cadete viejo o el nuevo no se encuentra en la lista");
        }
    }
    public string asignarInformeDeActividad(){
        string? informe = $"Se asignaron y entregaron {pedidosEntregados} pedidos\nSe reasignaron {pedidosReasignados}\n";
    informe += "CADETES\n";
    informe += String.Format("{0,-5}| {1,-20}| {2,-18}| {3,-6}\n", "ID", "NOMBRE", "PEDIDOS ENTREGADOS", "JORNAL");

    foreach (var cadete in listadoCadetes)
    {
        int id = cadete.VerIdCadete();
        informe += String.Format("{0,-5}| {1,-20}| {2,-18}| {3,-6}\n",
                                 id,
                                 cadete.VerNombreCadete(),
                                 cadete.verCantidadDePedidosEntregados(),
                                 JornalACobrar(id));
    }

    return informe;
    }
    public void agregarCadete(Cadete cadete){
        listadoCadetes.Add(cadete);
    }
    public void eliminarCadete(Cadete cadete){
        listadoCadetes.Remove(cadete);
   }
   public static Cadeteria CargarDatosCadeteria(string archivoCadeteria, string archivoCadetes){
            var cadeteriaDatos = File.ReadAllLines(archivoCadeteria).First().Split(';');
            Cadeteria cadeteria = new Cadeteria(cadeteriaDatos[0], cadeteriaDatos[1]);
            var cadetesDatos = File.ReadAllLines(archivoCadetes);
            foreach (var linea in cadetesDatos)
            {
                var datos = linea.Split(';');
                int id = int.Parse(datos[0]);
                string nombre = datos[1];
                string direccion = datos[2];
                string telefono = datos[3];

                Cadete cadete = new Cadete(id, nombre, direccion, telefono);
                cadeteria.agregarCadete(cadete);
            }

            return cadeteria;
    }
    public Pedidos? BuscarPedidoPorNumero(int numero){
        return listadoPedidos.FirstOrDefault(c => c.mostrarNumeroDePedido() == numero);
    }
    public Cadete? BuscarCadetePorId(int id){
        return listadoCadetes.FirstOrDefault(c => c.id == id);
    }
    public double JornalACobrar(int id){
        Cadete? cadete=BuscarCadetePorId(id);
        if(cadete!=null){
            return cadete.verCantidadDePedidosEntregados()*500;
        }
        return 0;
    }
    public void AgregarPedidoALaLista(Pedidos? pedido){
        if(pedido!=null){
            listadoPedidos.Add(pedido);
        }else{
            Console.WriteLine("No se pudo agregar el pedido, no existe");
        }
    }
}

public class Interfaz{
    public static void DarDeAltaPedido(Cadeteria cadeteria){
            Console.Write("Ingrese el nombre del cliente: ");
            string? nombreCliente = Console.ReadLine();
            Console.Write("Ingrese la dirección del cliente: ");
            string? direccionCliente = Console.ReadLine();
            Console.Write("Ingrese el teléfono del cliente: ");
            string? telefonoCliente = Console.ReadLine();
            Console.Write("Ingrese los datos de referencia de la dirección: ");
            string? referenciaDireccion = Console.ReadLine();
            Cliente cliente = new Cliente(nombreCliente, direccionCliente, telefonoCliente, referenciaDireccion);
            Console.Write("Ingrese las observaciones del pedido: ");
            string? obsPedido = Console.ReadLine();
            Pedidos pedido= new Pedidos(obsPedido, cliente);
            cadeteria.AgregarPedidoALaLista(pedido);
            Console.WriteLine("Pedido dado de alta exitosamente.");
    }
    public static void AsignarPedidoACadete(Cadeteria cadeteria){
        Console.Write("Ingrese el número del pedido: ");
        #pragma warning disable CS8604 // Posible argumento de referencia nulo
        int numeroPedido = int.Parse(Console.ReadLine());
        #pragma warning restore CS8604 // Posible argumento de referencia nulo
        Console.Write("Ingrese el id del cadete: ");
        #pragma warning disable CS8604 // Posible argumento de referencia nulo
        int idCadete = int.Parse(Console.ReadLine());
        cadeteria.AsignarCadeteAPedido(idCadete, numeroPedido);
    }
    public static void CambiarEstadoPedido(Cadeteria cadeteria)
        {
            Console.Write("Ingrese el número del pedido a cambiar de estado: ");
            #pragma warning disable CS8604 // Posible argumento de referencia nulo
            int numeroPedido = int.Parse(Console.ReadLine());
            #pragma warning restore CS8604 // Posible argumento de referencia nulo
            Pedidos? pedido=cadeteria.BuscarPedidoPorNumero(numeroPedido);
            if(pedido!=null){
                string? estado=pedido.mostarEstadoDePedido();
                Console.WriteLine($"El estado del pedido es '{estado}'");
                if(estado=="Entregado"){
                    pedido.cambiarEstadoASinEntregar();
                    Console.WriteLine("Estado del pedido cambiado a 'Sin Entregar'.");
                }else{
                    pedido.cambiarEstadoAEntregado();
                    Console.WriteLine("Estado del pedido cambiado a 'Entregado'.");
                }
            }else{
                Console.WriteLine("El pedido no existe.");
            }
        }
    public static void ReasignarPedido(Cadeteria cadeteria){
        #pragma warning disable CS8604 // Posible argumento de referencia nulo
        int idViejoCadete;
        int idNuevoCadete;
        Console.Write("Ingrese el número del pedido a reasignar: ");
        int numeroPedido = int.Parse(Console.ReadLine());
        Pedidos? pedido=cadeteria.BuscarPedidoPorNumero(numeroPedido);
        do{
            Console.Write("Ingrese el ID del cadete al que está asignado el pedido: ");
            idViejoCadete = int.Parse(Console.ReadLine());
            Console.Write("Ingrese el ID del nuevo cadete: ");
            idNuevoCadete = int.Parse(Console.ReadLine());
            if(idViejoCadete==idNuevoCadete){
                Console.WriteLine("Ingrese ids distintos");
            }
        }while(idViejoCadete==idNuevoCadete);
            Cadete? viejoCadete = cadeteria.BuscarCadetePorId(idViejoCadete);
            Cadete? nuevoCadete = cadeteria.BuscarCadetePorId(idNuevoCadete);
            if (viejoCadete != null && nuevoCadete != null){
                cadeteria.ReasignarPedido(viejoCadete, nuevoCadete, pedido);
                Console.WriteLine("Pedido reasignado con éxito.");
            }else{
                Console.WriteLine("Uno o ambos cadetes no existen.");
            }
    }
    public static void LeerInformes(Cadeteria cadeteria){
        string? informe=cadeteria.asignarInformeDeActividad();
        Console.WriteLine("PROGRAMA FINALIZADO, INFORME DE ACTIVIDAD:\n"+informe);
    }
}