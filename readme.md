2a.
¿Cuál de estas relaciones considera que se realiza por composición y cuál por agregación?
Pedidos->Cliente Composicion
Cadeteria->Cadete Composicion
Pedidos->Cadete Agregacion

¿Qué métodos considera que debería tener la clase Cadetería y la clase Cadete?
Cadeteria:
    AsignarPedido(Cadete, Pedido)
    AsignarInformeDeActividad()
    AgregarCadete(Cadete)
    EliminarCadete(Cadete)
Cadete:
    EntregarPedido(Pedido)
    AgregarPedido(Pedido)
    EliminarPedido(Pedido)

Teniendo en cuenta los principios de abstracción y ocultamiento, ¿que atributos, propiedades y métodos deberían ser públicos y cuáles privados?.
Todos los campos son privados y los metodos y propiedades son publicos.

¿Cómo diseñaría los constructores de cada una de las clases?

public Cliente(string Nombre, string Direccion, string Telefono, string DatosReferenciaDireccion){
        nombre=Nombre;
        direccion=Direccion;
        telefono=Telefono;
        datosReferenciaDireccion=DatosReferenciaDireccion;
    }

public Pedidos(int Numero, string Obs, Cliente Cliente){
        numero=Numero;
        obs=Obs;
        cliente=Cliente;
    }

public Cadete(int Id, string Nombre, string Direccion, string Telefono){
        id=Id;
        nombre=Nombre;
        direccion=Direccion;
        telefono=Telefono;
        listadoPedidos=new List<Pedidos>();
        jornal=0;
    }

public Cadeteria(string Nombre, string Telefono){
        nombre=Nombre;
        telefono=Telefono;
        listadoCadetes=new List<Cadete>();
    }

¿Se le ocurre otra forma que podría haberse realizado el diseño de clases?
Yo creo que el diseño esta bastante optimo, agregaria la variable double jornal a la clase cadete. Luego, para tener los atributos private y que puedan ser usados por otras clases, agregaria
metodos que devuelven dichos atributos cuando son invocados desde otras clases para seguir el concepto de encapsulacion.