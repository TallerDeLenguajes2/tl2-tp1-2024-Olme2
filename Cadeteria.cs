namespace Cadeteria;
public class Cliente{
    private string? nombre{get;set;}
    private string? direccion{get;set;}
    private string? telefono{get;set;}
    private string? datosReferenciaDireccion{get;set;}
}
public class Pedidos{
    private int numero{get;set;}
    private string? obs{get;set;}
    private Cliente? cliente{get;set;}
    public void verDireccionCliente(){

    }
    public void verDatosCliente(){

    }
}
public class Cadete{
    private int id{get;set;}
    private string? nombre{get;set;}
    private string? direccion{get;set;}
    private string? telefono{get;set;}
    private List<Pedidos>? listadoPedidos{get;set;}
    public double jornalACobrar(){
        double jornal;
        jornal=0;
        return jornal;
    }
    public void entregarPedido(Pedidos pedido){

    }
    public void agregarPedido(Pedidos pedido){

    }
    public void eliminarPedido(Pedidos pedido){
         
    }
    public List<Pedidos> listarPedidos(){
        List<Pedidos> lista=new List<Pedidos>();
        return lista;
    }
}
public class Cadeteria{
    private string? nombre{get;set;}
    private string? telefono{get;set;}
    private List<Cadete>? listadoCadetes{get;set;}
    public void asignarPedido(Cadete cadete, Pedidos pedido){

    }
    public string asignarInformeDeActividad(){
        string? informe="a";
        return informe;
    }
    public void agregarCadete(Cadete cadete){

    }
    public void eliminarCadete(Cadete cadete){
        
    }
}