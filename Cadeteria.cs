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
    public string? VerDireccionCliente(){
        return direccion;
    }
    public string? VerNombreCliente(){
        return nombre;
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
    private Cadete cadete{get;set;}
    public Pedidos(string? Obs, Cliente Cliente, Cadete Cadete){
        numero=contador++;
        obs=Obs;
        cliente=Cliente;
        estado="Sin entregar";
        cadete=Cadete;
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
}
public class Cadete{
    public int id{get;set;}
    private string? nombre{get;set;}
    private string? direccion{get;set;}
    private string? telefono{get;set;}
    private double jornal{get;set;}
    private int cantidadDePedidosEntregados{get;set;}
    public Cadete(int Id, string Nombre, string Direccion, string Telefono){
        id=Id;
        nombre=Nombre;
        direccion=Direccion;
        telefono=Telefono;
        jornal=0;
        cantidadDePedidosEntregados=0;
    }
    public bool SeEncuentraPedido(Pedidos pedido){
        return false;
    }
    public void EntregarPedido(Pedidos pedido){
        if(SeEncuentraPedido(pedido)){
            cantidadDePedidosEntregados++;
            pedido.EliminarCliente();
            pedido.cambiarEstadoAEntregado();
            EliminarPedido(pedido);
            Cadeteria.aumentarPedidosEntregados();
        }else{
            Console.WriteLine("El pedido no se encuentra en la lista de pedidos");
        }
    }
    public void AgregarPedido(Pedidos pedido){
        
    }
    public void EliminarPedido(Pedidos pedido){
        
    }
    public int VerCantidadPedidos(){
        return 0;
    }
    public string AsignarInformeCadete(int pedidosTotales){
        string informe=$"\nCadete {nombre}:\nSe entregaron {cantidadDePedidosEntregados} pedidos, se ganó ${jornal} por los pedidos y el promedio de pedidos entregados de este cadete fue de {((double)cantidadDePedidosEntregados/pedidosTotales)} pedidos";
        return informe;
    }
    public string? VerNombreCadete(){
        return nombre;
    }
    
}
public class Cadeteria{
    private string? nombre{get;set;}
    private string? telefono{get;set;}
    private static int pedidosEntregados{get;set;}
    private int pedidosAsignados{get;set;}
    private int pedidosReasignados{get;set;}
    private List<Cadete> listadoCadetes{get;set;}
    private List<Pedidos>? listadoPedidos{get;set;}

    public Cadeteria(string Nombre, string Telefono){
        nombre=Nombre;
        telefono=Telefono;
        listadoCadetes=new List<Cadete>();
        pedidosEntregados=0;
        pedidosAsignados=0;
        pedidosReasignados=0;
        listadoPedidos=new List<Pedidos>();
    }
    pub
    public void AsignarPedido(Cadete? cadete, Pedidos pedido){
        if(cadete!=null && pedido!=null){
            if(cadete.SeEncuentraPedido(pedido)){
                Console.WriteLine("El pedido ya se encuentra asignado al cadete");
            }else{
                cadete.AgregarPedido(pedido);
                pedidosAsignados++;
            }
        }else{
            Console.WriteLine("Cadete o Pedido inexistente");
        }
    }
    public void ReasignarPedido(Cadete viejo, Cadete nuevo, Pedidos pedido){
        if(viejo==nuevo){
            Console.WriteLine("El cadete no puede reasignar el pedido a si mismo");
        }else if(nuevo.SeEncuentraPedido(pedido)){
            Console.WriteLine("El pedido ya se encuentra asignado al nuevo cadete");
        }else if(!viejo.SeEncuentraPedido(pedido)){
            Console.WriteLine("El pedido no se encuentra asignado al viejo cadete, se lo asignara al nuevo");
            nuevo.AgregarPedido(pedido);
            pedidosAsignados++;
        }else{
            viejo.EliminarPedido(pedido);
            nuevo.AgregarPedido(pedido);
            Console.WriteLine("Pedido reasignado con exito");
            pedidosReasignados++;
        }
    }
    public string asignarInformeDeActividad(){
        string? informe=$"Se asignaron {pedidosAsignados} pedidos\nSe entregaron {pedidosEntregados} pedidos\nSe reasignaron {pedidosReasignados}\n";
        foreach(var cadete in listadoCadetes){
            cadete.JornalACobrar();
            informe+=cadete.AsignarInformeCadete(pedidosEntregados);
        }
        return informe;
    }
    public void agregarCadete(Cadete cadete){
        listadoCadetes.Add(cadete);
    }
    public void eliminarCadete(Cadete cadete){
        listadoCadetes.Remove(cadete);
   }
   public static void aumentarPedidosEntregados(){
        pedidosEntregados++;
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
    public void AgregarPedidoALista(Pedidos pedido){
        if(listadoPedidos!=null){
            listadoPedidos.Add(pedido);
        }else{
            Console.WriteLine("Lista de pedidos inexistente");
        }
    }
    public Pedidos? BuscarPedidoPorNumero(int numero){
        if(listadoPedidos!=null){
            foreach (var pedido in listadoPedidos){
                int numeroPedido=pedido.mostrarNumeroDePedido();
                if (numeroPedido == numero){
                    return pedido;
                }
            }
        }
        return null;
    }
    public Cadete? BuscarCadetePorId(int id){
        return listadoCadetes.FirstOrDefault(c => c.id == id);
    }
    public Cadete? SeleccionarCadeteAleatorio(){
        if(listadoCadetes.Count > 0){
            Random random = new Random();
            int index = random.Next(0, listadoCadetes.Count);
            return listadoCadetes[index];
        }else{
            Console.WriteLine("No hay cadetes");
            return null;
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
            Console.WriteLine("Pedido dado de alta exitosamente.");
    }
    public static void AsignarPedidoACadete(Cadeteria cadeteria){
        Console.Write("Ingrese el número del pedido: ");
        #pragma warning disable CS8604 // Posible argumento de referencia nulo
        int numeroPedido = int.Parse(Console.ReadLine());
        #pragma warning restore CS8604 // Posible argumento de referencia nulo
        Pedidos? pedido = cadeteria.BuscarPedidoPorNumero(numeroPedido);
        if (pedido == null){
            Console.WriteLine("El pedido no existe.");
            return;
        }
        Cadete? cadete = cadeteria.SeleccionarCadeteAleatorio();
        cadeteria.AsignarPedido(cadete, pedido);
        #pragma warning disable CS8602 // Desreferencia de una referencia posiblemente NULL.
        Console.WriteLine($"Pedido asignado al cadete {cadete.VerNombreCadete()}");
        #pragma warning restore CS8602 // Desreferencia de una referencia posiblemente NULL.
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
            var viejoCadete = cadeteria.BuscarCadetePorId(idViejoCadete);
            var nuevoCadete = cadeteria.BuscarCadetePorId(idNuevoCadete);
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