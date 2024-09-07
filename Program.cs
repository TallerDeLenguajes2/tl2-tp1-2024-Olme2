AccesoADatos accesoADatos;
string archivoCadeteria;
string archivoCadetes;
Console.WriteLine("¿Desea cargar los datos desde un archivo JSON o CSV?");
Console.WriteLine("1. JSON");
Console.WriteLine("2. CSV");
int opcion;
while(!int.TryParse(Console.ReadLine(), out opcion)){
    Console.WriteLine("Opción no válida, intente de nuevo.");
    continue;
}
if(opcion==1){
    accesoADatos=new AccesoJSON();
    archivoCadeteria="Cadeteria.json";
    archivoCadetes="Cadetes.json";
}else{
    accesoADatos=new AccesoCSV();
    archivoCadeteria="Cadeteria.csv";
    archivoCadetes="Cadetes.csv";
}
Cadeteria cadeteria = Cadeteria.CargarDatosCadeteria(accesoADatos, archivoCadeteria, archivoCadetes);
while (true){
    Console.WriteLine("\n----- Gestión de Pedidos -----");
    Console.WriteLine("1. Dar de alta pedido");
    Console.WriteLine("2. Asignar pedido a cadete");
    Console.WriteLine("3. Cambiar estado de pedido");
    Console.WriteLine("4. Reasignar pedido a otro cadete");
    Console.WriteLine("5. Salir");
    Console.Write("Seleccione una opción: ");
    if (!int.TryParse(Console.ReadLine(), out opcion)){
        Console.WriteLine("Opción no válida, intente de nuevo.");
        continue;
    }
    switch (opcion){
        case 1:
            Interfaz.DarDeAltaPedido(cadeteria);
            break;
        case 2:
            Interfaz.AsignarPedidoACadete(cadeteria);
            break;
        case 3:
            Interfaz.CambiarEstadoPedido(cadeteria);
            break;
        case 4:
            Interfaz.ReasignarPedido(cadeteria);
            break;
        case 5:
            Interfaz.LeerInformes(cadeteria);
            return;
        default:
            Console.WriteLine("Opción no válida, intente de nuevo.");
            break;
    }
}

