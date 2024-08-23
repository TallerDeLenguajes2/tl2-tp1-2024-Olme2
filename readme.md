2a.
¿Cuál de estas relaciones considera que se realiza por composición y cuál por agregación?
Pedidos->Cliente Composicion
Cadeteria->Cadete Composicion
Pedidos->Cadete Agregacion

¿Qué métodos considera que debería tener la clase Cadetería y la clase Cadete?
Cadeteria:
    AsignarPedido(Cadete, Pedido)
    GenerarInformeDeActividad()
    AgregarCadete(Cadete)
    EliminarCadete(Cadete)
Cadete:
    EntregarPedido(Pedido)
    AgregarPedido(Pedido)
    EliminarPedido(Pedido)
    ListarPedidos()

Teniendo en cuenta los principios de abstracción y ocultamiento, ¿que atributos, propiedades y métodos deberían ser públicos y cuáles privados?.
Todos los campos son privados y los metodos y propiedades son publicos.

¿Cómo diseñaría los constructores de cada una de las clases?

