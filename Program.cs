
Cadeteria cadeteria = Cadeteria.CargarDatosCadeteria("cadeteria.csv", "cadetes.csv");
while (true){
    Console.WriteLine("\n----- Gestión de Pedidos -----");
    Console.WriteLine("1. Dar de alta pedido");
    Console.WriteLine("2. Asignar pedido a cadete");
    Console.WriteLine("3. Cambiar estado de pedido");
    Console.WriteLine("4. Reasignar pedido a otro cadete");
    Console.WriteLine("5. Salir");
    Console.Write("Seleccione una opción: ");
    int opcion;
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

