namespace Cadeteria;
public class Cliente{
    private string? nombre{get;set;}
    private string? direccion{get;set;}
    private string? telefono{get;set;}
    private string? datosReferenciaDireccion{get;set;}
    public Cliente(string Nombre, string Direccion, string Telefono, string DatosReferenciaDireccion){
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
    private int numero{get;set;}
    private string? obs{get;set;}
    private Cliente? cliente{get;set;}
    private string? estado{get;set;}
    public Pedidos(int Numero, string Obs, Cliente Cliente){
        numero=Numero;
        obs=Obs;
        cliente=Cliente;
        estado="Sin entregar";
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
}
public class Cadete{
    private int id{get;set;}
    private string? nombre{get;set;}
    private string? direccion{get;set;}
    private string? telefono{get;set;}
    private List<Pedidos> listadoPedidos{get;set;}
    private double jornal{get;set;}
    private int cantidadDePedidosEntregados{get;set;}
    public Cadete(int Id, string Nombre, string Direccion, string Telefono){
        id=Id;
        nombre=Nombre;
        direccion=Direccion;
        telefono=Telefono;
        listadoPedidos=new List<Pedidos>();
        jornal=0;
        cantidadDePedidosEntregados=0;
    }
    public void JornalACobrar(){
        jornal=500*cantidadDePedidosEntregados;
    }
    public bool SeEncuentraPedido(Pedidos pedido){
        return listadoPedidos.Contains(pedido);
    }
    public void EntregarPedido(Pedidos pedido){
        if(SeEncuentraPedido(pedido)){
            cantidadDePedidosEntregados++;
            pedido.EliminarCliente();
            pedido.cambiarEstadoAEntregado();
            EliminarPedido(pedido);
        }else{
            Console.WriteLine("El pedido no se encuentra en la lista de pedidos");
        }
    }
    public void AgregarPedido(Pedidos pedido){
        if(SeEncuentraPedido(pedido)){
            Console.WriteLine("El pedido ya se encuentra en la lista de pedidos");
        }else{
            listadoPedidos.Add(pedido);
        }
    }
    public void EliminarPedido(Pedidos pedido){
        if(SeEncuentraPedido(pedido)){
           listadoPedidos.Remove(pedido);
        }else{
           Console.WriteLine("El pedido no se encuentra en la lista de pedidos");
        }
    }
    
}
public class Cadeteria{
    private string? nombre{get;set;}
    private string? telefono{get;set;}
    private List<Cadete> listadoCadetes{get;set;}
    private int pedidosEntregados{get;set;}
    private int pedidosAsignados{get;set;}
    private int pedidosReasignados{get;set;}

    public Cadeteria(string Nombre, string Telefono){
        nombre=Nombre;
        telefono=Telefono;
        listadoCadetes=new List<Cadete>();
        pedidosEntregados=0;
        pedidosAsignados=0;
        pedidosReasignados=0;
    }
    public void AsignarPedido(Cadete cadete, Pedidos pedido){
        if(cadete.SeEncuentraPedido(pedido)){
            Console.WriteLine("El pedido ya se encuentra asignado al cadete");
        }else{
            cadete.AgregarPedido(pedido);
            pedidosAsignados++;
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
        string? informe=$"Se asignaron {pedidosAsignados} pedidos\nSe entregaron {pedidosEntregados} pedidos\nSe reasignaron {pedidosReasignados}";
        return informe;
    }
    public void agregarCadete(Cadete cadete){
        listadoCadetes.Add(cadete);
    }
    public void eliminarCadete(Cadete cadete){
        listadoCadetes.Remove(cadete);
   }
}